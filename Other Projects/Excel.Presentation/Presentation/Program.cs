﻿using Excel.Presentation.Domain.Entities;
using Excel.Presentation.Persistence.Configurations;
using Excel.Presentation.Persistence.Contexts;
using Excel.Presentation.Services;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Excel.Presentation.Presentation
{
    class Program
    {
        private readonly static FakeDataService _fakeDataService = new FakeDataService();

        static void Main()
        {


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            using (var context = new StudentContext(new DbContextOptionsBuilder<StudentContext>().UseNpgsql(ConfigurationsDb.GetString("ConnectionStrings:PostgreSQL")).Options))
            {

                List<Student> excelData = ReadDataFromExcel($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Excel\\Exp.xlsx");
                excelData.AddRange<Student>(_fakeDataService.GeneratePetData(3).ToArray());


                foreach (var student in excelData)
                {
                    var existingStudent = context.Students.FirstOrDefault(s => s.Name == student.Name);

                    if (existingStudent is null)
                    {
                        context.Students.Add(student);
                    }
                }

                CompareAndUpdateExcelData(context, excelData);
                context.SaveChanges();
            }

            Console.WriteLine("The data was processed successfully.");

        }

        static void CompareAndUpdateExcelData(StudentContext context, List<Student> excelData)
        {
            foreach (var dbStudent in context.Students)
            {
                var excelStudent = excelData.FirstOrDefault(e => e.Id == dbStudent.Id);

                if (excelStudent == null)
                {
                    excelData.Add(dbStudent);
                }
            }


        }

        static List<Student> ReadDataFromExcel(string excelFilePath)
        {
            List<Student> students = new List<Student>();

            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var name = worksheet.Cells[row, 1].Text;
                    var age = Int16.Parse(worksheet.Cells[row, 2].Text);
                    var department = worksheet.Cells[row, 3].Text;
                    var idText = worksheet.Cells[row, 4].Text;
                    var id = !string.IsNullOrEmpty(idText)
                        ? Guid.Parse(idText)
                        : Guid.NewGuid();


                    students.Add(new Student { Id = id, Name = name, Age = age, Department = department });
                }
            }

            return students;
        }
    }
}
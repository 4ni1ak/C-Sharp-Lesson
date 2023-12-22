using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
public interface IEntity<T>
{
    T Id { get; set; }
}

public abstract class Shape : IEntity<Guid>
{
    public Guid Id { get; set; }

    public Shape()
    {
        Id = Guid.NewGuid();
    }
}

public abstract class TwoDimensionalShape : Shape
{
    public abstract double Area { get; }

    protected TwoDimensionalShape() : base()
    {

    }
    public override string ToString()
    {
        return base.ToString();
    }
}

public abstract class ThreeDimensionalShape : Shape
{
    public abstract double Area { get; }
    public abstract double Volume { get; }
    public override string ToString()
    {
        return base.ToString();
    }

    protected ThreeDimensionalShape() : base()
    {
    }
}

public class Triangle : TwoDimensionalShape
{
    public (double x, double y)[] Points { get; set; }//Yep Value Tuple:))

    internal Triangle((double x, double y)[] points)
    {
        Points = points;
    }

    public override double Area
    {
        get
        {
            var a = Math.Sqrt(Math.Pow(Points[1].x - Points[0].x, 2) + Math.Pow(Points[1].y - Points[0].y, 2));
            var b = Math.Sqrt(Math.Pow(Points[2].x - Points[1].x, 2) + Math.Pow(Points[2].y - Points[1].y, 2));
            var c = Math.Sqrt(Math.Pow(Points[0].x - Points[2].x, 2) + Math.Pow(Points[0].y - Points[2].y, 2));
            var s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }

    public override string ToString() => $"Triangle with points {Points[1]}, {Points[2]}, and {Points[3]}";
}

public class Tetrahedron : ThreeDimensionalShape
{
    public (double x, double y, double z)[] Points { get; set; }

    internal Tetrahedron((double x, double y, double z)[] points) : base()
    {
        if (points.Length != 4)
            throw new ArgumentException("A tetrahedron must have 4 points.");

        Points = points;
    }

    private double EdgeLength => Math.Sqrt(Math.Pow(Points[1].x - Points[0].x, 2) + Math.Pow(Points[1].y - Points[0].y, 2) + Math.Pow(Points[1].z - Points[0].z, 2));

    public override double Area => Math.Sqrt(3) * Math.Pow(EdgeLength, 2); // √3 * a^2

    public override double Volume => Math.Pow(EdgeLength, 3) / (6 * Math.Sqrt(2)); // a ^ 3 / (6√2)

    public override string ToString() => $"Tetrahedron with points {Points[0]}, {Points[1]}, {Points[2]}, and {Points[3]}";
}
public class Cube : ThreeDimensionalShape
{
    public (double x, double y, double z)[] Points { get; set; }

    public Cube((double x, double y, double z)[] points) : base()
    {

        Points = points;
    }

    private double EdgeLength => Math.Sqrt(Math.Pow(Points[1].x - Points[0].x, 2) + Math.Pow(Points[1].y - Points[0].y, 2) + Math.Pow(Points[1].z - Points[0].z, 2));

    public override double Area => 6 * Math.Pow(EdgeLength, 2); // 6a^2

    public override double Volume => Math.Pow(EdgeLength, 3); // a^3

    public override string ToString() => $"Cube with points {Points[0]}, {Points[1]}, {Points[2]}, {Points[3]}, {Points[4]}, {Points[5]}, {Points[6]}, and {Points[7]}";
}

public class Sphere : ThreeDimensionalShape
{
    public (double x, double y, double z) Center { get; set; }
    public double Radius { get; set; }

    public Sphere((double x, double y, double z) center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public override double Area => 4 * Math.PI * Math.Pow(Radius, 2); // 4πr^2

    public override double Volume => 4 / 3 * Math.PI * Math.Pow(Radius, 3); // 4/3πr^3

    public override string ToString() => $"Sphere with center {Center} and radius {Radius}";
}

public class Circe : TwoDimensionalShape
{
    public (double x, double y) Center { get; set; }
    public double Radius { get; set; }

    public Circe((double x, double y) center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public override double Area => Math.PI * Math.Pow(Radius, 2); // πr^2

    public override string ToString() => $"Circle with center {Center} and radius {Radius}";
}

public class Square : TwoDimensionalShape
{
    public (double x, double y)[] Points { get; set; }

    public Square((double x, double y)[] points)
    {
        Points = points;
    }

    private double EdgeLength => Math.Sqrt(Math.Pow(Points[1].x - Points[0].x, 2) + Math.Pow(Points[1].y - Points[0].y, 2));

    public override double Area => Math.Pow(EdgeLength, 2); // a^2

    public override string ToString() => $"Square with points {Points[0]}, {Points[1]}, {Points[2]}, and {Points[3]}";
}


class Program
{
    static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();

        Random random = new Random();

        stopwatch.Start();
        List<Shape> shapes = new List<Shape>();

        #region ShapeMaker

        int cubeCount = 20;
        int sphereCount = 30;
        int circleCount = 40;
        int squareCount = 50;
        int triangleCount = 10;
        int tetrahedronCount = 20;

        for (int i = 0; i < triangleCount; i++)
        {
            shapes.Add(new Triangle(
                new (double, double)[] {
            (random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble())
                }));
        }

        for (int i = 0; i < tetrahedronCount; i++)
        {
            shapes.Add(new Tetrahedron(
                new (double, double, double)[] {
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble())
                }));
        }

        for (int i = 0; i < cubeCount; i++)
        {
            shapes.Add(new Cube(
                new (double, double, double)[] {
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble(), random.NextDouble())
                }));
        }

        for (int i = 0; i < sphereCount; i++)
        {
            shapes.Add(new Sphere(
                (random.NextDouble(), random.NextDouble(), random.NextDouble()),
                random.NextDouble()));
        }

        for (int i = 0; i < circleCount; i++)
        {
            shapes.Add(new Circe(
                (random.NextDouble(), random.NextDouble()),
                random.NextDouble()));
        }

        for (int i = 0; i < squareCount; i++)
        {
            shapes.Add(new Square(
                new (double, double)[] {
            (random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble()),
            (random.NextDouble(), random.NextDouble())
                }));
        }
        #endregion

        stopwatch.Stop();
        var shapelistTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();

        stopwatch.Start();
        Parallel.ForEach(shapes, shape =>
        {
            Console.WriteLine($"The end of {nameof(shape)}");

            switch (shape)
            {
                case TwoDimensionalShape twoDimensional:
                    Console.WriteLine($"Area: {twoDimensional.Area}");
                    break;
                case ThreeDimensionalShape threeDShape:
                    Console.WriteLine($"Area: {threeDShape.Area}");
                    Console.WriteLine($"Volume: {threeDShape.Volume}");
                    break;
            }

            Console.WriteLine($"The end of {shape.GetType()}");
            Console.WriteLine();
        });
        //stopwatch.Stop();

        var parallelTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();

        stopwatch.Start();
        foreach (var shape in shapes)
        {

            switch (shape)
            {
                case TwoDimensionalShape twoDimensional:
                    Console.WriteLine($"The start of {twoDimensional.GetType()}");
                    Console.WriteLine($"Area: {twoDimensional.Area}");
                    break;
                case ThreeDimensionalShape threeDShape:
                    Console.WriteLine($"{threeDShape.GetType()}");
                    Console.WriteLine($"Area: {threeDShape.Area}");
                    Console.WriteLine($"Volume: {threeDShape.Volume}");

                    break;
            }
            Console.WriteLine($"The end of {nameof(shape)}");

        }
        stopwatch.Stop();
        var foreachTime = stopwatch.ElapsedMilliseconds;
        Console.WriteLine($"shapelistTime:{shapelistTime},,,,\n parallelTime:{parallelTime},,,, \nforeachTime:{foreachTime}");
        /*
         *shapelistTime:40
         * parallelTime:27653
         *  foreachTime:7723 
        */
        Console.ReadLine();
    }
}

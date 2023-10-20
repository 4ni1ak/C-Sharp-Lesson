using HealtApp.Domain.Common;
using HealtApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealtApp.Domain.Entities
{
	internal class Patient : Person<Guid>
	{
		public string Illnes { get; set; }// for the doc
		public string DescriptionDisease { get; set; }
		public int BigBeats { get; set; }
		public int SmallBeats { get; set; }


		public int MaxHeartRate
		{
			get
			{
				
				if ( Gender is Genders.Male)
				{
					return 220 - Age.Value;
				}
				else if (Gender is Genders.Female)
				{
					return 226 - Age.Value;
				}

				else
				{
					return 220 - Age.Value;
				}
			}
			set { }
		}

		public int TargetHeartRateMin
		{
			get
			{
				return (int)(MaxHeartRate * 0.5);
			}
			set { }
		}

		public int TargetHeartRateMax
		{
			get
			{
				return (int)(MaxHeartRate * 0.85);
			}
			set { }
		}


		public Patient(string name, string surName, DateTime birthday, int bigBeats, int smallBeats, string descriptionDisease, Genders genders = Genders.Other)
		{
			Id = Guid.NewGuid();
			CreatedOn = DateTime.Now;
			FirstName = name;
			LastName = surName;
			Birthday = birthday;
			BigBeats = bigBeats;
			SmallBeats = smallBeats;
			DescriptionDisease = descriptionDisease;
			Age = DateTime.Now.Year - birthday.Year;
			Gender = genders;
		}
	}
}

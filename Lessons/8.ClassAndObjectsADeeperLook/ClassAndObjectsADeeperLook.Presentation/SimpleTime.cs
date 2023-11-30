using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObjectsADeeperLook.Presentation
{
    public class SimpleTime
    {
        private int hour; // 0-23
        private int minute; // 0-59
        private int second; // 0-59

        public SimpleTime(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public string BuildString() =>
            $"{"this.ToUniversalString()",24}: {this.ToUniversalString()}" +
            $"\n{"ToUniversalString()",24}: {ToUniversalString()}";
        
        public string ToUniversalString() => $"{this.hour: D2}:{this.minute: D2}:{this.second: D2}";
    }
}
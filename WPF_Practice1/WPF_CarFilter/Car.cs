using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_CarFilter
{
    class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string Mileage { get; set; }

        public Car()
        {
            Year = 0;
            Make = string.Empty;
            Color = string.Empty;
            Mileage = string.Empty;
        }

        public Car(string line)
        {
            string[] pieces = line.Split(',');
            Year = Convert.ToInt32(pieces[0]);
            Make = pieces[1];
            Color = pieces[2];
            Mileage = pieces[3];
        }

        public override string ToString()
        {
            return $"{Year}, {Make} {Color} - {Mileage}"; 
        }
    }
}

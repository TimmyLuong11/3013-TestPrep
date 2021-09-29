using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Practice2
{
    class ClassPopulation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Photo { get; set; }

        public ClassPopulation()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Country = string.Empty;
            Photo = string.Empty;
        }

        public ClassPopulation(string line)
        {
            string[] pieces = line.Split(",");
            FirstName = pieces[0];
            LastName = pieces[1];
            Email = pieces[2];
            Phone = pieces[3];
            Country = pieces[4];
            Photo = pieces[5];
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Phone} or {Email}";
        }
    }
}

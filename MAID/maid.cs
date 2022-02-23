using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAID
{
    class Maid
    {
        private int id;
        private string name;
        private string surname;
        private float rating;
        private int roomsCleaned;
        private float salary;

        public Maid(int id, string name, string surname, float rating, int roomsCleaned, float salary)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Rating = rating;
            this.RoomsCleaned = roomsCleaned;
            this.Salary = salary;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public float Rating { get => rating; set => rating = value; }
        public int RoomsCleaned { get => roomsCleaned; set => roomsCleaned = value; }
        public float Salary { get => salary; set => salary = value; }
    }
}

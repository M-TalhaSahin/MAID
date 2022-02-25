using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAID
{
    class Cleaning
    {
        private Maid maid;
        private dataBase.odaTipi type;
        private string roomNumber;
        private string date;
        private int rating;
        private int cId;

        public Cleaning(Maid maid, dataBase.odaTipi type, string roomNumber, string date, int rating, int cId)
        {
            this.Maid = maid;
            this.Type = type;
            this.RoomNumber = roomNumber;
            this.Date = date;
            this.Rating = rating;
            this.CId = cId;
        }

        public string RoomNumber { get => roomNumber; set => roomNumber = value; }
        public string Date { get => date; set => date = value; }
        public int Rating { get => rating; set => rating = value; }
        public int CId { get => cId; set => cId = value; }
        internal Maid Maid { get => maid; set => maid = value; }
        internal dataBase.odaTipi Type { get => type; set => type = value; }
    }
}

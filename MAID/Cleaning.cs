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

        public Cleaning(Maid maid, dataBase.odaTipi type, string roomNumber, string date)
        {
            this.Maid = maid;
            this.Type = type;
            this.RoomNumber = roomNumber;
            this.Date = date;
        }

        public string RoomNumber { get => roomNumber; set => roomNumber = value; }
        public string Date { get => date; set => date = value; }
        internal Maid Maid { get => maid; set => maid = value; }
        internal dataBase.odaTipi Type { get => type; set => type = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MAID
{
    class dataBase
    {
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "PDPS";
        //private static string Password = "6026";
        //private static string Password = "4458771";
        private static string Password = "by145278";
        private static string Port = "5432";
        private static NpgsqlConnection connection;

        public enum odaTipi
        {
            cikis = 0,
            bakim = 1
        }
        public struct CalcResult
        {
            public double result;
            public DateTime date;
            public CalcResult(double _result, DateTime _date)
            {
                result = _result;
                date = _date;
            }
        }

        public dataBase()
        {
            string connString =
                   String.Format(
                       "Server={0};Port={1};Database={2};User Id={3};Password={4}",
                       Host,
                       Port,
                       DBname,
                       User,
                       Password
                       );

            connection = new NpgsqlConnection(connString);
            
        }
     
        public void insertMaid(string name, string surname)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("insert into tblmaid(name, surname) values('{0}', '{1}')", name, surname), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void removeMaid(int ID)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("update tblmaid set isactive = false where maid_id = {0}", ID), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Maid> selectMaidList(bool isActive)
        {
            List<Maid> maids = new List<Maid>();
            using (var command = new NpgsqlCommand("select maid_id, name, surname, ratingavg, roomscleaned, salary from tblmaid where isactive = " + isActive.ToString(), connection))
            {
                connection.Open();
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    maids.Add(new Maid(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), float.Parse(dr[3].ToString()), Convert.ToInt32(dr[4]), Convert.ToInt32(dr[5])));
                }
                connection.Close();
            }
            return maids;
        }
        public void insertTemizlik(int maidID, odaTipi odaTipi, string roomNumer, int rate, string yorum)
        {
            float caring = selectCaring();
            float checkout = selectCheckout();

            connection.Open();
            var command = new NpgsqlCommand(String.Format("insert into tbltemizlikkayit(maid_id, odatipi, date, odano, rate, yorum) values({0}, CAST({1} AS bit), '{5}', {2}, {3}, '{4}')", 
                maidID, (int)odaTipi, roomNumer, rate, yorum, DateTime.Now.ToString("yyyy-MM-dd")), connection);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand(String.Format("select ratingavg, roomscleaned, salary from tblmaid where maid_id = {0}", maidID), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            dr.Read();
            double newrate;
            int roomscleaned = Convert.ToInt32(dr[1].ToString());

            if (dr[1].ToString() == "0") newrate = rate;
            else newrate = Math.Round(((float.Parse(dr[0].ToString()) * roomscleaned) + rate) / (roomscleaned + 1), 2);
            

            float miktar = (float.Parse(dr[2].ToString())); // oda ücreti
            connection.Close();
            connection.Open();

            if (odaTipi == dataBase.odaTipi.bakim) miktar += caring;
            else miktar += checkout;


            command = new NpgsqlCommand(String.Format("update tblmaid set roomscleaned = {0}, ratingavg = {1}, salary = {2} where maid_id = {3}", roomscleaned + 1, newrate.ToString().Replace(",","."), miktar, maidID), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Cleaning> selectCleaningList(bool isActive, int id = -1, string name = "", string date = "", string rtype = "")
        {
            string filter = "";
            if(id != -1)
            {
                filter = " and m.maid_id = " + id.ToString();
            }
            else if(name != "")
            {
                filter = " and m.surname LIKE '%' || '" + name + "' || '%'";
            }
            else if(date != "")
            {
                filter = " and t.date = TO_DATE('" + (date.Split('/')[0] + "-" + date.Split('/')[1] + "-" + date.Split('/')[2] + "', 'MM-dd-yyyy')");
            }
            else if(rtype != "")
            {
                if(rtype == "checkout")
                {
                    filter = " and t.odatipi = CAST(0 AS bit)";
                }
                else if(rtype == "care")
                {
                    filter = " and t.odatipi = CAST(1 AS bit)";
                }
            }
            List<Cleaning> cleanings = new List<Cleaning>();
            using (var command = new NpgsqlCommand("select m.maid_id, m.name, m.surname, t.odatipi, t.odano, t.date, t.rate, m.ratingavg, m.roomscleaned, m.salary, t.temizlik_id " +
                "from tbltemizlikkayit as t left join tblmaid as m on t.maid_id = m.maid_id " +
                "where m.isactive = " + isActive.ToString() + filter, connection))
            {
                connection.Open();
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    dataBase.odaTipi type;
                    if(!Convert.ToBoolean(dr[3])) type = dataBase.odaTipi.cikis;
                    else type = dataBase.odaTipi.bakim;

                    cleanings.Add(new Cleaning(new Maid(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), float.Parse(dr[7].ToString()), Convert.ToInt32(dr[8]), Convert.ToInt32(dr[9])),
                        type, dr[4].ToString(), dr[5].ToString().Split(' ')[0], Convert.ToInt32(dr[6]), Convert.ToInt32(dr[10])));
                }
                connection.Close();
            }
            return cleanings;
        }
        public string selectCleaningYorum(int cleaningId)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("select yorum from tbltemizlikkayit where temizlik_id = {0}", cleaningId), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            dr.Read();
            string rstring = dr[0].ToString();
            connection.Close();
            return rstring;
        }

        public void insertUser(string name, string surname, string username,string password)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("insert into tbluser(name, surname, username, password) values('{0}', '{1}', '{2}', '{3}')", name, surname, username, password), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int usernameSearch(string username)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("select count(*) from tbluser where username = '{0}'", username), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            dr.Read();
            int value = Convert.ToInt32(dr[0].ToString());
            connection.Close();
            return value;
        }

        public int checkUser(string username, string password)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("select count(*) from tbluser where username = '{0}' and password = '{1}'", username, password), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            dr.Read();
            int value = Convert.ToInt32(dr[0].ToString());
            connection.Close();
            return value;
        }

        public void updatePrice(double checkout, double caring)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("update tblprice set checkout={0}, caring={1} where price_id=1", checkout, caring), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public float selectCheckout()
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("select checkout from tblprice where price_id=1"), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            dr.Read();
            float value = float.Parse(dr[0].ToString());
            connection.Close();
            return value;
        }

        public float selectCaring()
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("select caring from tblprice where price_id=1"), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            dr.Read();
            float value = float.Parse(dr[0].ToString());
            connection.Close();
            return value;
        }

        public void insertCalculation(string type, double result)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("insert into public.\"tblCalculation\"(type, result, date) values('{0}', {1}, '{2}')", 
                type, result.ToString().Replace(",", "."), DateTime.Now.ToString("yyyy-MM-dd")), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public List<CalcResult> selectCalculation(string type, DateTime startDate, DateTime endDate)
        {
            connection.Open();
            List<CalcResult> results = new List<CalcResult>();
            var command = new NpgsqlCommand(String.Format("select result, date from public.\"tblCalculation\" where type='{0}' and date between '{1}' and '{2}'",
                type, startDate.ToShortDateString(), endDate.ToShortDateString()), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                CalcResult res = new CalcResult(float.Parse(dr[0].ToString()), Convert.ToDateTime(dr[1].ToString()));
                results.Add(res);
            }
            connection.Close();
            return results;
        }

        public void insertBCVCalc(int id, double result)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("insert into public.\"tblBCV\"(maidid, result, date) values('{0}', {1}, '{2}')",
               id, result.ToString().Replace(",", "."), DateTime.Now.ToString("yyyy-MM-dd")), connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public List<CalcResult> selectBCV(int id, DateTime startDate, DateTime endDate)
        {
            connection.Open();
            List<CalcResult> results = new List<CalcResult>();
            var command = new NpgsqlCommand(String.Format("select result, date from public.\"tblBCV\" where maidid ='{0}' and date between '{1}' and '{2}'",
                id, startDate.ToShortDateString(), endDate.ToShortDateString()), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                CalcResult res = new CalcResult(float.Parse(dr[0].ToString()), Convert.ToDateTime(dr[1].ToString()));
                results.Add(res);
            }
            connection.Close();
            return results;
        }

        public void ClearSalary(int id)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("update tblmaid set salary = 0 where maid_id = {0}", id), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}

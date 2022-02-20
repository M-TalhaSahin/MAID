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
        private static string Password = "4458771";
        private static string Port = "5432";
        private static NpgsqlConnection connection;

        public enum odaTipi
        {
            cikis = 0,
            bakim = 1
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
        public void clearDB()
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("delete from tbltemizlikkayit"), connection);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand(String.Format("delete from tblmaid"), connection);
            command.ExecuteNonQuery();
            connection.Close();
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
            var command = new NpgsqlCommand(String.Format("delete from tblmaid where maid_id = {0}", ID), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Maid> selectMaidList()
        {
            List<Maid> maids = new List<Maid>();
            using (var command = new NpgsqlCommand("select maid_id, name, surname, ratingavg, roomscleaned from tblmaid", connection))
            {
                connection.Open();
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    maids.Add(new Maid(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), float.Parse(dr[3].ToString()), Convert.ToInt32(dr[4])));
                }
                connection.Close();
            }
            return maids;
        }
        public void insertTemizlik(int maidID, odaTipi odaTipi, string roomNumer, int rate)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("insert into tbltemizlikkayit(maid_id, odatipi, date, odano, rate) values({0}, CAST({1} AS bit), NOW(), {2}, {3})", 
                maidID, (int)odaTipi, roomNumer, rate), connection);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand(String.Format("select ratingavg, roomscleaned from tblmaid where maid_id = {0}", maidID), connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            dr.Read();
            float newrate;
            int roomscleaned = Convert.ToInt32(dr[1].ToString());
            if (dr[1].ToString() == "0") newrate = rate;
            else newrate = ((float.Parse(dr[0].ToString()) * roomscleaned) + rate) / (roomscleaned + 1);
            connection.Close();
            connection.Open();
            command = new NpgsqlCommand(String.Format("update tblmaid set roomscleaned = {0}, ratingavg = {1} where maid_id = {2}", roomscleaned + 1, newrate, maidID), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Cleaning> selectCleaningList()
        {
            List<Cleaning> cleanings = new List<Cleaning>();
            using (var command = new NpgsqlCommand("select m.maid_id, m.name, m.surname, t.odatipi, t.odano, t.date, t.rate, m.ratingavg, m.roomscleaned from tbltemizlikkayit as t left join tblmaid as m on t.maid_id = m.maid_id", connection))
            {
                connection.Open();
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    dataBase.odaTipi type;
                    if(!Convert.ToBoolean(dr[3])) type = dataBase.odaTipi.cikis;
                    else type = dataBase.odaTipi.bakim;

                    cleanings.Add(new Cleaning(new Maid(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), float.Parse(dr[7].ToString()), Convert.ToInt32(dr[8])),
                        type, dr[4].ToString(), dr[5].ToString().Split(' ')[0], Convert.ToInt32(dr[6])));
                }
                connection.Close();
            }
            return cleanings;
        }
    }
}

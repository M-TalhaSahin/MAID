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
            var command = new NpgsqlCommand(String.Format("delete from tblmaid"), connection);
            command.ExecuteNonQuery();
            command = new NpgsqlCommand(String.Format("delete from tbltemizlikkayit"), connection);
            command.ExecuteNonQuery();
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
            var command = new NpgsqlCommand(String.Format("delete from tblmaid where maid_id = {0}", ID), connection);
            command.ExecuteNonQuery();
        }
        public List<Maid> selectMaidList()
        {
            List<Maid> maids = new List<Maid>();
            using (var command = new NpgsqlCommand("select maid_id, name, surname from tblmaid", connection))
            {
                connection.Open();
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    maids.Add(new Maid(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()));
                }
                connection.Close();
            }
            return maids;
        }
        public void insertTemizlik(int maidID, odaTipi odaTipi, string roomNumer)
        {
            connection.Open();
            var command = new NpgsqlCommand(String.Format("insert into tbltemizlikkayit(maid_id, odatipi, date, odano) values({0}, CAST({1} AS bit), NOW(), {2})", maidID, (int)odaTipi, roomNumer), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Cleaning> selectCleaningList()
        {
            List<Cleaning> cleanings = new List<Cleaning>();
            using (var command = new NpgsqlCommand("select m.maid_id, m.name, m.surname, t.odatipi, t.odano, t.date from tbltemizlikkayit as t left join tblmaid as m on t.maid_id = m.maid_id", connection))
            {
                connection.Open();
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    dataBase.odaTipi type;
                    if(!Convert.ToBoolean(dr[3])) type = dataBase.odaTipi.cikis;
                    else type = dataBase.odaTipi.bakim;

                    cleanings.Add(new Cleaning(new Maid(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString()),
                        type, dr[4].ToString(), dr[5].ToString().Split(' ')[0]));
                }
                connection.Close();
            }
            return cleanings;
        }
    }
}

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
        // Obtain connection string information from the portal
        //
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
            connection.Open();
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
            var command = new NpgsqlCommand(String.Format("insert into tblmaid(name, surname) values('{0}', '{1}')", name, surname), connection);
            command.ExecuteNonQuery();
            Console.Out.WriteLine("\nQuery executed.\n");
        }
        public void removeMaid(int ID)
        {
            var command = new NpgsqlCommand(String.Format("delete from tblmaid where maid_id = {0}", ID), connection);
            command.ExecuteNonQuery();
            Console.Out.WriteLine("\nQuery executed.\n");
        }
        public void insertTemizlik(int maidID, odaTipi odaTipi)
        {
            var command = new NpgsqlCommand(String.Format("insert into tbltemizlikkayit(maid_id, odatipi, date) values({0}, CAST({1} AS bit), NOW())", maidID, (int)odaTipi), connection);
            command.ExecuteNonQuery();
            Console.Out.WriteLine("\nQuery executed.\n");
        }
    }
}

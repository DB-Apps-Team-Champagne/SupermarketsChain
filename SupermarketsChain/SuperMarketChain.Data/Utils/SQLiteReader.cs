using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketChain.Data.Utils
{
    class SQLiteReader
    {
        static void Main()
        {

            SQLiteConnection m_dbConnection =
                    new SQLiteConnection("Data Source=SQLiteDatabase.sqlite;Version=3;");
            m_dbConnection.Open();



            string taxReader = "select * from taxes order by tax desc";
            SQLiteCommand readCommand = new SQLiteCommand(taxReader, m_dbConnection);
            SQLiteDataReader reader = readCommand.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("Name: " + reader["productName"] + "\tScore: " + reader["tax"] + "%");

            m_dbConnection.Close();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Data.SQLite;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SuperMarketChain.Data;
//using SuperMarketChain.Model;

//namespace SuperMarketChain.SQLite
//{
//    class SQLiteDatabase
//    {
//        static void Main()
//        {
//            SQLiteConnection.CreateFile("SQLiteDatabase.sqlite");
//            SQLiteConnection m_dbConnection = 
//                    new SQLiteConnection("Data Source=SQLiteDatabase.sqlite;Version=3;");
//            m_dbConnection.Open();

//            string sql = "CREATE TABLE taxes (productname NVARCHAR(100), tax INT)";
//            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
//            command.ExecuteNonQuery();

//            var context = new SupermarketChainContext();

//            var products = context.Products.Select(p => p.ProductName).Distinct();


//            var r = new Random();
//            foreach (var item in products)
//            {
//                string prodName = item;
//                string insert = "insert into taxes (productname, tax) values ('" + prodName + "', '" + r.Next(10,30) + "')";
                
//                SQLiteCommand cmd = new SQLiteCommand(insert, m_dbConnection);
//                cmd.ExecuteNonQuery();
//            }

//            string taxReader = "select * from taxes order by tax desc";
//            SQLiteCommand readCommand = new SQLiteCommand(taxReader, m_dbConnection);
//            SQLiteDataReader reader = readCommand.ExecuteReader();
//            while (reader.Read())
//                Console.WriteLine("Name: " + reader["productName"] + "\tScore: " + reader["tax"] +"%");

//            m_dbConnection.Close();
//        }
//    }
//}

using MySql.Data.MySqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace BookvikSupport
{
    public class DataBaseConnector
    {
        public MySqlConnection DbConnection;

        public DataBaseConnector()
        {
            string conn = ConfigurationManager.ConnectionStrings["BookvikDB"].ConnectionString;
            DbConnection = new MySqlConnection(conn);
        }


        public List<BindingModel.Page> GetAllPage(string name)
        {
            DbConnection.Open();
            List<BindingModel.Page> pages = new List<BindingModel.Page>();
            using (MySqlCommand command =
                new MySqlCommand("GetPages", DbConnection) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("@Nam",name);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pages.Add(new BindingModel.Page(0, reader[2].ToString(), reader[0].ToString(),
                            reader[3].ToString(), reader[6].ToString(), reader[5].ToString(), reader[9].ToString(),
                            reader[4].ToString(), reader[8].ToString(),Convert.ToInt32(reader[1])));
                    }
                }
            }
            DbConnection.Close();
            return pages;
        }
        public void InsertNewBook(BindingModel.Book book)
        {
            
                DbConnection.Open();
                using (MySqlCommand command =
                    new MySqlCommand("AddNoteBook", DbConnection) {CommandType = CommandType.StoredProcedure})
                {
                    command.Parameters.AddWithValue("@Nam", book.NameBook);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book.Id = Convert.ToInt32(reader[0]);
                        }
                    }
                }
                DbConnection.Close();
            
        }

        public void ChangeData( BindingModel.Page page)
        {
            DbConnection.Open();
            using (MySqlCommand command = new MySqlCommand("ChangeLink", DbConnection) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("@id", page.BookId);
                command.Parameters.AddWithValue("@Typ", page.Type);
                command.Parameters.AddWithValue("@Model", page.Model);
                command.Parameters.AddWithValue("@Link", page.GameLink1);
                command.ExecuteNonQuery();
            }
            DbConnection.Close();
        }
        public void InsertPagesInBook(BindingModel.Page page)
        {
            DbConnection.Open();
            using (MySqlCommand command = new MySqlCommand("InsertTargetUa", DbConnection) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("@Number", page.Number);
                command.Parameters.AddWithValue("@Name", page.Name);
                command.Parameters.AddWithValue("@Type", page.Type);
                command.Parameters.AddWithValue("@3D", page.Model);
                command.Parameters.AddWithValue("@YT", page.YoutubeLink1);
                command.Parameters.AddWithValue("@YT2", page.YoutubeLink2);
                command.Parameters.AddWithValue("@G", page.GameLink1);
                command.Parameters.AddWithValue("@G2", page.GameLink2);
                command.Parameters.AddWithValue("@AG", page.BookId);
                command.Parameters.AddWithValue("@PinG", page.PlaceInGroup);
                command.ExecuteNonQuery();
            }
            DbConnection.Close();
        }
    }
}

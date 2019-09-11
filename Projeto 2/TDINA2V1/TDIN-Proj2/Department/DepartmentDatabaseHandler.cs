using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

using Common;


namespace Department
{
    public static class DepartmentDatabaseHandler
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Department.Properties.Settings.DepartmentDatabaseConnectionString"].ConnectionString;


        public static bool ClearDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                try
                {
                    command.CommandText = "DELETE FROM [Questions]";
                    command.ExecuteNonQuery();
                    command.CommandText = "DBCC CHECKIDENT([Questions], RESEED)";
                    command.ExecuteNonQuery();

                    Console.WriteLine("Databased cleaned");
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: Cleaning Database");
                    return false;
                }
            }
        }



        //##################  Questions  ##################
        public static bool AddQuestion(string title, string quesiton, int serverQuestionId, int ticketId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("AddQuestionTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [Questions] values (@Title, @Question, @ServerQuestion_Id, @Ticket_Id)";
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Question", quesiton);
                command.Parameters.AddWithValue("@ServerQuestion_Id", serverQuestionId);
                command.Parameters.AddWithValue("@Ticket_Id", ticketId);

                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Questions: Registered new Question (" + title + " - TickedID " + ticketId + ")");
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: AddQuestion - Inserting into database");
                    return false;
                }
            }
        }

        public static bool IsAllQuestionsAnswered(int ticketId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Questions] WHERE Ticket_Id = @ticketid";
                command.Parameters.AddWithValue("@ticketid", ticketId);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        return false;
                    }
                    else return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: Verifying Questions existence - Reading from database");
                    return false;
                }
            }
        }

        public static bool RemoveQuestion(int questionID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                command.CommandText = "DELETE FROM [Questions] WHERE Id = @id";
                command.Parameters.AddWithValue("@id", questionID);

                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Questions: Removed Question with id " + questionID);
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: Removing Question with id "+questionID);
                    return false;
                }
            }
        }


        public static DepartmentQuestion GetQuestion(int id)
        {
            DepartmentQuestion question = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Questions] WHERE Id = @id";
                command.Parameters.Add(new SqlParameter("@id", id));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                        question = new DepartmentQuestion((int)reader["Id"],
                                                reader["Title"].ToString(),
                                                reader["Question"].ToString(),
                                                (int)reader["ServerQuestion_Id"],
                                                (int)reader["Ticket_Id"]);

                    reader.Close();
                    return question;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetQuestion - Reading from database");
                    return null;
                }
            }
        }


        public static List<DepartmentQuestion> GetAllQuestions(int ticketID)
        {
            List<DepartmentQuestion> quesitonsList = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Questions] WHERE Ticket_Id = @ticketid";
                command.Parameters.Add(new SqlParameter("@ticketid", ticketID));
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (quesitonsList == null)
                            quesitonsList = new List<DepartmentQuestion>();
                        quesitonsList.Add(new DepartmentQuestion(
                                                (int)reader["Id"],
                                                reader["Title"].ToString(),
                                                reader["Question"].ToString(),
                                                (int)reader["ServerQuestion_Id"],
                                                (int)reader["Ticket_Id"]));
                    }
                    reader.Close();
                    return quesitonsList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetAllQuestions filtered by ticketid - Reading from database");
                    return null;
                }
            }
        }

        public static List<DepartmentQuestion> GetAllQuestions()
        {
            List<DepartmentQuestion> quesitonsList = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Questions]";
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (quesitonsList == null)
                            quesitonsList = new List<DepartmentQuestion>();
                        quesitonsList.Add(new DepartmentQuestion(
                                                (int)reader["Id"],
                                                reader["Title"].ToString(),
                                                reader["Question"].ToString(),
                                                (int)reader["ServerQuestion_Id"],
                                                (int)reader["Ticket_Id"]));
                    }
                    reader.Close();
                    return quesitonsList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetAllQuestions - Reading from database");
                    return null;
                }
            }


        }

    }
}

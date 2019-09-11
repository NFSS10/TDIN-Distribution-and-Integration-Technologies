using System;
using System.Data.SqlClient;
using System.Collections.Generic;

using Common;


namespace webServer
{
    public static class ServerDatabaseHandler
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ServerDatabase.mdf;Integrated Security = True";



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
                    command.CommandText = "DBCC CHECKIDENT([Questions], RESEED, 0)";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM [TroubleTickets]";
                    command.ExecuteNonQuery();
                    command.CommandText = "DBCC CHECKIDENT([TroubleTickets], RESEED, 0)";
                    command.ExecuteNonQuery();


                    command.CommandText = "DELETE FROM [Workers]";
                    command.ExecuteNonQuery();
                    command.CommandText = "DBCC CHECKIDENT([Workers], RESEED, 0)";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM [Solvers]";
                    command.ExecuteNonQuery();
                    command.CommandText = "DBCC CHECKIDENT([Solvers], RESEED, 0)";
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



        //##################  Workers  ##################
        public static bool IsWorkerRegistered(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Workers] WHERE Email = @email";
                command.Parameters.Add(new SqlParameter("@email", email));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        return true;
                    }
                    else return false;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: Verifying Worker existence - Reading from database");
                    return true;
                }
            }
        }

        public static bool AddWorker(string name, string email)
        {
            if (IsWorkerRegistered(email))
                return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Add_Worker_Transaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [Workers] values (@Name, @Email)";
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Worker: Registered new worker ("+name + " - " +email+")");
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: AddWorker - Inserting into database");
                    return false;
                }
            }
        }

        public static Worker GetWorker(int id)
        {
            Worker worker = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Workers] WHERE Id = @id";
                command.Parameters.Add(new SqlParameter("@id", id));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                        worker = new Worker((int)reader["Id"], reader["Email"].ToString(), reader["Name"].ToString());

                    reader.Close();
                    return worker;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetWorker - Reading from database");
                    return null;
                }
            }
        }

        public static Worker GetWorker(string email)
        {
            Worker worker = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Workers] WHERE Email = @email";
                command.Parameters.Add(new SqlParameter("@email", email));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                        worker = new Worker((int)reader["Id"], reader["Email"].ToString(), reader["Name"].ToString());

                    reader.Close();
                    return worker;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetWorker - Reading from database");
                    return null;
                }
            }
        }

        public static List<Worker> GetAllWorkers()
        {
            List<Worker> workersList = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Workers]";

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (workersList == null)
                            workersList = new List<Worker>();
                        workersList.Add(new Worker((int)reader["Id"], reader["Email"].ToString(), reader["Name"].ToString()));

                    }
                    reader.Close();
                    return workersList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetAllWorker - Reading from database");
                    return null;
                }
            }
        }

        //##################  Tickets  ##################
        public static bool CreateTroubleTicket(string title, string description, int workerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Create_TroubleTicket_Transaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [TroubleTickets] (Title, Description, CreationDate, State, Answer, Worker_Id) values (@Title, @Description, @CreationDate, @State, @Answer, @Worker_Id)";
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                command.Parameters.AddWithValue("@CreationDate", sqlFormattedDate);
                command.Parameters.AddWithValue("@State", (int)TicketState.UNASSIGNED);
                command.Parameters.AddWithValue("@Answer", "");
                command.Parameters.AddWithValue("@Worker_Id", workerId);

                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Tickets: Created a new ticked (" + title + " - " + description + " workerID: "+ workerId+" )");
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    transaction.Rollback();
                    Console.WriteLine("ERROR: CreateTroubleTicket - Inserting into database");
                    return false;
                }
            }
        }

        public static bool AssignTroubleTicket(int ticketID, int solverID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("AssignTroubleTicketTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "UPDATE [TroubleTickets] SET Solver_Id = @solverID, State = @newState WHERE Id = @id";
                command.Parameters.AddWithValue("@solverID", solverID);
                command.Parameters.AddWithValue("@newState", (int)TicketState.ASSIGNED);
                command.Parameters.AddWithValue("@id", ticketID);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Tickets: Ticket assigned to Solver " + solverID);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: Assigning ticket to Solver " + solverID);
                    return false;
                }
            }
        }

        public static bool UpdateTroubleTicketState(int tickedID, TicketState newTicketState)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("UpdateTicketStateTrans");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "UPDATE [TroubleTickets] SET State = @newState WHERE Id = @id";
                command.Parameters.AddWithValue("@newState", (int)newTicketState);
                command.Parameters.AddWithValue("@id", tickedID);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Tickets: Ticket state changed to " + newTicketState);
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: Changing ticket state");
                    return false;
                }
            }
        }

        public static bool SolveTroubleTicket(int tickedID, string answer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("SolveTicketTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "UPDATE [TroubleTickets] SET Answer = @answer, State = @newState WHERE Id = @id";
                command.Parameters.AddWithValue("@answer", answer);
                command.Parameters.AddWithValue("@newState", (int)TicketState.SOLVED);
                command.Parameters.AddWithValue("@id", tickedID);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Tickets: Ticket solved (TicketID = " + tickedID+")");
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: Solving ticket" + tickedID);
                    return false;
                }
            }
        }

        public static List<Ticket> GetAllUnassignedTroubleTickets()
        {
            List<Ticket> ticketsList = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [TroubleTickets] WHERE State = @state";
                command.Parameters.Add(new SqlParameter("@state", (int)TicketState.UNASSIGNED));
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (ticketsList == null)
                            ticketsList = new List<Ticket>();
                        ticketsList.Add(new Ticket(
                                                (int)reader["Id"],
                                                reader["Title"].ToString(),
                                                reader["Description"].ToString(),
                                                reader["CreationDate"].ToString(),
                                                (TicketState)reader["State"],
                                                reader["Answer"].ToString(),
                                                (reader["Worker_Id"] as int?) ?? -1,
                                                (reader["Solver_Id"] as int?) ?? -1)
                                        );
                    }
                    reader.Close();
                    return ticketsList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetAllUnassignedTroubleTickets - Reading from database");
                    return null;
                }
            }
        }

        public static List<Ticket> GetSolverAssignedTroubleTickets(int solverID)
        {
            List<Ticket> ticketsList = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [TroubleTickets] WHERE Solver_Id = @solverid AND State != @state";
                command.Parameters.Add(new SqlParameter("@solverid", solverID));
                command.Parameters.Add(new SqlParameter("@state", (int)TicketState.SOLVED));
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (ticketsList == null)
                            ticketsList = new List<Ticket>();
                        ticketsList.Add(new Ticket(
                                                (int)reader["Id"],
                                                reader["Title"].ToString(),
                                                reader["Description"].ToString(),
                                                reader["CreationDate"].ToString(),
                                                (TicketState)reader["State"],
                                                reader["Answer"].ToString(),
                                                (reader["Worker_Id"] as int?) ?? -1,
                                                (reader["Solver_Id"] as int?) ?? -1)
                                        );
                    }
                    reader.Close();
                    return ticketsList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetSolverAssignedTroubleTickets - Reading from database");
                    return null;
                }
            }
        }

        public static List<Ticket> GetWorkerTroubleTickets(int workerID)
        {
            List<Ticket> ticketsList = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [TroubleTickets] WHERE Worker_Id = @workerid";
                command.Parameters.Add(new SqlParameter("@workerid", workerID));
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (ticketsList == null)
                            ticketsList = new List<Ticket>();
                        ticketsList.Add(new Ticket(
                                                (int)reader["Id"],
                                                reader["Title"].ToString(),
                                                reader["Description"].ToString(),
                                                reader["CreationDate"].ToString(),
                                                (TicketState)reader["State"],
                                                reader["Answer"].ToString(),
                                                (reader["Worker_Id"] as int?) ?? -1,
                                                (reader["Solver_Id"] as int?) ?? -1)
                                        );
                    }
                    reader.Close();
                    return ticketsList;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetWorkerTroubleTickets - Reading from database");
                    return null;
                }
            }
        }

        public static Ticket GetTroubleTicket(int ticketID)
        {
            Ticket ticket = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [TroubleTickets] WHERE Id = @id";
                command.Parameters.Add(new SqlParameter("@id", ticketID));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                        ticket = new Ticket(
                            (int)reader["Id"], 
                            reader["Title"].ToString(), 
                            reader["Description"].ToString(),
                            reader["CreationDate"].ToString(), 
                            (TicketState)reader["State"], 
                            reader["Answer"].ToString(),
                            (reader["Worker_Id"] as int?) ?? -1,
                            (reader["Solver_Id"] as int?) ?? -1);

                    reader.Close();
                    return ticket;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetTroubleTicket - Reading from database");
                    return null;
                }
            }
        }


        //##################  Solvers  ##################
        public static bool IsSolverRegistered(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Solvers] WHERE Username = @username";
                command.Parameters.Add(new SqlParameter("@username", username));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        return true;
                    }
                    else return false;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: Verifying Solver existence - Reading from database");
                    return true;
                }
            }
        }

        public static bool AddSolver(string name, string username, string password)
        {
            if (IsSolverRegistered(username))
                return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("Add_Solver_Transaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [Solvers] values (@Username, @Name, @Password)";
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Solver: Registered new Solver (" + username + " - " + name + ")");
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: AddSolver - Inserting into database");
                    return false;
                }
            }
        }

        public static Solver GetSolver(int id)
        {
            Solver solver = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Solvers] WHERE Id = @id";
                command.Parameters.Add(new SqlParameter("@id", id));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                        solver = new Solver((int)reader["Id"], reader["Username"].ToString(), reader["Name"].ToString());

                    reader.Close();
                    return solver;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetSolver - Reading from database");
                    return null;
                }
            }
        }


        public static Solver GetSolver(string username)
        {
            Solver solver = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Solvers] WHERE Username = @username";
                command.Parameters.Add(new SqlParameter("@username", username));

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                        solver = new Solver((int)reader["Id"], reader["Username"].ToString(), reader["Name"].ToString());

                    reader.Close();
                    return solver;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetSolver - Reading from database");
                    return null;
                }
            }
        }
        public static Solver GetSolver(string username, string password)
        {
            Solver solver = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [Solvers] WHERE Username = @username AND Password = @password";
                command.Parameters.Add(new SqlParameter("@username", username));
                command.Parameters.Add(new SqlParameter("@password", password));
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                        solver = new Solver((int)reader["Id"], reader["Username"].ToString(), reader["Name"].ToString());

                    reader.Close();
                    return solver;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: GetSolver - Reading from database");
                    return null;
                }
            }
        }



        //##################  Questions  ##################
        public static int AddQuestion(string title, string description, int departmentId, int ticketId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("AddQuestionTransaction");
                command.Connection = connection;
                command.Transaction = transaction;


                command.CommandText = "INSERT INTO [Questions] OUTPUT INSERTED.Id values (@Title, @Description, @Answer, @IsAnswered, @Department_Id, @Ticket_Id)";
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Answer", "");
                command.Parameters.AddWithValue("@IsAnswered", false);
                command.Parameters.AddWithValue("@Department_Id", departmentId);
                command.Parameters.AddWithValue("@Ticket_Id", ticketId);

                try
                {
                    Int32 orderID = (Int32)command.ExecuteScalar();
                    transaction.Commit();
                    Console.WriteLine("Worker: Registered new Question (" + title + " - TickedID" + ticketId + ")");
                    return orderID;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: AddQuestion - Inserting into database");
                    return -1;
                }
            }
        }

        public static bool AnswerQuestion(int questionID, string departmentAnswer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                SqlTransaction transaction = connection.BeginTransaction("AnswerQuestion");
                command.Connection = connection;
                command.Transaction = transaction;

                command.CommandText = "UPDATE [Questions] SET Answer = @answer, IsAnswered = @newState WHERE Id = @id";
                command.Parameters.AddWithValue("@answer", departmentAnswer);
                command.Parameters.AddWithValue("@newState", true);
                command.Parameters.AddWithValue("@id", questionID);

                try
                {
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Console.WriteLine("Questions: Question " + questionID + " answered");
                    return true;
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    Console.WriteLine("ERROR: Answering question "+ questionID);
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
                command.CommandText = "SELECT * FROM [Questions] WHERE Ticket_Id = @ticketid AND IsAnswered = @answerState";
                command.Parameters.AddWithValue("@ticketid", ticketId);
                command.Parameters.AddWithValue("@answerState", false);

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
                    Console.WriteLine("ERROR: Verifying Worker existence - Reading from database");
                    return false;
                }
            }
        }

        //Only removes if all questions are answered
        public static bool RemoveAllQuestions(int ticketId)
        {
            if (!IsAllQuestionsAnswered(ticketId))
                return false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                command.CommandText = "DELETE FROM [Questions] WHERE Ticket_Id = @ticketid";
                command.Parameters.AddWithValue("@ticketid", ticketId);

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ERROR: Removing Questions");
                    return false;
                }
            }
        }

        public static List<Question> GetAllQuestions(int ticketID)
        {
            List<Question> quesitonsList = null;

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
                            quesitonsList = new List<Question>();
                        quesitonsList.Add(new Question(
                                                (int)reader["Id"],
                                                reader["Title"].ToString(),
                                                reader["Description"].ToString(),
                                                reader["Answer"].ToString(),
                                                (bool)reader["IsAnswered"],
                                                (reader["Department_Id"] as int?) ?? -1,
                                                (reader["Ticket_Id"] as int?) ?? -1));
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
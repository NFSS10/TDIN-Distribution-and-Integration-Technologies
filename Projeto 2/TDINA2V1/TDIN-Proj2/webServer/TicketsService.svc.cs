using Common;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using webServer.QueueService;

namespace webServer
{
    public class TicketsService : ITicketsService
    {
        QueueServiceClient queueService = new QueueServiceClient();


        public string HelloWorld()
        {
            return "Olá, Mundo";
        }

        public string Test(string texto)
        {
            return "(Envias-te o texto: " + texto + ")";
        }



        public bool AddTicket(string title, string description, int author_id)
        {
            if (ServerDatabaseHandler.CreateTroubleTicket(title, description, author_id))
                return true;
            else
                return false;

        }

   
        public Ticket[] GetUnassignedTickets()
        {
            List<Ticket> uTickets;
            if ((uTickets = ServerDatabaseHandler.GetAllUnassignedTroubleTickets()) != null)
                return uTickets.ToArray();
            else
                return null;
        }

        public void SendQuestionToDepartment(string title, string question, int questionID, int ticketID)
        {
            queueService.ProcessQuestion(title, question, questionID, ticketID);
        }


        public bool AssignTicketToSolver(int ticketId, int solverId)
        {
            bool result = ServerDatabaseHandler.AssignTroubleTicket(ticketId, solverId);
            return result;
        }

        public Solver Login(string username, string password)
        {
            Solver solver = ServerDatabaseHandler.GetSolver(username, password);
            return solver;
        }

        public bool Register(string name, string username, string password)
        {
            if (!ServerDatabaseHandler.IsSolverRegistered(username))
            {
                return ServerDatabaseHandler.AddSolver(name, username, password);
            }
            else
                return false;
        }

        public Ticket[] GetAssignedTickets(int solverId)
        {
            List<Ticket> aTickets;
            if ((aTickets = ServerDatabaseHandler.GetSolverAssignedTroubleTickets(solverId)) != null)
                return aTickets.ToArray();
            else
                return null;
        }

        public bool SolveTicket(int ticketId, string solverName, string ticketTitle, string finalAnswer,string authorEmail)
        {
            string emailTitle = "Ticket - #" + ticketId + " " + ticketTitle + " SOLVED";
            Ticket ticket = ServerDatabaseHandler.GetTroubleTicket(ticketId);
            string emailMessage = "Your ticket: #" + ticketId + " - " + ticketTitle + "\nWith the problem description:\n"+ ticket.description 
                + "\n\nWas solved! The solver, "+solverName+", left this final answer:\n\n" + finalAnswer;
            if (ServerDatabaseHandler.SolveTroubleTicket(ticketId, finalAnswer))
            {
                if (ServerDatabaseHandler.RemoveAllQuestions(ticketId))
                {
                    SendEmail(authorEmail, emailTitle, emailMessage);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            
        }

        public Ticket GetTicket(int ticketId)
        {
            Ticket ticket;
            if ((ticket = ServerDatabaseHandler.GetTroubleTicket(ticketId)) != null)
                return ticket;
            else
                return null;
        }

        public Question[] GetTicketQuestions(int ticketId)
        {
            List<Question> ticketQuestions;
            if ((ticketQuestions = ServerDatabaseHandler.GetAllQuestions(ticketId)) != null)
                return ticketQuestions.ToArray();
            else
                return null;
        }

        public bool CanCloseTicket(int ticketId)
        {
            return ServerDatabaseHandler.IsAllQuestionsAnswered(ticketId);
        }

        public int AddQuestion(string title, string description, int departmentId, int ticketId)
        {
            return ServerDatabaseHandler.AddQuestion(title, description, departmentId, ticketId);
        }

        public bool UpdateTicketState(int ticketId, TicketState newState)
        {
            return ServerDatabaseHandler.UpdateTroubleTicketState(ticketId, newState);
        }

        public Worker GetAuthorInfo(int authorId)
        {
            return ServerDatabaseHandler.GetWorker(authorId);
        }

        public bool DeleteTicketQuestions(int ticketId)
        {
            return ServerDatabaseHandler.RemoveAllQuestions(ticketId);
        }

        public bool AnswerQuestion(int questionID, string answer)
        {
            return ServerDatabaseHandler.AnswerQuestion(questionID, answer);
        }

        //Returns -1 if error, else returns id of worker
        public int AddWorker(string name, string email)
        {
            if (ServerDatabaseHandler.IsWorkerRegistered(email))
            {
                Worker worker = ServerDatabaseHandler.GetWorker(email);
                if (worker == null)
                    return -1;
                else return worker.id;
            }

            if (ServerDatabaseHandler.AddWorker(name, email))
            {
                Worker worker = ServerDatabaseHandler.GetWorker(email);
                if (worker == null)
                    return -1;
                else return worker.id;
            }
            else return -1;
        }


        public void SendEmail(string emailTo, string title, string message)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("tdin.test.email@gmail.com", "123@tdinpassword");

            MailMessage mm = new MailMessage("donotreply@tdinsolver.com",
                emailTo,
                title,
                message);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
        }




        //Testes
        public string DebugTests()
        {
            string msg = "<br>------------------ Debug: ------------------<br>";
            msg += "Testes:<br><br>";

            if(ServerDatabaseHandler.ClearDatabase())
                msg += "BD limpa<br><br>";
            else msg += "ERRO a limpar BD<br><br>";



            //##################  Workers  ##################
            msg += "<br>##################  Workers  ##################<br>";
            if (!ServerDatabaseHandler.IsWorkerRegistered("up201404380@fe.up.pt"))
                msg += "1: OK<br>";
            else
                msg += "1: ERROR<br>";

            if (ServerDatabaseHandler.AddWorker("Nuno", "up201404380@fe.up.pt"))
                msg += "2: OK<br>";
            else
                msg += "2: ERROR<br>";
            
            if (ServerDatabaseHandler.GetWorker(1).name == "Nuno" && ServerDatabaseHandler.GetWorker("up201404380@fe.up.pt").email == "up201404380@fe.up.pt")
                msg += "3: OK<br>";
            else
                msg += "3: ERROR<br>";

            if (ServerDatabaseHandler.AddWorker("Nuno test2", "up201404381@fe.up.pt"))
                msg += "4: OK<br>";
            else
                msg += "4: ERROR<br>";

            if (ServerDatabaseHandler.GetWorker(2).name == "Nuno test2" && ServerDatabaseHandler.GetWorker("up201404381@fe.up.pt").email == "up201404381@fe.up.pt")
                msg += "5: OK<br>";
            else
                msg += "5: ERROR<br>";


            //##################  Solvers  ##################
            msg += "<br>##################  Solvers  ##################<br>";
            if (!ServerDatabaseHandler.IsSolverRegistered("solver1 Username"))
                msg += "1: OK<br>";
            else
                msg += "1: ERROR<br>";

            if (ServerDatabaseHandler.AddSolver("Solver1 Name", "solver1 Username", "pass123"))
                msg += "2: OK<br>";
            else
                msg += "2: ERROR<br>";

            if (ServerDatabaseHandler.GetSolver(1).name == "Solver1 Name" && ServerDatabaseHandler.GetSolver("solver1 Username").username == "solver1 Username")
                msg += "3: OK<br>";
            else
                msg += "3: ERROR<br>";

            if (ServerDatabaseHandler.AddSolver("Solver2 Name", "solver2 Username", "pass123"))
                msg += "4: OK<br>";
            else
                msg += "4: ERROR<br>";

            if (ServerDatabaseHandler.GetSolver(2).username == "solver2 Username" && ServerDatabaseHandler.GetSolver("solver2 Username").name == "Solver2 Name")
                msg += "5: OK<br>";
            else
                msg += "5: ERROR<br>";


            //##################  Tickets  ##################
            msg += "<br>##################  Tickets  ##################<br>";
            if (ServerDatabaseHandler.CreateTroubleTicket("Titulo do ticket 1", "descricao do problema do ticket 1", 1))
                msg += "1: OK<br>";
            else
                msg += "1: ERROR<br>";

            if (ServerDatabaseHandler.GetTroubleTicket(1).solverId == -1 && ServerDatabaseHandler.GetTroubleTicket(1).workerId == 1 
                && ServerDatabaseHandler.GetTroubleTicket(1).state == TicketState.UNASSIGNED 
                && ServerDatabaseHandler.GetTroubleTicket(1).title == "Titulo do ticket 1"
                && ServerDatabaseHandler.GetTroubleTicket(1).answer == ""
                && ServerDatabaseHandler.GetTroubleTicket(1).description == "descricao do problema do ticket 1")
                msg += "2: OK<br>";
            else
                msg += "2: ERROR<br>";

            if (ServerDatabaseHandler.UpdateTroubleTicketState(1,TicketState.ASSIGNED))
                msg += "3: OK<br>";
            else
                msg += "3: ERROR<br>";

            if (ServerDatabaseHandler.GetTroubleTicket(1).state == TicketState.ASSIGNED)
                msg += "4: OK<br>";
            else
                msg += "4: ERROR<br>";

            if (ServerDatabaseHandler.UpdateTroubleTicketState(1, TicketState.SOLVED))
                msg += "5: OK<br>";
            else
                msg += "5: ERROR<br>";

            if (ServerDatabaseHandler.GetTroubleTicket(1).state == TicketState.SOLVED)
                msg += "6: OK<br>";
            else
                msg += "6: ERROR<br>";

            if (ServerDatabaseHandler.UpdateTroubleTicketState(1, TicketState.WAITING_FOR_ANSWERS))
                msg += "7: OK<br>";
            else
                msg += "7: ERROR<br>";

            if (ServerDatabaseHandler.GetTroubleTicket(1).state == TicketState.WAITING_FOR_ANSWERS)
                msg += "8: OK<br>";
            else
                msg += "8: ERROR<br>";

            if (ServerDatabaseHandler.UpdateTroubleTicketState(1, TicketState.UNASSIGNED))
                msg += "9: OK<br>";
            else
                msg += "9: ERROR<br>";

            if (ServerDatabaseHandler.GetTroubleTicket(1).state == TicketState.UNASSIGNED)
                msg += "10: OK<br>";
            else
                msg += "10: ERROR<br>";

            if (ServerDatabaseHandler.AssignTroubleTicket(1, 1))
                msg += "11: OK<br>";
            else
                msg += "11: ERROR<br>";

            if (ServerDatabaseHandler.GetTroubleTicket(1).state == TicketState.ASSIGNED && ServerDatabaseHandler.GetTroubleTicket(1).solverId == 1)
                msg += "12: OK<br>";
            else
                msg += "12: ERROR<br>";

            if(ServerDatabaseHandler.GetSolverAssignedTroubleTickets(1).Count == 1 && ServerDatabaseHandler.GetSolverAssignedTroubleTickets(1)[0].title == "Titulo do ticket 1")
                msg += "13: OK<br>";
            else
                msg += "13: ERROR<br>";

            if (ServerDatabaseHandler.GetAllUnassignedTroubleTickets() == null)
                msg += "14: OK<br>";
            else
                msg += "14: ERROR<br>";

            if (ServerDatabaseHandler.CreateTroubleTicket("T2", "des2", 1) && ServerDatabaseHandler.CreateTroubleTicket("T3", "des3", 1))
                msg += "15: OK<br>";
            else
                msg += "15: ERROR<br>";

            if (ServerDatabaseHandler.GetAllUnassignedTroubleTickets().Count == 2 && ServerDatabaseHandler.GetAllUnassignedTroubleTickets()[1].title == "T3")
                msg += "16: OK<br>";
            else
                msg += "16: ERROR<br>";

            if (ServerDatabaseHandler.GetWorkerTroubleTickets(2)==null
                && ServerDatabaseHandler.GetWorkerTroubleTickets(1).Count == 3
                && ServerDatabaseHandler.GetWorkerTroubleTickets(1)[1].title == "T2")
                msg += "17: OK<br>";
            else
                msg += "17: ERROR<br>";

            if(ServerDatabaseHandler.SolveTroubleTicket(1, "resposta final dada"))
                msg += "18: OK<br>";
            else
                msg += "18: ERROR<br>";

            if (ServerDatabaseHandler.GetTroubleTicket(1).answer == "resposta final dada" && ServerDatabaseHandler.GetTroubleTicket(1).state == TicketState.SOLVED)
                msg += "19: OK<br>";
            else
                msg += "19: ERROR<br>";
            

            //##################  Questions  ##################
            msg += "<br>##################  Questions  ##################<br>";
            if (ServerDatabaseHandler.AddQuestion("T1","des1",1,1) != -1 && ServerDatabaseHandler.AddQuestion("T2", "des2", 1, 1) != -1)
                msg += "1: OK<br>";
            else
                msg += "1: ERROR<br>";

            if (ServerDatabaseHandler.GetAllQuestions(1).Count == 2
                && ServerDatabaseHandler.GetAllQuestions(1)[1].title == "T2"
                && ServerDatabaseHandler.GetAllQuestions(1)[1].isAnswered == false)
                msg += "2: OK<br>";
            else
                msg += "2: ERROR<br>";

            if (!ServerDatabaseHandler.IsAllQuestionsAnswered(1))
                msg += "3: OK<br>";
            else
                msg += "3: ERROR<br>";

            if (ServerDatabaseHandler.AnswerQuestion(1, "res1"))
                msg += "4: OK<br>";
            else
                msg += "4: ERROR<br>";

            if (ServerDatabaseHandler.GetAllQuestions(1)[0].isAnswered == true && ServerDatabaseHandler.GetAllQuestions(1)[0].answer == "res1")
                msg += "5: OK<br>";
            else
                msg += "5: ERROR<br>";

            if (!ServerDatabaseHandler.RemoveAllQuestions(1))
                msg += "6: OK<br>";
            else
                msg += "6: ERROR<br>";
            
            if (ServerDatabaseHandler.AnswerQuestion(2, "res2")) //todas as questoes do ticket 1 estao respondidas a partir daqui
                msg += "7: OK<br>";
            else
                msg += "7: ERROR<br>";

            if (ServerDatabaseHandler.IsAllQuestionsAnswered(1))
                msg += "8: OK<br>";
            else
                msg += "8: ERROR<br>";

            if (ServerDatabaseHandler.RemoveAllQuestions(1))
                msg += "9: OK<br>";
            else
                msg += "9: ERROR<br>";

            if(ServerDatabaseHandler.GetAllQuestions(1) == null)
                msg += "10: OK<br>";
            else
                msg += "10: ERROR<br>";


            return msg;
        }

        public List<Worker> GetAllWorkers()
        {
            return ServerDatabaseHandler.GetAllWorkers();
        }

        public List<Ticket> GetWorkerTroubleTickets(int workerID)
        {
            return ServerDatabaseHandler.GetWorkerTroubleTickets(workerID);
        }

        public void ClearServerDatabase()
        {
            ServerDatabaseHandler.ClearDatabase();
        }
    }








}

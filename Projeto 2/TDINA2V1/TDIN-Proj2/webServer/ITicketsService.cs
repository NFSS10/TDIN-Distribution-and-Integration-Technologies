using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Common;

namespace webServer
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "ITicketsService" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface ITicketsService
    {
        [OperationContract]
        string HelloWorld();

        [OperationContract]
        string Test(string texto);

        [OperationContract]
        string DebugTests();

        [OperationContract]
        bool AddTicket(string title, string description, int author_id);

        
        [OperationContract(IsOneWay = true)]
        void SendQuestionToDepartment(string title, string question, int questionID, int ticketID);

        [OperationContract]
        Ticket[] GetUnassignedTickets();

        [OperationContract]
        bool AssignTicketToSolver(int ticketId, int solverId);

        [OperationContract]
        Solver Login(string email, string password);

        [OperationContract]
        bool Register(string name, string username, string password);

        [OperationContract]
        Ticket[] GetAssignedTickets(int solverId);

        [OperationContract]
        Ticket GetTicket(int ticketId);

        [OperationContract]
        int AddQuestion(string title, string description, int departmentId, int ticketId);

        [OperationContract]
        bool UpdateTicketState(int ticketId, TicketState newState);

        [OperationContract]
        Worker GetAuthorInfo(int authorId);

        [OperationContract]
        Question[] GetTicketQuestions(int ticketId);

        [OperationContract]
        bool CanCloseTicket(int ticketId);

        [OperationContract]
        bool DeleteTicketQuestions(int ticketId);

        [OperationContract]
        bool AnswerQuestion(int questionID, string answer);

        [OperationContract]
        int AddWorker(string name, string email);

        [OperationContract]
        List<Worker> GetAllWorkers();

        [OperationContract]
        List<Ticket> GetWorkerTroubleTickets(int workerID);

        [OperationContract]
        void SendEmail(string emailTo, string title, string message);

        [OperationContract]
        bool SolveTicket(int ticketId, string solverName, string ticketTitle, string finalAnswer, string authorEmail);

        [OperationContract]
        void ClearServerDatabase();

    }
}

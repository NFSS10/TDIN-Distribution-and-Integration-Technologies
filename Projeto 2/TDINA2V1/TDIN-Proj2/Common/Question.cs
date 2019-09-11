
using System;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    public class Question
    {
        [DataMember]
        public int id { get; }

        [DataMember]
        public string title { get; }

        [DataMember]
        public string description { get; }

        [DataMember]
        public string answer { get; }

        [DataMember]
        public bool isAnswered { get; }

        [DataMember]
        public int departmentId { get; }

        [DataMember]
        public int ticketId { get; }


        public Question(int id, string title, string description, string answer, bool isAnswered, int departmentId, int ticketId)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.answer = answer;
            this.isAnswered = isAnswered;
            this.departmentId = departmentId;
            this.ticketId = ticketId;
        }

    }




    public class DepartmentQuestion
    {
        public int id { get; }
        public string title { get; }
        public string question { get; }
        public int serverQuestionId { get; }
        public int ticketId { get; }


        public DepartmentQuestion(int id, string title, string question, int serverQuestionId, int ticketId)
        {
            this.id = id;
            this.title = title;
            this.question = question;
            this.serverQuestionId = serverQuestionId;
            this.ticketId = ticketId;
        }

        public override string ToString()
        {
            return title;
        }

    }







}

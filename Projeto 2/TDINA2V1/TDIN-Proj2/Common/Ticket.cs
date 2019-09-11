
using System;
using System.Runtime.Serialization;

namespace Common
{
    public enum TicketState { UNASSIGNED=1 , ASSIGNED=2 , WAITING_FOR_ANSWERS=3, SOLVED = 4 }

    [Serializable]
    public class Ticket
    {
        [DataMember]
        public int id { get; }
        [DataMember]
        public string title { get; }
        [DataMember]
        public string description { get; }
        [DataMember]
        public string date { get; }
        [DataMember]
        public TicketState state { get; }
        [DataMember]
        public string answer { get; }
        [DataMember]
        public int workerId { get; }
        [DataMember]
        public int solverId { get; }


        public Ticket(int id, string title, string description, string date, TicketState state, string answer, int workerId, int solverId)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.date = date;
            this.state = state;
            this.answer = answer;
            this.workerId = workerId;
            this.solverId = solverId;
        }


        public override string ToString()
        {
            return state.ToString() + " - " + title;
        }

    }


}

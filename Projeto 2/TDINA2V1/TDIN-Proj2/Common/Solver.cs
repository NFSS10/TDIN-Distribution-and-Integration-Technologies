
using System;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    public class Solver
    {
        [DataMember]
        public int id { get; }
        [DataMember]
        public string username { get; }
        [DataMember]
        public string name { get; }


        public Solver(int id, string username, string name)
        {
            this.id = id;
            this.username = username;
            this.name = name;
        }

    }





}

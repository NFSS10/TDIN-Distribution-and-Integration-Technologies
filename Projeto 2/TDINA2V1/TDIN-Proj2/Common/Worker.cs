
using System;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    public class Worker
    {
        [DataMember]
        public int id { get; }
        [DataMember]
        public string email { get; }
        [DataMember]
        public string name { get; }


        public Worker(int id, string email, string name)
        {
            this.id = id;
            this.email = email;
            this.name = name;
        }


        public override string ToString()
        {
            return name + " - "+email;
        }
    }





}

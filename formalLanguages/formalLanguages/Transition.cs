using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace formalLanguages
{
    [DataContract]
    class Transition
    {
        public Transition()
        {

        }
        [DataMember]
        public int Previous { get; set; }
        [DataMember]
        public int Next { get; set; }
        [DataMember]
        public string Condition { get; set; }
        public Transition(int previus,int next, string condition)
        {
            this.Condition = condition;
            this.Next = next;
            this.Previous = previus;

        }
    }
}

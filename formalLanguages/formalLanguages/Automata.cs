using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace formalLanguages
{
    [DataContract]
    class Automata
    {
        public Automata()
        {
            Transitions = new List<Transition>();
            FinalStates = new List<int>();
    }
        [DataMember]
        public List<Transition> Transitions { get; set; }
        [DataMember]
        public string LexemeName { get; set; }
        [DataMember]
        public int StartState { get; set; }
        [DataMember]

        public List<int> FinalStates { get; set; }
        [DataMember]
        public int Priority { get; set; }
        
    }
}

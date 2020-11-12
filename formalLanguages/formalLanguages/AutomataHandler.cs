
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace formalLanguages
{
    class AutomataHandler
    {
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Automata));
        private List<Automata> lexemes;
        public AutomataHandler()
        {
            lexemes = new List<Automata>();
            string[] filePaths = Directory.GetFiles(@"..\\..\\..\\Automata");
            foreach (string item in filePaths)
            {
                using (var file = new FileStream(item,FileMode.Open))
                {
                    lexemes.Add((Automata)jsonFormatter.ReadObject(file));
                }
            }
            lexemes = lexemes.OrderBy(x => x.Priority).ToList();
        }
        public Tuple<bool, int> CheckThroughAnLexema(Automata lexema, int skip, string line)
        {
            int iterator = skip;
            int currentState = lexema.StartState;
            bool k = true;
            while (k)
            {
                if (iterator == line.Length)
                {
                    k = false;
                    break;
                }
                Transition transition = lexema.Transitions.Find(x => x.Previous == currentState && x.Condition.Contains(line[iterator]));
                if (transition == null)
                {
                    k = false;
                }
                else
                {
                    iterator++;
                    currentState = transition.Next;
                }
            }
            if (lexema.FinalStates.Contains(currentState))
            {
                return new Tuple<bool, int>(true, iterator - skip);
            }
            else
            {
                return new Tuple<bool, int>(false, 0);
            }
        }
        public Tuple<bool, int> CheckForIntValue(int skip, string line)
        {
            return CheckThroughAnLexema(lexemes.Find(x => x.LexemeName == "ValueInt"), skip, line);
        }
        public List<string> CheckForEverything(string line)
        {
            List<string> result = new List<string>();
            int iterator = 0;
            while(iterator<line.Length)
            {
                bool lexemeWasIdentified = false;
                foreach(var item in lexemes)
                {
                    Tuple<bool, int> currentLexemCheckResult = CheckThroughAnLexema(item, iterator, line);
                    if (currentLexemCheckResult.Item1)
                    {
                        result.Add(item.LexemeName);
                        iterator += currentLexemCheckResult.Item2;
                        lexemeWasIdentified = true;
                        break;
                    }
                }
                if (!lexemeWasIdentified)
                {
                    result.Add("undefined symbol");
                    iterator++;
                }
                
            }
            return result;
        }
    }
}

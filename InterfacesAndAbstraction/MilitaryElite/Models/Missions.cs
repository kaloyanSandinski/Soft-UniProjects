using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enum;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Missions : IMissions
    {
        public Missions(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; }
        public State State { get; private set; }
        public void CompleteMission()
        {
            State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enum;

namespace MilitaryElite.Interfaces
{
    public interface IMissions
    {
        public string CodeName { get; }
        public State State { get; }

        void CompleteMission();
    }
}

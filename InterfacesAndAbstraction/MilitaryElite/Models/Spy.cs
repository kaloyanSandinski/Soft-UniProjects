using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    class Spy : Private, ISpy
    {
        public Spy(int id, string firstName, string lastName, decimal salary, int codeNumber) 
            : base(id, firstName, lastName, salary)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Code Number: {CodeNumber}";
        }
    }
}

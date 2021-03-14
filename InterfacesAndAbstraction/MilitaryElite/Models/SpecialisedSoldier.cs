using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enum;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corbs corbs) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corbs;
        }

        public Corbs Corps { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps}";
        }
    }
}

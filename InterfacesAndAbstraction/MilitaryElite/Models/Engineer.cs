using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enum;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, Corbs corbs) 
            : base(id, firstName, lastName, salary, corbs)
        {
            repairs = new List<IRepair>();
        }

        public string PartName { get; set; }
        public int HoursWorked { get; set; }
        public IReadOnlyCollection<IRepair> Repairs => repairs.AsReadOnly();
        public void AddRepairs(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Repairs:");
            foreach (var repair in repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}

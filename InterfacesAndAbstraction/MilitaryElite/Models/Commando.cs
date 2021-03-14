using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MilitaryElite.Enum;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMissions> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, Corbs corbs) 
            : base(id, firstName, lastName, salary, corbs)
        {
            missions = new List<IMissions>();
        }

        public IReadOnlyCollection<IMissions> Missions => missions.AsReadOnly();
        public void AddMission(IMissions mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");
            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().Trim();
        }
    }
}

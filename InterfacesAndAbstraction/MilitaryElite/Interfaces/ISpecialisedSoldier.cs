using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enum;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corbs Corps { get; }
    }
}

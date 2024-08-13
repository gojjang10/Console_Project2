using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;

namespace TestRPG.Interfaces
{
    internal interface IInteractable
    {
        void Interaction(Player player);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public interface ISolwerOutput
    {
        void SolwerGreating();
        void Assumption(int assumption);
        void ResaultAssumption(bool guessed);

    }
}

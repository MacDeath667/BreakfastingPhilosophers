using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakfastingPhilosophers
{
    class Officiant
    {
        Object brainThread = new Object();
        public bool GivePermissionToGetFork(ref Fork left, ref Fork right)
        {
            lock (brainThread)
            {
                if (!left.IsBusy && !right.IsBusy)
                {
                    return true;
                }

                return false;
            }
        }
    }
}

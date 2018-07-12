using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BreakfastingPhilosophers
{
    class Philosopher
    {
        bool LeftHandIsBusy { get; set; }
        bool RightHandIsBusy { get; set; }
        string name;
        bool thought;

        public Philosopher(string _name)
        {
            name = _name;
        }
        public void GetFork(bool permission, ref Fork forkLeft, ref Fork forkRight)
        {
            while (true)
            {
                if (permission && !forkRight.IsBusy && !forkLeft.IsBusy)
                {
                    forkRight.IsBusy = true;
                    forkLeft.IsBusy = true;
                    LeftHandIsBusy = true;
                    RightHandIsBusy = true;
                    Console.WriteLine(name + " прекрасно себе ужинает");
                    LeaveFork(ref permission, ref forkRight, ref forkLeft);
                }

                if (!permission)
                {
                    thought = false;
                    Think();
                }
            }
        }




        void LeaveFork(ref bool permission, ref Fork forkLeft, ref Fork forkRight)
        {
            forkRight.IsBusy = false;
            forkLeft.IsBusy = false;
            LeftHandIsBusy = false;
            RightHandIsBusy = false;
            permission = false;
        }

        void Think()
        {
            if (!thought)
            {
                thought = true;
                Console.WriteLine(name + " размяшляет о бренности бытия");
            }
        }
    }
}

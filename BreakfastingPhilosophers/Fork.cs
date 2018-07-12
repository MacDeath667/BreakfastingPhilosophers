using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakfastingPhilosophers
{
    public class Fork
    {
        public Fork(int number)
        {
            Number = number;
            IsBusy = false;
        }

        //props
        private int Number { get; set; }
        public bool IsBusy { get; set; }
    }
}

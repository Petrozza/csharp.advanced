using System;
using System.Collections.Generic;
using System.Text;

namespace Border.Control
{
    interface IBuyer
    {
        public int Food { get; }
        public string Name { get; }
        public void  BuyFood();
    }
}

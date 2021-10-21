using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket
{
    interface IPurchase
    { // This interface defines the behavior of purchase: by the supermarket and by the end-user.
        public abstract void Purchase();
        public abstract void CalculateTotalPrice();
        public abstract void HandleSupply();
    }
}

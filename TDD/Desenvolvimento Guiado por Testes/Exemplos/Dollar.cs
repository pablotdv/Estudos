using System;

namespace Exemplos
{
    internal class Dollar
    {        
        public Dollar(int amount) => _amount = amount;

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }


        internal Dollar Times(int multiplier) {
            return new Dollar(_amount * multiplier);            
        }
    }
}
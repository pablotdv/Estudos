using System;

namespace Capitulo01
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


        internal void Times(int multiplier) {
            _amount *= multiplier;
        }
    }
}
using System;

namespace _10x10SaldiriOyunu
{
    internal class Player
    {
        public string Name;
        public string Sign;
        public string _Sign
        {
            set
            {
                if (value == "0")
                    Sign = "x";
                else if (value == "1")
                    Sign = "o";
                else
                    Console.WriteLine("Uyarı! Lütfen 1 ya da 0 giriniz. | 0: x | 1: o");
            }
        }
    }
}

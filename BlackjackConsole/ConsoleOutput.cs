using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    class ConsoleOutput
    {
        public void TakeCard()
        {
            Console.WriteLine("\nDo you wanna take a card?\nY/N");
        }
        public void YouCards()
        {
            Console.WriteLine($"\nYour cards:");
        }
        public void CroupierCards()
        {
            Console.WriteLine($"\nCroupier cards: ");
        }
        public void Win()
        {
            Console.WriteLine("\nWin!");
        }
        public void Loose()
        {
            Console.WriteLine("\nLoose!");
        }
        public void Draw()
        {
            Console.WriteLine("\nThe game ended in a draw");
        }
        public void QuantityOfDecks()
        {
            Console.WriteLine("Coice quantity of card decks \nFrom 1 to 6");
        }
        public void IncorrectlyData()
        {
            Console.WriteLine("Incorrectly entered data, try again!");
        }
        public void ChoiceMoney(){
            Console.WriteLine("Choice amount of your money");
        }

        public void ChoiceRate()
        {
            Console.WriteLine("Choice your rate");
        }
        public void HigherRate()
        {
            Console.WriteLine("Your rate higher then your bank");
        }
        public void ChoiceAce()
        {
            Console.WriteLine("Choice value of Ace\n1 or 11");
        }
        public void MakeChoice()
        {

        }
    }
    
}

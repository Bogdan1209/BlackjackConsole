using System;
using System.Collections.Generic;
using BlackjackConsole.Interfaces;

namespace BlackjackConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ICroupier croupier = new Croupier();
            croupier.NumberOfDecks();
            List<string> currentDeck = croupier.CreateDeck();
            IGame game = new Game(currentDeck);
            Console.ReadLine();
        }
    }

    public class CroupierResult
    {
        public bool NeedCard { get; set; }
        public int CroupierAce { get; set; }
    }
}

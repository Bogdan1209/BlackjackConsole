using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsole.Interfaces;
using BlackjackConsole.Models;

namespace BlackjackConsole
{
    class Croupier:ICroupier
    {
        ICustomer user;
        CroupierModel CroupM;
        CustomerModel CustM;
        ConsoleOutput ConOut;

        public Croupier()
        {
            user = new Customer();
            CustM = new CustomerModel();
            CroupM = new CroupierModel();
            ConOut = new ConsoleOutput();
            CustM.customerCards = new List<string>();
            CroupM.CroupierCards = new List<string>();
            
        }

        

        int croupierAcePoint = 0;
        static int currentCountOfDecks;

        public int NumberOfDecks()
        {
            int countOfDecks = 0;
            ConOut.QuantityOfDecks();
            while (true)
            {
                try
                {
                    currentCountOfDecks = Int32.Parse(Console.ReadLine()).RangeOf(1, 6);
                    break;

                }
                catch (Exception)
                {
                    ConOut.IncorrectlyData();
                }
            }
            return countOfDecks;

        }
        public List<string> CreateDeck()
        {
            const int COUNT_OF_SUIR = 4;
            IEnumerable<string> newDecks = new List<string>(CroupM.cardsValue.Keys);

            for (int i = 1; i < currentCountOfDecks * COUNT_OF_SUIR; i++)
            {
                newDecks = newDecks.Concat(CroupM.cardsValue.Keys);
            }
            var Deck = newDecks.ToList();
            Deck.Shuffle();
            return Deck;

        }

        public string GetCard(List<string> currentDeck)
        {
            var card = currentDeck[0];
            currentDeck.RemoveAt(0);
            return card;
        }

        private int ChoiceValueOfAse(int croupierScoupe)
        {
           if (croupierScoupe + 11 > 21)
                return 1;
           return 11;
        }

        private int CheckAce(int croupierScoupe)
        {
            if (CroupM.CroupierCards[CroupM.CroupierCards.Count - 1] == "A")
            {
                return croupierAcePoint += ChoiceValueOfAse(croupierScoupe);
            }
            return croupierScoupe;
        }

        public CroupierResult TakeCard(List<string> currentDeck, int userScoupe, int croupierScoupe)
        {
            CroupierResult crupierResult = new CroupierResult();
            if (croupierScoupe < 17 && croupierScoupe < userScoupe)
            {
                CroupM.CroupierCards.Add(GetCard(currentDeck));
                croupierAcePoint = CheckAce(croupierScoupe);
                crupierResult.NeedCard = true;
                crupierResult.CroupierAce = croupierAcePoint;
                return crupierResult;
            }
            crupierResult.NeedCard = false;
            crupierResult.CroupierAce = croupierAcePoint;
            return crupierResult;

        }

        
    }
}

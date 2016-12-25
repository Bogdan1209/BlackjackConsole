using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsole.Interfaces;

namespace BlackjackConsole
{
    class Croupier:ICroupier
    {
        ICustomer user;
        public Croupier()
        {
            user = new Customer();
            user.customerCards = new List<string>();
            cardsValue = new Dictionary<string, int> { { "2",2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
            { "7", 7 }, { "8",8 },{ "9",9 }, { "10",10 }, { "J", 10 }, { "Q", 10 }, { "K",10 }, { "A",0 } };
        }

        public List<string> CroupierCards { get; set; }
        public Dictionary<string, int> cardsValue { get; set; }

        int croupierAce = 0;
        static int currentCountOfDecks;
        public int NumberOfDecks()
        {
            int countOfDecks = 0;
            Console.WriteLine("Coice quantity of card decks \nFrom 1 to 6");
            while (true)
            {
                try
                {
                    currentCountOfDecks = Int32.Parse(Console.ReadLine()).RangeOf(1, 6);
                    break;

                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrectly entered data, try again!");
                }
            }
            return countOfDecks;

        }
        public List<string> CreateDeck()
        {
            const int COUNT_OF_SUIR = 4;
            IEnumerable<string> newDecks = new List<string>(cardsValue.Keys);

            for (int i = 1; i < currentCountOfDecks * COUNT_OF_SUIR; i++)
            {
                newDecks = newDecks.Concat(cardsValue.Keys);
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
            else
                return 11;
        }


        public CroupierResult TakeCard(List<string> currentDeck, int userScoupe, int croupierScoupe)
        {
            CroupierResult crupierResult = new CroupierResult();
            if (croupierScoupe < 17 && croupierScoupe < userScoupe)
            {
                CroupierCards.Add(GetCard(currentDeck));
                if (CroupierCards[CroupierCards.Count - 1] == "A")
                {
                    croupierAce += ChoiceValueOfAse(croupierScoupe);
                }
                crupierResult.NeedCard = true;
                crupierResult.CroupierAce = croupierAce;
                return crupierResult;
            }
            else
            {
                crupierResult.NeedCard = false;
                crupierResult.CroupierAce = croupierAce;
                return crupierResult;
            }
                

        }

        
    }
}

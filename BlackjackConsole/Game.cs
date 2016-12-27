using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsole.Interfaces;
using BlackjackConsole.Models;

namespace BlackjackConsole
{
    public class Game:IGame
    {
        List<string> currentDeck { get; set; }
        ICroupier croupier;
        ICustomer user;
        CustomerModel CustM;
        CroupierModel CroupM;
        ConsoleOutput ConOut;
        int userAcePoint = 0;

        public Game(List<string> currentDeck)
        {
            CustM = new CustomerModel();
            CroupM = new CroupierModel();
            croupier = new Croupier();
            user = new Customer();
            ConOut = new ConsoleOutput();
            this.currentDeck = currentDeck;
            CustM.customerCards = new List<string>();
            CroupM.CroupierCards = new List<string>();

            StartGame();
        }

        public void StartGame()
        {     
            //Очки за тузов



            user.ChoiceBank();
            user.ChangeRate();
            GetCards();

            

            foreach (string str in CustM.customerCards)
            if (str == "A")
            {
                userAcePoint += user.ChoiceValueOfAse();
            }
            int[] scoupeArray = CroupierTakeCards();

            CheckWinner(scoupeArray[0], scoupeArray[1]);
        }

        public int[] CroupierTakeCards()
        {
            int croupierAcePoint = 0;
            CroupierResult croupierResult = new CroupierResult();
            bool croupierTakeCard = true;
            int[] scoupeArray = CountPoints(userAcePoint, croupierAcePoint);
            while (croupierTakeCard)
            {
                croupierResult = croupier.TakeCard(currentDeck, scoupeArray[0], scoupeArray[1]);
                scoupeArray = CountPoints(userAcePoint, croupierAcePoint);
                croupierTakeCard = croupierResult.NeedCard;
                croupierAcePoint = croupierResult.CroupierAce;
            }
            return scoupeArray;
        }

        public void GetCards()
        {
            bool userTakeCard = true;
            for (int i = 0; i < 2; i++)
            {
                if (currentDeck.Count <= 0)
                {
                    currentDeck = croupier.CreateDeck();

                }

                CustM.customerCards.Add(croupier.GetCard(currentDeck));
            }
            CroupM.CroupierCards.Add(croupier.GetCard(currentDeck));
            ShowCards();
            while (userTakeCard)
            {
                userTakeCard = TakeCard();
            }
        }

       public bool TakeCard()
        {
            ConOut.TakeCard();
            var result = Console.ReadKey().Key;
            while (true)
            {
                switch (result)
                {
                    case ConsoleKey.Y:
                        CustM.customerCards.Add(croupier.GetCard(currentDeck));
                        ShowCards();
                        return true;                    
                    case ConsoleKey.N:
                        return false;
                    default:
                        Console.WriteLine("Make a choice");
                        break;
                }
            }
        }

        private void ShowCards()
        {
            ConOut.YouCards();
            foreach (string str in CustM.customerCards)
            {
                Console.Write(str + " ");
            }
            ConOut.CroupierCards();
            foreach (string str in CroupM.CroupierCards)
            {
                Console.Write(str + " ");
            }
        }

        private int[] CountPoints(int userAce, int croupieAce)
        {
            int userScoupe = 0;
            int croupierScoupe = 0;

            foreach (string str in CustM.customerCards)
            {
                userScoupe += CroupM.cardsValue[str];
            }
            foreach (string str in CroupM.CroupierCards)
            {
                croupierScoupe += CroupM.cardsValue[str];
            }

            userScoupe += userAce;
            croupierScoupe += croupieAce;

            CheckBlackjack(userScoupe, croupierScoupe);

            int[] scoupe = new int[] { userScoupe, croupierScoupe };
            return scoupe;

        }

        private bool CheckBlackjack(int userScoupe, int croupierScoupe)
        {
            if (userScoupe == 21)
            {
                ConOut.Win();
                CustM.customerBank += CustM.currentRate;
                return true;
            }
            if (croupierScoupe == 21)
            {
                ConOut.Loose();
                CustM.customerBank -= CustM.currentRate;
                return true;
            }
            return false;
        }

        private void CheckWinner(int userScoupe, int croupierScoupe)
        {
            if(userScoupe > croupierScoupe && userScoupe < 21 || croupierScoupe > 21)
            {
                ConOut.Win();
                CustM.customerBank += CustM.currentRate;
                return;
                
            }
            if(croupierScoupe > userScoupe && croupierScoupe < 21 || userScoupe > 21)
            {
                ConOut.Loose();
                CustM.customerBank -= CustM.currentRate;
                return;
            }

            ConOut.Draw();
        }


    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsole.Interfaces;

namespace BlackjackConsole
{
    public class Game:IGame
    {
        List<string> currentDeck { get; set; }
        ICroupier croupier;
        ICustomer user;

        public Game(List<string> currentDeck)
        {
            croupier = new Croupier();
            user = new Customer();
            this.currentDeck = currentDeck;
            user.customerCards = new List<string>();
            croupier.CroupierCards = new List<string>();

            StartGame();
        }

        public void StartGame()
        {
            CroupierResult croupierResult = new CroupierResult();
            //нужнали еще одна карта крупье/юзеру
            bool userTakeCard = true;
            bool croupierTakeCard = true;
            //Очки за тузов
            int userAcePoint = 0;
            int croupierAcePoint = 0;


            user.ChoiceBank();
            user.ChangeRate();

            for (int i = 0; i < 2; i++)
            {
                if (currentDeck.Count <= 0)
                {
                    currentDeck = croupier.CreateDeck();

                }
                
                user.customerCards.Add(croupier.GetCard(currentDeck));
            }
            croupier.CroupierCards.Add(croupier.GetCard(currentDeck));
            ShowCards();

            while (userTakeCard)
            {
                userTakeCard = TakeCard();
            }

            foreach (string str in user.customerCards)
            if (str == "A")
            {
                userAcePoint += user.ChoiceValueOfAse();
            }

            int[] scoupeArray = CountPoints(userAcePoint, croupierAcePoint);

            while (croupierTakeCard)
            {
                croupierResult = croupier.TakeCard(currentDeck, scoupeArray[0], scoupeArray[1]);
                scoupeArray = CountPoints(userAcePoint, croupierAcePoint);
                croupierTakeCard = croupierResult.NeedCard;
                croupierAcePoint = croupierResult.CroupierAce;
            }
            CheckWinner(scoupeArray[0], scoupeArray[1]);
        }

       public bool TakeCard()
        {
            Console.WriteLine("\nDo you wanna take a card?\nY/N");
            var result = Console.ReadKey().Key;
            while (true)
            {
                switch (result)
                {
                    case ConsoleKey.Y:
                        user.customerCards.Add(croupier.GetCard(currentDeck));
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
            Console.WriteLine($"\nYour cards:");
            foreach (string str in user.customerCards)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine($"\nCroupier cards: ");
            foreach (string str in croupier.CroupierCards)
            {
                Console.Write(str + " ");
            }
        }

        private int[] CountPoints(int userAce, int croupieAce)
        {
            int userScoupe = 0;
            int croupierScoupe = 0;

            foreach (string str in user.customerCards)
            {
                userScoupe += croupier.cardsValue[str];
            }
            foreach (string str in croupier.CroupierCards)
            {
                croupierScoupe += croupier.cardsValue[str];
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
                Console.WriteLine("\nWin!");
                user.customerBank += user.currentRate;
                return true;
            }
            if (croupierScoupe == 21)
            {
                Console.WriteLine("\nLoose!");
                user.customerBank -= user.currentRate;
                return true;
            }
            return false;
        }

        private void CheckWinner(int userScoupe, int croupierScoupe)
        {
            if(userScoupe > croupierScoupe && userScoupe < 21 || croupierScoupe > 21)
            {
                Console.WriteLine("\nWin!");
                user.customerBank += user.currentRate;
                
            }
            else if(croupierScoupe > userScoupe && croupierScoupe < 21 || userScoupe > 21)
            {
                Console.WriteLine("\nLoose!");
                user.customerBank -= user.currentRate;
            }
            else
            {
                Console.WriteLine("\nThe game ended in a draw");
            }
        }


    }
}

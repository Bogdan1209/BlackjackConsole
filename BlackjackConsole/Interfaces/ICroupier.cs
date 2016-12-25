using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole.Interfaces
{
    interface ICroupier
    {
        Dictionary<string, int> cardsValue { get; set; }
        List<string> CroupierCards { get; set; }
        int NumberOfDecks();
        List<string> CreateDeck();
        string GetCard(List<string> currentDeck);
        CroupierResult TakeCard(List<string> currentDeck, int userScoupe, int croupierScoupe);
    }
}

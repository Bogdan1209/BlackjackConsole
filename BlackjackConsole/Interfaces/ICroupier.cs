using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackConsole.Models;

namespace BlackjackConsole.Interfaces
{
    interface ICroupier
    {
        int NumberOfDecks();
        List<string> CreateDeck();
        string GetCard(List<string> currentDeck);
        CroupierResult TakeCard(List<string> currentDeck, int userScoupe, int croupierScoupe);
    }
}

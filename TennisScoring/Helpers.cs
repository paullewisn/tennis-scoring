using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoring
{
    public static class Helpers
    {
        public static string PLAYER1
        {
            get { return "Player 1"; }
        }

        public static string PLAYER2
        {
            get { return "Player 2"; }
        }

        public static string WINNER
        {
            get { return "{0} is the winner"; }
        }

        public static string DEUCE
        {
            get { return "Deuce at {0} points"; }
        }

        public static string SCORE
        {
            get { return "{0} - {1}"; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoring
{
    public class Scorer
    {
        public string GetScore(int player1score, int player2score)
        {
            if (player1score == player2score) return string.Format(Helpers.DEUCE, player1score);
            return "invalid score";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoring
{
    public class Scorer
    {
        public string GetScore(int player1Score, int player2Score)
        {
            string player1ScoreStr = player1Score.ToString();
            string player2ScoreStr = player2Score.ToString();
            if (player1ScoreStr == "0") player1ScoreStr = Helpers.LOVE;
            if (player2ScoreStr == "0") player2ScoreStr = Helpers.LOVE;

            if (player1ScoreStr == player2ScoreStr && player1ScoreStr != Helpers.MAX_SCORE &&
                player2ScoreStr != Helpers.MAX_SCORE)
                return string.Format(Helpers.ALL, player1ScoreStr);

            if (player1Score == player2Score && player1ScoreStr == Helpers.MAX_SCORE &&
                player2ScoreStr == Helpers.MAX_SCORE)
                return string.Format(Helpers.DEUCE, player1ScoreStr);

            return string.Format(Helpers.SCORE, player1ScoreStr, player2ScoreStr);
        }
    }
}
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoring.Tests
{
    [TestFixture]
    public class Tests
    {
        private Scorer _scorer;

        [SetUp]
        public void Init()
        {
            _scorer = new Scorer();
        }

        [TestCaseSource(nameof(ZeroTestCases))]
        public void ZeroScoreProducesLove(int player1Score, int player2Score)
        {
            var result = _scorer.GetScore(player1Score, player2Score);
            var resultChk = result.Contains(Helpers.LOVE) && !result.Contains(" 0");
            Console.WriteLine(resultChk);
            Assert.IsTrue(resultChk);
        }

        [TestCaseSource(nameof(EvenTestCases))]
        public void DrawScoreProducesValidResult(int player1Score, int player2Score)
        {
            var result = _scorer.GetScore(player1Score, player2Score);
            var expectedResult =
                player1Score == 40
                    ? string.Format(Helpers.DEUCE, player1Score)
                    : string.Format(Helpers.ALL, player1Score == 0 ? Helpers.LOVE : player1Score.ToString());
            Console.WriteLine(result);
            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }

        [TestCase(40, 40)]
        public void DeuceScoreProducesValidResult(int player1Score, int player2Score)
        {
            var result = _scorer.GetScore(player1Score, player2Score);
            var expectedResult = string.Format(Helpers.DEUCE, player1Score);
            Console.WriteLine(result);
            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }

        [Test]
        public void ScoreProducesAnyResult()
        {
            var result = _scorer.GetScore(15, 15);
            Assert.That(result, Is.Not.Empty);
        }

        [TestCaseSource(nameof(OddTestCases))]
        public void UnequalScoreProducesRegularResult(int player1Score, int player2Score)
        {
            var result = _scorer.GetScore(player1Score, player2Score);
            Console.WriteLine(result);
            var expectedResult = string.Format(Helpers.SCORE, player1Score == 0 ? Helpers.LOVE : player1Score.ToString(),
                player2Score == 0 ? Helpers.LOVE : player2Score.ToString());
            StringAssert.AreEqualIgnoringCase(expectedResult, result);
        }

        public static object[] OddTestCases =
        {
            new[] {0, 15},
            new[] {0, 30},
            new[] {0, 40},
            new[] {15, 0},
            new[] {15, 30},
            new[] {15, 40},
            new[] {30, 0},
            new[] {30, 15},
            new[] {30, 40},
            new[] {40, 0},
            new[] {40, 15},
            new[] {40, 30},
        };

        public static object[] ZeroTestCases =
        {
            new[] {0, 0},
            new[] {0, 15},
            new[] {0, 30},
            new[] {0, 40},
            new[] {15, 0},
            new[] {30, 0},
            new[] {40, 0},
        };

        public static object[] EvenTestCases =
        {
            new[] {0, 0},
            new[] {15, 15},
            new[] {30, 30},
            new[] {40, 40},
        };
    }
}
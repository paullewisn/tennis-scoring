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
        private Scorer scorer;

        [SetUp]
        public void Init()
        {
            scorer = new Scorer();
        }

        [TestCase(0, 0)]
        [TestCase(15, 15)]
        [TestCase(30, 30)]
        public void DrawScoreProducesValidResult(int player1Score, int player2Score)
        {
            var result = scorer.GetScore(player1Score, player2Score);
            var expectedResult = string.Format(Helpers.ALL, player1Score);
            Console.WriteLine(result);
            StringAssert.AreEqualIgnoringCase(result, expectedResult, result);
        }

        [TestCase(40, 40)]
        public void DeuceScoreProducesValidResult(int player1Score, int player2Score)
        {
            var result = scorer.GetScore(player1Score, player2Score);
            var expectedResult = string.Format(Helpers.DEUCE, player1Score);
            Console.WriteLine(result);
            StringAssert.AreEqualIgnoringCase(result, expectedResult, result);
        }

        [TestCase(0, 0)]
        [TestCase(15, 30)]
        [TestCase(30, 30)]
        public void InvalidDeuceScoreProducesResult(int player1Score, int player2Score)
        {
            var result = scorer.GetScore(player1Score, player2Score);
            var expectedResult = string.Format(Helpers.DEUCE, player1Score);
            Console.WriteLine(result);
            StringAssert.AreEqualIgnoringCase(result, expectedResult, result);
        }

        [Test]
        public void ScoreProducesAnyResult()
        {
            var result = scorer.GetScore(15, 15);
            Assert.That(result, Is.Not.Empty);
        }
    }
}
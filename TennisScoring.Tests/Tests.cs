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

        [TestCase(15, 15)]
        public void DeuceScoreProducesValidResult(int player1Score, int player2Score)
        {
            var result = scorer.GetScore(player1Score, player2Score);
            Assert.That(result, Is.EqualTo(string.Format(Helpers.DEUCE, player1Score)));
        }

        [TestCase(15, 30)]
        public void InvalidDeuceScoreProducesResult(int player1Score, int player2Score)
        {
            var result = scorer.GetScore(player1Score, player2Score);
            Assert.That(result, Is.Not.EqualTo(string.Format(Helpers.DEUCE, player1Score)));
        }

        [Test]
        public void ScoreProducesAnyResult()
        {
            var result = scorer.GetScore(15, 15);
            Assert.That(result, Is.Not.Empty);
        }
    }
}
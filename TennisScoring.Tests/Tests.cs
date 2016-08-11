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

        [Test]
        public void ScoreProducesResult()
        {
            var result = scorer.GetScore(15, 15);
            Assert.That(result, Is.Not.Empty);
        }
    }
}
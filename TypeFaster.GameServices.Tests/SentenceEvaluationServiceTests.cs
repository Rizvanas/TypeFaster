using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;
using TypeFaster.Persistence.Contracts;

namespace TypeFaster.GameServices.Tests
{
    [TestFixture]
    public class SentenceEvaluationServiceTests
    {
        private ISentenceRepository _sentenceRepository;
        private ISententceEvaluationService _sententceEvaluationService;

        [SetUp]
        public void SetUp()
        {
            _sentenceRepository = Substitute.For<ISentenceRepository>();
            _sentenceRepository.GetAllSentences().Returns(GetSentencesTestList());
            _sentenceRepository.GetSentenceById(1).Returns(GetSentencesTestList().First());
            _sentenceRepository.GetSentenceById(2).Returns(GetSentencesTestList().Last());

            _sententceEvaluationService = new SentenceEvaluationService(_sentenceRepository);
        }

        [Test]
        [TestCase(1,"")]
        [TestCase(1, "J")]
        [TestCase(1, "Jus")]
        [TestCase(1, "Just ")]
        [TestCase(1, "Just so")]
        [TestCase(1, "Just some words for testing purposes.")]
        public void CheckIfInputIsASliceOfSentence_Returns_True(int testSentenceId, string userInput)
        {
            var testResult = _sententceEvaluationService
                .CheckIfInputIsASliceOfSentence(userInput, testSentenceId);

            _sentenceRepository.Received(1).GetSentenceById(testSentenceId);
            testResult.ShouldBeTrue();
        }

        [Test]
        [TestCase(2, "a")]
        [TestCase(2, "anoter")]
        [TestCase(2, "anos")]
        [TestCase(2, "asdsa")]
        [TestCase(2, "Another\tmeaningless text, create just for testing purposes.")]
        public void CheckIfInputIsASliceOfSentence_Returns_False(int testSentenceId, string userInput)
        {
            var testResult = _sententceEvaluationService
                .CheckIfInputIsASliceOfSentence(userInput, testSentenceId);

            _sentenceRepository.Received(1).GetSentenceById(testSentenceId);
            testResult.ShouldBeFalse();
        }

        [Test]
        [TestCase(1, null)]
        public void CheckIfInputIsASliceOfSentence_Trows_ArgumentNullException(int testSentenceId, string userInput)
        {
            Should.Throw<ArgumentNullException>(() => _sententceEvaluationService
                .CheckIfInputIsASliceOfSentence(userInput, testSentenceId));

            _sentenceRepository.Received(0).GetSentenceById(testSentenceId);
        }


        private IList<Sentence> GetSentencesTestList()
        {
            return new List<Sentence>
            {
                new Sentence
                {
                    Id = 1,
                    Words = "Just some words for testing purposes."
                },
                new Sentence
                {
                    Id = 1,
                    Words = "Another meaningless text, created just for testing pursoses."
                },
            };
        }
    }
}

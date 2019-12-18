using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using TypeFaster.Common.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;
using TypeFaster.GameServices.Implementations;

namespace TypeFaster.GameServices.Tests
{
    public class TestData
    {
        public Sentence Sentence { get; set; }
        public TimeSpan ExpectedResult { get; set; }
    }

    public class TimeServiceTests
    {
        private ITimeService _timeService;
        private ITimer _timer;
        private IStopwatch _stopwatch;

        [SetUp]
        public void Setup()
        {
            _timer = Substitute.For<ITimer>();
            _stopwatch = Substitute.For<IStopwatch>();
            _timeService = new TimeService(_stopwatch, _timer);
        }

        private static TestData[] validDataSet = new[]
        {
            new TestData
            {
                Sentence = new Sentence { Id = 1, Words = "Hello, World!" },
                ExpectedResult = TimeSpan.FromSeconds(6)
            },
            new TestData
            {
                Sentence = new Sentence { Id = 2, Words = "" },
                ExpectedResult = TimeSpan.FromSeconds(3)
            }
        };

        private static TestData[] invalidDataSet = new[]
        {
            new TestData
            {
                Sentence = new Sentence { Id = 3, Words = null }
            },
            new TestData
            {
                Sentence =  null
            }
        };


        [Test]
        public void CalculateGameDurationReturnsCorrectResultWhenInputIsValid([ValueSource("validDataSet")]TestData testData)
        {
            var result = _timeService.CalculateGameDuration(testData.Sentence);
            result.ShouldBe(testData.ExpectedResult);
        }

        [Test]
        public void CalculateGameDurationThorwsExceptionWhenInputIsInvalid([ValueSource("invalidDataSet")]TestData testData)
        {
            Should.Throw<ArgumentException>(() =>
            {
                _timeService.CalculateGameDuration(testData.Sentence);
            });
        }
    }
}

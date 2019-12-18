using NUnit.Framework;
using Shouldly;
using System;
using TypeFaster.GameServices.Contracts;
using TypeFaster.GameServices.Implementations;

namespace TypeFaster.GameServices.Tests
{
    public class TypingTestData
    {
        public string UserInput { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public int TotalErrorsMade { get; set; }
        public int ExpectedNetSpeed { get; set; }
        public int ExpectedGrossSpeed { get; set; }
        public decimal ExpectedAccuracy { get; set; }
    }

    public class TypingCalculatorTests
    {
        private ITypingCalculator _typingCalculator;

        [SetUp]
        public void SetUp()
        {
            _typingCalculator = new TypingCalculator();
        }

        private static TypingTestData[] _typingTestDataSet1 = new[]
        {
            new TypingTestData
            {
                UserInput = "Labas vakaras, ponai ir ",
                ElapsedTime = TimeSpan.FromSeconds(60),
                TotalErrorsMade = 1,
                ExpectedNetSpeed = 3,
                ExpectedGrossSpeed = 4,
                ExpectedAccuracy = 75M
            },
            new TypingTestData
            {
                UserInput = "Labas vakaras, ponai ir ",
                ElapsedTime = TimeSpan.FromSeconds(60),
                TotalErrorsMade = 0,
                ExpectedNetSpeed = 4,
                ExpectedGrossSpeed = 4,
                ExpectedAccuracy = 100M
            },
            new TypingTestData
            {
                UserInput = "Labas vakaras, ponai ir ",
                ElapsedTime = TimeSpan.FromSeconds(10),
                TotalErrorsMade = 0,
                ExpectedNetSpeed = 24,
                ExpectedGrossSpeed = 24,
                ExpectedAccuracy = 100M
            }
        };
        private static TypingTestData[] _typingTestDataSet2 = new[]
       {
            new TypingTestData
            {
                UserInput = "",
                ElapsedTime = TimeSpan.FromSeconds(0),
                TotalErrorsMade = 1,
                ExpectedNetSpeed = 3,
                ExpectedGrossSpeed = 4,
                ExpectedAccuracy = 75M
            },
        };


        [Test]
        public void GetNetTypingSpeedReturnsExpectedValue(
            [ValueSource("_typingTestDataSet1")]TypingTestData testData)
        {
            var testResult = _typingCalculator.GetNetTypingSpeed(testData.UserInput, testData.ElapsedTime, testData.TotalErrorsMade);

            testResult.ShouldBe(testData.ExpectedNetSpeed);
        }

        [Test]
        public void GetGrossTypingSpeedReturnsExpectedValue(
            [ValueSource("_typingTestDataSet1")]TypingTestData testData)
        {
            var testResult = _typingCalculator.GetGrossTypingSpeed(testData.UserInput, testData.ElapsedTime);

            testResult.ShouldBe(testData.ExpectedGrossSpeed);
        }

        [Test]
        public void GetTypingAccuracyReturnsExpectedValue(
            [ValueSource("_typingTestDataSet1")]TypingTestData testData)
        {
            var testResult = _typingCalculator.GetTypingAccuracy(testData.UserInput, testData.TotalErrorsMade);

            testResult.ShouldBe(testData.ExpectedAccuracy);
        }

        [Test]
        public void GetNetTypingSpeedThrowsDivideByZeroExceptionWhenElapsedTimeIs0(
            [ValueSource("_typingTestDataSet2")]TypingTestData testData)
        {
            Should.Throw<DivideByZeroException>(() => _typingCalculator.GetNetTypingSpeed(
                    testData.UserInput,
                    testData.ElapsedTime,
                    testData.TotalErrorsMade));
        }

        [Test]
        public void GetGrossTypingSpeedThrowsDivideByZeroExceptionWhenElapsedTimeIs0(
            [ValueSource("_typingTestDataSet2")]TypingTestData testData)
        {
            Should.Throw<DivideByZeroException>(() => _typingCalculator.GetGrossTypingSpeed(
                    testData.UserInput,
                    testData.ElapsedTime));
        }

        [Test]
        public void GetTypingAccuracyThrowsDivideByZeroExceptionWhenUserInputLenghtIs0(
            [ValueSource("_typingTestDataSet2")]TypingTestData testData)
        {
            Should.Throw<DivideByZeroException>(() => _typingCalculator.GetTypingAccuracy(
                    testData.UserInput,
                    testData.TotalErrorsMade));
        }
    }
}

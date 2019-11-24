using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using TypeFaster.Domain.Entities;
using TypeFaster.Domain.ValueObjects;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class ClassicTypingRace : ITypingRace, IObservable
    {
        private readonly TypingRaceData _typingRaceData;
        private readonly ITypingCalculator _typingCalculator;
        private readonly List<IObserver> _observers;

        public string PreErrorInput { get; private set; }
        public int UserTypingSpeed => _typingRaceData.WordsPerMinute;
        public string UserInput => _typingRaceData.UserInput;
        public string Sentence => _typingRaceData.Sentence.Words;

        public TypingRaceState State => _typingRaceData.State;

        public ClassicTypingRace(TypingRaceData typingRaceData, ITypingCalculator typingCalculator)
        {
            _typingRaceData = typingRaceData;
            _typingCalculator = typingCalculator;
            _observers = new List<IObserver>();
            PreErrorInput = "";
        }

        public void InsertNewLetter(char letter)
        {
            _typingRaceData.UserInput += letter;
        }

        public void DeleteLastLetter()
        {
            var userInput = _typingRaceData.UserInput;
            var lastWordIndex = userInput.Length - 1;

            if (lastWordIndex != -1)
                _typingRaceData.UserInput = userInput.Remove(lastWordIndex);
        }

        public void UpdateTypingSpeed()
        {
            var wordsPerMinute = _typingCalculator.GetNetTypingSpeed(
                userInput: State == TypingRaceState.Error ? 
                PreErrorInput : _typingRaceData.UserInput,
                startTime: _typingRaceData.StartTime,
                totalErrorsMade: _typingRaceData.Typos.Count);

            _typingRaceData.WordsPerMinute = wordsPerMinute;
        }

        public void UpdateTypoList()
        {
            var userInput = _typingRaceData.UserInput.Split(" ");
            var inputWordIndex = userInput.Length - 1;
            var word = _typingRaceData.Sentence.Words.Split(" ").ElementAt(inputWordIndex);

            var typoMade = false;
            if (!word.StartsWith(userInput.ElementAt(inputWordIndex)))
            {
                typoMade = true;
                _typingRaceData.Typos.TryAdd(inputWordIndex, word);
            }

            if (_typingRaceData.State != TypingRaceState.Error && typoMade)
            {
                if (UserInput.Length - 1 != -1)
                    PreErrorInput = UserInput.Remove(UserInput.Length - 1);
                UpdateTypingRaceState(TypingRaceState.Error);
            }
            else
                UpdateTypingRaceState(TypingRaceState.Running);
        }

        public void UpdateTypingRaceState(TypingRaceState state)
        {
            _typingRaceData.State = state;
            Notify();
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_typingRaceData.State);
            }
        }

        public void OnTimerIntervalEnd(Object source, ElapsedEventArgs e)
        {
            if (State != TypingRaceState.Error)
            {
                UpdateTypingSpeed();
            }
        }
    }
}

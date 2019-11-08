using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class ClassicTypingRace : ITypingRace, IObservable
    {
        private readonly TypingRaceData _typingRaceData;
        private readonly List<IObserver> _observers;

        public ClassicTypingRace(TypingRaceData typingRaceData)
        {
            _typingRaceData = typingRaceData;
            _observers = new List<IObserver>();
        }

        public void InsertNewLetter(char letter)
        {

            if (letter == ' ')
            {
                _typingRaceData.UserInput.Words.Add("");
            } 
            else
            {
                _typingRaceData.UserInput.Words.Last().Append(letter);
            }

            Notify();
        }

        public void DeleteLastLetter()
        {
            var lastWordIndex = _typingRaceData.UserInput.Words.Count - 1; 
            var lastWord = _typingRaceData.UserInput.Words.Last();

            if (lastWord == "")
            {
                _typingRaceData.UserInput.Words.RemoveAt(lastWordIndex);
            } 
            else
            {
                _typingRaceData.UserInput.Words[lastWordIndex] = lastWord.Remove(lastWord.Length - 1);
            }

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
                observer.Update();
            }
        }
    }
}

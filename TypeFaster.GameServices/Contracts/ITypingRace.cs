using System;
using System.Timers;
using TypeFaster.Domain.Entities;
using TypeFaster.Domain.ValueObjects;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITypingRace
    {
        string PreErrorInput { get; }
        string UserInput { get; }
        string Sentence { get; }
        int UserTypingSpeed { get; }
        TypingRaceState State { get; }
        void InsertNewLetter(char letter);
        void DeleteLastLetter();
        void UpdateTypingSpeed();
        void UpdateTypoList();
        void UpdateTypingRaceState(TypingRaceState state);
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify();
        void OnTimerIntervalEnd(Object source, ElapsedEventArgs e);
    }
}

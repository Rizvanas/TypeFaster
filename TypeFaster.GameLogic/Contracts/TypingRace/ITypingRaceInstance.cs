using System;
using System.Collections.Generic;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.Contracts.TypingRace
{
    public interface ITypingRaceInstance
    {
        string UserInput { get; }
        string Sentence { get; }
        IDictionary<int, string> Typos { get; }
        TimeSpan GameTimeLeft { get; }
        int TypingSpeed { get; }
        decimal TypingAccuracy { get; }
        TypingRaceState State { get; }
        bool IsInErrorState { get; }
        bool IsInExitState { get; }

        void HandleUserInput(ConsoleKeyInfo consoleKeyInfo);
        void Render();
        void ChangeState(TypingRaceState state);
        bool CheckForInputError();
        void UpdateTypos();
        void AddNewLetter(char letter);
        void DeleteLastLetter();
    }
}

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
        TypingRaceState State { get; }
        bool IsInErrorState { get; }
        bool IsInExitState { get; }
        public decimal TypingAccuracy { get; }
        public int TypingSpeed { get; }

        void HandleUserInput(ConsoleKeyInfo consoleKeyInfo);
        void Render();
        void ChangeState(TypingRaceState state);
        bool UserHasMadeATypo();
        void UpdateTypos();
        void AddNewLetter(char letter);
        void DeleteLastLetter();
        void ToggleTimer();
        void RestartTimer();
        void UpdateTypingSpeed();
        void UpdateTypingAccuracy();
    }
}

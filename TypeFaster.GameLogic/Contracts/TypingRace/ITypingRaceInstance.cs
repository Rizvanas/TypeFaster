using System;
using System.Collections.Generic;
using System.Timers;
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
        bool IsInFinishedState { get; }
        bool IsInWaitingForRestartState { get; }
        decimal TypingAccuracy { get; }
        int TypingSpeed { get; }

        void HandleUserInput(ConsoleKeyInfo consoleKeyInfo);
        void Render();
        void ChangeState(TypingRaceState state);
        bool UserHasMadeATypo();
        void UpdateTypos();
        void AddNewLetter(char letter);
        void DeleteLastLetter();
        void UpdateTypingSpeed(Object source, ElapsedEventArgs e);
        void UpdateTypingAccuracy();
        void TrySetToGameOverState(Object source, ElapsedEventArgs e);
        bool GameIsFinished();
    }
}

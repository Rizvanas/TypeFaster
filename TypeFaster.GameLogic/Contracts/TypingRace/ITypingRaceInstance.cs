﻿using System;
using System.Collections.Generic;
using System.Timers;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.Contracts.TypingRace
{
    public interface ITypingRaceInstance
    {
        string UserInput { get; }
        string PreErrorInput { get; }
        string Sentence { get; }
        IDictionary<int, string> Typos { get; }
        TimeSpan GameTimeLeft { get; }
        TypingRaceState State { get; }
        bool ShouldExit { get; set; }
        bool ShouldRestart { get; set; }
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
        void UpdatePreErrorInput();
        void TrySetToGameOverState(Object source, ElapsedEventArgs e);
        bool GameIsFinished();
        void Notify();
    }
}

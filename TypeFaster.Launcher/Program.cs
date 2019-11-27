using System;
using System.Diagnostics;
using System.Timers;
using TypeFaster.Common.services;
using TypeFaster.GameLogic.Input.Handlers;
using TypeFaster.GameLogic.Input.Listeners;
using TypeFaster.GameLogic.Rendering;
using TypeFaster.GameLogic.TypingRace;
using TypeFaster.GameServices.Implementations;
using TypeFaster.Launcher.GameLauncher;
using TypeFaster.Persistence.Repositories;

namespace TypeFaster.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentenceRepository = new SentenceTxtFileRepository("SentencesDatabase.txt");
            var rng = new RandomGenerator(new Random());
            var timeService = new TimeService(new Stopwatch(), new Timer());

            var gameLauncher = new ClassicGameLauncher(
                inputListener: new InputListener(),
                sentenceLoader: new SentenceLoader(sentenceRepository, rng), 
                timeService: timeService,
                typingCalculator: new TypingCalculator(),
                inputHandler: new InputHandler(timeService, new RaceInstanceModifier()),
                gameRenderer: new GameRenderer());

            gameLauncher.Launch();
        }
    }
}

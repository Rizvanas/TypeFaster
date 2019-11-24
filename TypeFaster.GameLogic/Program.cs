using System;
using System.Timers;
using TypeFaster.Common;
using TypeFaster.Common.services;
using TypeFaster.GameLogic.Implementations;
using TypeFaster.GameServices.Implementations;
using TypeFaster.Persistence.Repositories;
using TypeFaster.UI.Implementations;

namespace TypeFaster.GameLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var machineDateTime = new MachineDateTime();
            var sentenceRepo = new SentenceTxtFileRepository("SentencesDatabase.txt");
            var rng = new RandomGenerator(new Random());

            var timer = new Timer();
            timer.Interval = 1000;
            timer.AutoReset = true;

            var gameHandler = new ClassicGameHandler(
                userInputListener: new InputListener(),
                inputHandler: new InputHandler(new InitializedState(), new RaceInstanceAlterator()),
                timeService: new TimeService(machineDateTime),
                typingCalculator: new TypingCalculator(machineDateTime),
                sentenceLoader: new SentenceLoader(sentenceRepo, rng),
                gameRenderer: new GameRenderer(), 
                timer: timer);

            gameHandler.Run();
        }
    }
}

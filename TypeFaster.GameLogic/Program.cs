using System;
using TypeFaster.Common;
using TypeFaster.Common.services;
using TypeFaster.GameLogic.Commands;
using TypeFaster.GameLogic.Implementations;
using TypeFaster.GameServices.Implementations;
using TypeFaster.Persistence.Repositories;

namespace TypeFaster.GameLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentenceRepo = new SentenceTxtFileRepository("SentencesDatabase.txt");
            var rng = new RandomGenerator(new Random());
            var inputListener = new UserInputHandler();
            var timeService = new TimeService(new MachineDateTime());
            var sentenceLoader = new SentenceLoader(sentenceRepo, rng);
            var gameHandler = new ClassicGameHandler(inputListener, timeService, sentenceLoader);

            gameHandler.Run(true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.GameLogic.Contracts;

namespace TypeFaster.Launcher.GameLauncher
{
    public abstract class GameLauncher
    {
        public abstract ITypingRaceInstance CreateTypingRaceInstace();

        public void Run()
        {

        }
    }
}

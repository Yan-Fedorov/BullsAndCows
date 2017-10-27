﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;

namespace BullsAndCows.Oop.Menu
{
    public class OopMenu
    {
        private readonly IGamerConsoleInput _input;
        private readonly IOopRunnerOutput _output;
        private readonly IGameLoader _gameLoader;
        private readonly IBuilder _builder;
        private readonly IOopRunner _oopRunner;
        private readonly ITemporaryStorageSolwer _temporaryStorageSolwer;



        public OopMenu(IGamerConsoleInput input, IOopRunnerOutput output, IGameLoader gameLoader, IBuilder builder, IOopRunner oopRunner, ITemporaryStorageSolwer temporaryStorageSolwer)
        {
            _input = input;
            _output = output;
            _gameLoader = gameLoader;
            _builder = builder;
            _oopRunner = oopRunner;
            _temporaryStorageSolwer = temporaryStorageSolwer;
        }
        public List<TemporaryStorageSolwer> solwerList = new List<TemporaryStorageSolwer>();


        public void RunMainMenu()
        {
            while (true)
            {
                

        var input = _input.SelectGame();
                IOopGame game = null;

                switch (input.Option)
                {
                    case GameInputOption.CallGameMenu:

                        var gamesNames = _gameLoader.GetGameNames();
                        var savedGameKey = _input.SelectSavedGame(gamesNames);

                        if (savedGameKey.Option != GameInputOption.GameInput)
                            break;

                        var gameData = _gameLoader.Load(out game, savedGameKey.Input);
                        _oopRunner.Iteration = gameData.Iteration;
                        break;

                    case GameInputOption.Exit:
                        _output.ByeBye();
                        _input.PressAnyKey();
                        return;

                    case GameInputOption.GameInput:
                        game = _builder.GetGame(input.Input);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (game != null)
                    _oopRunner.Run(game);
                _temporaryStorageSolwer.WriteSolwerConsole(solwerList);
            }
        }
    }
}

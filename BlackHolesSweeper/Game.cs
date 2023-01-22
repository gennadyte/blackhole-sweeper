using BlackHolesSweeper.ConsoleWrapper;
using BlackHolesSweeper.Helpers;
using BlackHolesSweeper.Helpers.BlackHoleGenerator;

namespace BlackHolesSweeper;

    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IGenerateBlackHoles _blackHolesGenerator;
        public GameState State { get; private set; }
        public Board Board { get; private set; }
        
        public Game(IInput input, IOutput output, IGenerateBlackHoles blackHolesGenerator)
        {
            _input = input;
            _output = output;
            _blackHolesGenerator = blackHolesGenerator;
            State = GameState.Unknown;
        }

        public void CreateBoard()
        {
            var boardSize = SetGameBoardSize();
            Board = Board.CreateEmptyBoard(boardSize);
            _blackHolesGenerator.PlaceBlackHoles(boardSize, Board);
            HintGenerator.SetHints(Board);
            _output.Write(GameInstruction.DisplayCurrentBoardMessage);
            DisplayBoard();
        }
        
        private void DisplayBoard() => 
            _output.Write(Board.ToString());

        private int SetGameBoardSize()
        {
            var value = _input.Ask(GameInstruction.InputBoardSizeMessage);
            while (BoardSizeInputIsNotValid(value))
            {
                _output.Write(GameInstruction.InputNotValidMessage);
                value = _input.Ask(GameInstruction.InputBoardSizeMessage);
            }
            
            return int.Parse(value);
        }

        private static bool BoardSizeInputIsNotValid(string difficultyInput)
        {
            return !InputValidator.IsValidBoardSizeInput(difficultyInput);
        }

        public void Play()
        {
            while (BoardIsNotRevealed())
            {
                var newLocation = CreateLocationBasedOnInput();
                RevealTheSquareIfLocationIsOnBoard(newLocation);
                CheckIfGameIsOver();

                _output.Write(GameInstruction.DisplayCurrentBoardMessage);
                DisplayBoard();
            }
        }


        private void CheckIfGameIsOver()
        {
            if (WinLoseChecker.IsLosingConditionWhenOneBlackHoleIsRevealed(Board))
            {
                _output.Write(GameInstruction.GameOverMessage);
                Board.RevealAllSquares();
                State = GameState.Lose;
                _output.Write(GameInstruction.ResultMessage + State);
            }
            else if (WinLoseChecker.IsWinningConditionWhenAllHintsAreRevealed(Board))
            {
                _output.Write(GameInstruction.GameOverMessage);
                Board.RevealAllSquares();
                State = GameState.Win;
                _output.Write(GameInstruction.ResultMessage + State);
            } 
        }

        private void RevealTheSquareIfLocationIsOnBoard(Location newLocation)
        {
            if (Board.HasLocation(newLocation))
            {
                Board.RevealOneSquare(newLocation);
            }
            else
            {
                _output.Write(GameInstruction.WrongLocationMessage);
            }
        }

        private Location CreateLocationBasedOnInput()
        {
            var locationInput = _input.Ask(GameInstruction.InputLocationValueMessage);
            while (LocationInputIsNotValid(locationInput))
            {
                _output.Write(GameInstruction.InputNotValidMessage);
                locationInput = _input.Ask(GameInstruction.InputLocationValueMessage);
            }

            var newLocation = InputParser.CreateLocationBasedOnInput(locationInput);
            return newLocation;
        }

        private static bool LocationInputIsNotValid(string locationInput)
        {
            return !InputValidator.IsValidLocationInput(locationInput);
        }

        private bool BoardIsNotRevealed()
        {
            return !Board.IsRevealed;
        }
    }
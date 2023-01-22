using BlackHolesSweeper;
using BlackHolesSweeper.Helpers;
using BlackHoleSweeper.Tests.Helpers;
using Xunit;

namespace BlackHoleSweeper.Tests;

    public class WinLoseCheckerTest
    {
        [Fact]
        public void IsWinningConditionShould_ReturnTrue_WhenAllHintsOnBoardAreRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var blackHoleGenerator = new MockBlackHolesGenerator();
            blackHoleGenerator.PlaceBlackHoles(2, board);
            var bottomLeft = new Location(1,0);
            var bottomRight = new Location(1,1);
            var hintOne = board.GetSquare(bottomLeft);
            var hintTwo = board.GetSquare(bottomRight);
            hintOne.Reveal();
            hintTwo.Reveal();
            var result = WinLoseChecker.IsWinningConditionWhenAllHintsAreRevealed(board);
            Assert.True(result);
        }
        
        [Fact]
        public void IsWinningConditionShould_ReturnFalse_WhenOneHintsOnBoardIsRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var blackHoleGenerator = new MockBlackHolesGenerator();
            blackHoleGenerator.PlaceBlackHoles(2, board);
            var bottomLeft = new Location(1,0);
            var hintOne = board.GetSquare(bottomLeft);
            hintOne.Reveal();
            var result = WinLoseChecker.IsWinningConditionWhenAllHintsAreRevealed(board);
            Assert.False(result);
        }
        
        [Fact]
        public void IsLosingConditionShould_ReturnTrue_WhenOneBlackHoleOnBoardAreRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var blackHoleGenerator = new MockBlackHolesGenerator();
            blackHoleGenerator.PlaceBlackHoles(2, board);
            var topLeft = new Location(0,0);
            var blackHoleOne = board.GetSquare(topLeft);
            blackHoleOne.Reveal();
            var result = WinLoseChecker.IsLosingConditionWhenOneBlackHoleIsRevealed(board);
            Assert.True(result);
        }
        
        [Fact]
        public void IsLosingConditionShould_ReturnFalse_WhenNoBlackHoleOnBoardIsRevealed()
        {
            var board = Board.CreateEmptyBoard(2);
            var blackHoleGenerator = new MockBlackHolesGenerator();
            blackHoleGenerator.PlaceBlackHoles(2, board);
            var result = WinLoseChecker.IsLosingConditionWhenOneBlackHoleIsRevealed(board);
            Assert.False(result);
        }
    }

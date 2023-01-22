using BlackHolesSweeper;
using BlackHolesSweeper.ConsoleWrapper;
using BlackHolesSweeper.Helpers.BlackHoleGenerator;

var input = new ConsoleInput();
var output = new ConsoleOutput();
var blackHolesGenerator = new RandomBlackHolesGenerator();
var game = new Game(input, output, blackHolesGenerator);
           
game.CreateBoard();
game.Play();
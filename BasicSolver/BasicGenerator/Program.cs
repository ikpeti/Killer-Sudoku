using BasicGenerator;

using BasicSolver;

using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddScoped<ISudokuBoard, SudokuBoard>();
services.AddScoped<ISudokuGenerator, SudokuGenerator>();

((ISudokuGenerator)ActivatorUtilities.CreateInstance(services.BuildServiceProvider(), typeof(SudokuGenerator))).Generate();
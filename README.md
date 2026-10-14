# Hangman

A simple console-based Hangman game where the player guesses a film title one letter at a time.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Run the game

Open a terminal in the project folder and run:

```bash
dotnet run
```

Alternatively, build the project first and then run it:

```bash
dotnet build
dotnet run --no-build
```

## How to play

1. Enter your name when prompted.
2. Guess one letter at a time to uncover the film title.
3. You can make up to six incorrect guesses.
4. After each round, choose to play again, view the session's game statistics, or quit.

The available film titles are defined in `Services/FilmRepository.cs`.

## Project structure

- `Models/` — game state and completed-game records.
- `Services/` — game flow, film selection, and game history.
- `UI/` — console display and input validation.
- `Program.cs` — application entry point.

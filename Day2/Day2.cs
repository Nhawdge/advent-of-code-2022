using System.Data;
public static class Day2 {
    public static void SolvePart1() {
        var file = File.ReadAllLines("Day2\\input.txt");
        var score = 0;
        foreach (var line in file) {
            var opponent = line.Split(' ') [0]
            switch {
                "A" => Move.Rock, "B" => Move.Paper, "C" => Move.Scissor, _ =>
                throw new Exception("Invalid move")
            };
            var player = line.Split(' ') [1]
            switch {
                "X" => Move.Rock, "Y" => Move.Paper, "Z" => Move.Scissor, _ =>
                throw new Exception("Invalid move")
            };

            var isDraw = opponent == player;
            if (isDraw) {
                score += 3;
            }
            if (opponent == Move.Rock && player == Move.Paper) {
                score += 6;
            }
            if (opponent == Move.Paper && player == Move.Scissor) {
                score += 6;
            }
            if (opponent == Move.Scissor && player == Move.Rock) {
                score += +6;
            }
            score += player
            switch {
                Move.Rock => 1, Move.Paper => 2, Move.Scissor => 3, _ =>
                throw new Exception("Invalid move")
            };

        }
        Console.WriteLine($"Score: {score}");
    }

    public static void SolvePart2() {
        var file = File.ReadAllLines("Day2\\input.txt");
        var score = 0;
        foreach (var line in file) {
            var opponent = line.Split(' ') [0]
            switch {
                "A" => Move.Rock, "B" => Move.Paper, "C" => Move.Scissor, _ =>
                throw new Exception("Invalid move")
            };
            var result = line.Split(' ') [1]
            switch {
                "X" => Result.Lose, "Y" => Result.Draw, "Z" => Result.Win, _ =>
                throw new Exception("Invalid move")
            };
            Move player;
            if (result == Result.Draw) {
                score += 3;
                player = opponent;
            } else if (result == Result.Win) {
                score += +6;
                player = opponent
                switch {
                    Move.Rock => Move.Paper, Move.Paper => Move.Scissor, Move.Scissor => Move.Rock, _ =>
                    throw new Exception("Invalid move")
                };
            } else {
                player = opponent
                switch {
                    Move.Rock => Move.Scissor, Move.Paper => Move.Rock, Move.Scissor => Move.Paper, _ =>
                    throw new Exception("Invalid move")
                };
            }

            score += player
            switch {
                Move.Rock => 1, Move.Paper => 2, Move.Scissor => 3, _ =>
                throw new Exception("Invalid move")
            };

        }
        Console.WriteLine($"Score: {score}");
    }

    public enum Move {
        Rock,
        Paper,
        Scissor
    }
    public enum Result {
        Win,
        Lose,
        Draw
    }
}
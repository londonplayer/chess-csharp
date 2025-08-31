
using System;

public enum WhitePiecesEnum 
{	
	WhiteKing = ♔,
	WhiteQueen = ♕,
	WhiteRook = ♖,
	WhiteBishop = ♗,
	WhiteKnight = ♘,
	WhitePawn = ♙,
}

public enum BlackPiecesEnum 
{	
	BlackKing = ♚,
	BlackQueen = ♛,
	BlackRook = ♜,
	BlackBishop = ♝,
	BlackKnight = ♞,
	BlackPawn = ♟,
}


class GameEngine
{
	static void StartGame()
	{
		Console.WriteLine("Game started!");

		// cria um objeto a partir da classe Board
		Board board = new Board();
		// chama o método DisplayBoard que foi contruído na classe Board
		board.CreateBoard();

		Piece rook1 = new Rook();

		rook1.Move();
		rook1.Capture();
		rook1.Check();

	}

    static void Main()
    {
        StartGame();
    }
}


public class Board
{
	private List<string> letterSquares = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H"};
	private List<string> numberSquares = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8"};

	public void CreateBoard()
	{	
		int totalLetterSquares = letterSquares.Count;
		int totalNumberSquares = numberSquares.Count;

		for (int i = 0; i < 10; i++)
		{
			// print the first row
			if (i == 0)
			{
				List<string> firtRow = new List<string>(letterSquares);

				firtRow.Insert(0, "  ");
				firtRow.Add("  ");

				string joinedFirstRow = string.Join("   ", firtRow);
				Console.WriteLine(joinedFirstRow);
			}

			// print the middle rows
			if (i != 0 && i != 9)
			{

				List<string> numberRow = new List<string>(numberSquares);

				numberRow.Insert(0, $"{numberRow.ElementAt(totalNumberSquares - i)} ");
				numberRow.Add($" {numberRow.ElementAt(numberRow.Count - i)}");

				for (int j = 1; j < numberRow.Count - 1; j++)
				{
					numberRow[j] = " ";
				}

				string joinedNumberRow = string.Join(" | ", numberRow);
				Console.WriteLine(joinedNumberRow);
			}
			
			// print the last row
			if (i == 9)
			{
				List<string> lastRow = new List<string>(letterSquares);

				lastRow.Insert(0, "  ");
				lastRow.Add("  ");

				string joinedLastRow = string.Join("   ", lastRow);
				Console.WriteLine(joinedLastRow);
			}
		}
	}

	public void DispalyBoard() 
	{
		Console.WriteLine("Display Board");
	}
}

public class Piece
{
	// private string color = "white";
	// private string type = "pawn";

	public virtual void Move()
	{
		Console.WriteLine("Piece moved!");
	}

	public virtual void Capture()
	{
		Console.WriteLine("Piece ___ captured by ___!");
	}

	public virtual void Check()
	{
		Console.WriteLine("Piece checked the ___ king!");
	}
}

class Rook : Piece
{ 
	public override void Move()
	{
		Console.WriteLine("Rook moved!");
	}
	public override void Capture()
	{
		Console.WriteLine("Rook captured!");
	}

	public override void Check()
	{
		Console.WriteLine("Rook checked the king!");
	}

}
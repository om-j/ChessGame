﻿using System.Data;

namespace ChessLogic
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen; //This line defines a property `Type` in a class that overrides Piece class property to always return `PieceType.Bishop`.
        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.NorthWest,
            Direction.SouthWest
        };
         
        public override Player Color { get; }
        public Queen(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to)); //  The method returns an enumerable collection of `NormalMove` objects, representing all possible moves from the given position by transforming valid destination positions generated by `MovePositionsInDirs`.
        }
    }
}

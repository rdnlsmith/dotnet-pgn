using System;
using DotnetPgn.Models;

namespace DotnetPgn
{
    public static class PieceParser
    {
        public static Piece ParsePiece(string sanPiece)
        {
            return sanPiece switch
            {
                "P" or "p" or "" => Piece.Pawn,
                "N" or "n" => Piece.Knight,
                "B" or "b" => Piece.Bishop,
                "R" or "r" => Piece.Rook,
                "Q" or "q" => Piece.Queen,
                "K" or "k" => Piece.King,
                _ => throw new ArgumentException($"'{sanPiece} is not a valid piece.'"),
            };
        }
    }
}

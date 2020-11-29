using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotnetPgn.Models;
using Xunit;

namespace DotnetPgn.Test
{
    public class TokenizerTest
    {
        [Fact]
        public void ParseMovesTest()
        {
            var moveText = "1. e4 e5 2. Nf3 Qe7 3. d3 h5\n";
            IEnumerable<HalfMove> halfmoves;

            #region Expected
            List<HalfMove> expectedHalfMoves = new()
            {
                new HalfMove
                {
                    MoveNumber = 1,
                    Player = Player.White,
                    Piece = Piece.Pawn,
                    TargetSquare = new Square('e', 4),
                },
                new HalfMove
                {
                    MoveNumber = 1,
                    Player = Player.Black,
                    Piece = Piece.Pawn,
                    TargetSquare = new Square('e', 5),
                },
                new HalfMove
                {
                    MoveNumber = 2,
                    Player = Player.White,
                    Piece = Piece.Knight,
                    TargetSquare = new Square('f', 3),
                },
                new HalfMove
                {
                    MoveNumber = 2,
                    Player = Player.Black,
                    Piece = Piece.Queen,
                    TargetSquare = new Square('e', 7),
                },
                new HalfMove
                {
                    MoveNumber = 3,
                    Player = Player.White,
                    Piece = Piece.Pawn,
                    TargetSquare = new Square('d', 3),
                },
                new HalfMove
                {
                    MoveNumber = 3,
                    Player = Player.Black,
                    Piece = Piece.Pawn,
                    TargetSquare = new Square('h', 5),
                },
            };
            #endregion

            halfmoves = Tokenizer.ParseMoves(moveText);

            for (int i = 0; i < expectedHalfMoves.Count(); i++)
            {
                HalfMove generated = halfmoves.ElementAtOrDefault(i);
                HalfMove expected = expectedHalfMoves.ElementAtOrDefault(i);

                Assert.NotNull(generated);
                Assert.NotNull(expected);
                Assert.Equal(expected.MoveNumber, generated.MoveNumber);
                Assert.Equal(expected.Player, generated.Player);
                Assert.Equal(expected.Piece, generated.Piece);
                Assert.Equal(expected.TargetSquare, generated.TargetSquare);
            }
        }
    }
}

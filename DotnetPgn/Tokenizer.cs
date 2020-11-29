using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DotnetPgn.Models;

namespace DotnetPgn
{
    public static class Tokenizer
    {
        private static readonly Regex s_halfMoveRegex =
            new(@"([KQRBNP]?)([a-h]?[1-8]?)(x?)([a-h][1-8])([+#]?)");

        public static IEnumerable<HalfMove> ParseMoves(string moveText)
        {
            StringBuilder currToken = new();
            char[] moveTextChars = moveText.ToCharArray();
            int moveNumber = 1;
            Player currPlayer = Player.White;

            for (int i = 0; i < moveTextChars.Length; i++)
            {
                char nextChar = moveTextChars[i];

                if (nextChar is ' ' or '\t' or '\n' or '\r')
                {
                    // We should have either a move number or a complete halfmove.
                    string token = currToken.ToString();
                    currToken.Clear();
                    Match match = s_halfMoveRegex.Match(token);

                    if (!match.Success)
                    {
                        Console.WriteLine($"Unrecognized token: `{token}`");
                        Console.WriteLine();
                        continue;
                    }

                    Console.WriteLine($"Recognized token: {token}");
                    Console.WriteLine($"Matching groups: ({match.Groups[1].Value})" +
                        $"({match.Groups[2].Value})({match.Groups[3].Value})({match.Groups[4].Value})" +
                        $"({match.Groups[5].Value})");

                    var move = new HalfMove
                    {
                        MoveNumber = moveNumber,
                        Player = currPlayer,
                        Piece = PieceParser.ParsePiece(match.Groups[1].Value),
                        TargetSquare = new Square(match.Groups[4].Value[0], Convert.ToInt32(Char.GetNumericValue(match.Groups[4].Value[1]))),
                    };

                    Console.WriteLine($"Halfmove: {move.MoveNumber}. {move.Player} {move.Piece} from {move.SourceSquare} to {move.TargetSquare}");
                    Console.WriteLine();

                    if (currPlayer == Player.White)
                    {
                        currPlayer = Player.Black;
                    }
                    else
                    {
                        currPlayer = Player.White;
                        moveNumber++;
                    }

                    yield return move;
                }
                else
                {
                    currToken.Append(nextChar);
                }
            }
        }
    }
}
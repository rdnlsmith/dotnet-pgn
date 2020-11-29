using System.Linq;
using DotnetPgn.Models;
using Xunit;

namespace DotnetPgn.Test
{
    public class PieceParserTest
    {
        [Theory]
        [InlineData("K", Piece.King)]
        [InlineData("Q", Piece.Queen)]
        public void ParsePieceTest(string input, Piece expectedOutput)
        {
            Assert.Equal(expectedOutput, PieceParser.ParsePiece(input));
        }
    }
}

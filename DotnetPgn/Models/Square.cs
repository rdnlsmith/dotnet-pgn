using System;

namespace DotnetPgn.Models
{
    public record Square
    {
        public char Rank { get; }
        public int File { get; }

        public Square(char rank, int file)
        {
            if (rank < 'a' || rank > 'h')
                throw new ArgumentException($"Invalid rank '{rank}'.");

            if (file < 1 || file > 8)
                throw new ArgumentException($"Invalid file '{file}'.");

            Rank = rank;
            File = file;
        }
    }
}
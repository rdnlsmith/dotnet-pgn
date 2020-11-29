namespace DotnetPgn.Models
{
    public record HalfMove
    {
        public int MoveNumber {get; init;}
        public Player Player { get; init; }
        public Piece Piece { get; init; }
        public Square SourceSquare { get; init; }
        public Square TargetSquare { get; init; }
    }
}
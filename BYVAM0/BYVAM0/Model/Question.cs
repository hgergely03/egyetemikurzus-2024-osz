namespace BYVAM0.Model
{
    public record Question
    {
        public required string Text { get; init; }
        public required int Weight { get; init; }
    };
}

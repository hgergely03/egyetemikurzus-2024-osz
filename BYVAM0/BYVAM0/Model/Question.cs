namespace BYVAM0.Model
{
    internal record Question
    {
        public required string Text { get; init; }
        public required int Weight { get; init; }
    };
}

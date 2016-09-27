namespace Level
{
    public interface ILevel
    {
        bool HasWinner { get; }
        SortColor Winner { get; }
    }
}
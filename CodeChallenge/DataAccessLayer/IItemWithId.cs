namespace CodeChallenge
{
    /// <summary>
    /// Interface for data, in order to expose it's ID.
    /// </summary>
    public interface IItemWithId
    {
        int Id { get; set; }
    }
}
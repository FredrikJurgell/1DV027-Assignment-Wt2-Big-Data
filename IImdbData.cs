namespace assignment_wt2_oauth
{
    /// <summary>
    /// This interface implements the IImdbData interface to provide access to IMDB data.
    /// </summary>
     public interface IImdbData
    {
        /// <summary>
        /// Retrieves data from IMDB.
        /// </summary>
        /// <returns>An asynchronous task that returns an IEnumerable of Data objects.</returns>
        Task<IEnumerable<Data>> GetData();
    }
}

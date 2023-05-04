namespace assignment_wt2_oauth
{
    /**
        This interface defines the method signature for retrieving data from IMDB.
    */
     public interface IImdbData
    {
        /**
            This method retrieves data from IMDB.
        */
        Task<IEnumerable<Data>> GetData();
    }
}

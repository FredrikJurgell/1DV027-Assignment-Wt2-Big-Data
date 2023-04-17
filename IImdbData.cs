using System;

namespace assignment_wt2_oauth
{
     public interface IImdbData
    {
        Task<IEnumerable<Data>> GetData();
    }
}

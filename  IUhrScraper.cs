using System;

namespace assignment_wt2_oauth
{
    public interface  IUhrScraper
    {
        public Task<IEnumerable<Data>> GetData();
    }
}

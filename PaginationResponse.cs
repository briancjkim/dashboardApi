using System.Collections.Generic;
using System.Linq;

namespace coreangular.api
{
    //collectino of sometype 
    public class PaginationResponse<T>
    {
        public PaginationResponse(IEnumerable<T> data, int i, int len)
        {
            Data = data.Skip((i - 1) * len).Take(len).ToList();
            Total = data.Count();
        }

        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
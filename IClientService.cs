using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageGenerator
{
    public interface IClientService<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAll(string endPoint);
    }
}
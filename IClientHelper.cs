using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageGenerator
{
    public interface IClientHelper
    {
        Task<string> GetJson(string path);
    }
}
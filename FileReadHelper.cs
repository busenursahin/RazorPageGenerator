using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace RazorPageGenerator
{
    public class FileReadHelper : IClientHelper
    {
        public async Task<string> GetJson(string path)
        {
            string readText = File.ReadAllText(path);

            return readText;

        }
    }
}
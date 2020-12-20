using System;
using Minify.Interfaces;

namespace Minify
{
    public class TokenGenerator : ITokenGenerator
    {
        public string Generate()
        {
            string key = Guid.NewGuid().ToString();
            return key;
        }
    }
}
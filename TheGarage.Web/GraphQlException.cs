using System;

namespace TheGarage.Web
{
    public class GraphQlException : ApplicationException
    {
        public GraphQlException(string message) : base(message)
        {
        }
    }
}

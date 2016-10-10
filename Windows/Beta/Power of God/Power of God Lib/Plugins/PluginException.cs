using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God_Lib.Plugins
{
    public class PluginException : Exception
    {
        public PluginException()
        {
        }

        public PluginException(string message) : base(message)
        {
        }

        public PluginException(string message, Exception inner) : base(message, inner)
        {
        }

        public PluginException(Exception inner) : base("", inner)
        {
        }
    }
}

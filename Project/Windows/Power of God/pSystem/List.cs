using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God.pSystem
{
    public class List<T> : System.Collections.Generic.List<T>
    {
        /// <summary>
        /// Performs the same function as ElementAt. All this seeks to do is optimize when converting from java to C#
        /// </summary>
        /// <param name="index">The item index in the list</param>
        /// <returns></returns>
        public T get(int index)
        {
            return this.ElementAt(index);
        }
    }
}

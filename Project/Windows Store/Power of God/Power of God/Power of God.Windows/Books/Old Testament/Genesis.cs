using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_of_God.Books.Old_Testament
{
    public class Genesis : Book
    {
        public override string Name { get; set; } = "Genesis";

        public override int BookNum { get; set; } = 1;

        public override int ChapterCount { get; set; } = 50;
    }
}

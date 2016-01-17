using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Galatians : Book
    {
        public override string Name { get; set; } = "Galatians";

        public override int BookNum { get; set; } = 48;

        public override int ChapterCount { get; set; } = 6;
    }
}

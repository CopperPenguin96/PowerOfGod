using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.Old_Testament
{
    public class Chronicles1 : Book
    {
        public override string Name { get; set; } = "1 Chronicles";

        public override int BookNum { get; set; } = 13;

        public override int ChapterCount { get; set; } = 29;
    }
}

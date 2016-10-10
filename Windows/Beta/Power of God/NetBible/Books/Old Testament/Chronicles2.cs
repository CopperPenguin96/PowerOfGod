using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.Old_Testament
{
    public class Chronicles2 : Book
    {
        public override string Name { get; set; } = "2 Chronicles";

        public override int BookNum { get; set; } = 14;

        public override int ChapterCount { get; set; } = 36;
    }
}

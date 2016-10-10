using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Corinthians2 : Book
    {
        public override string Name { get; set; } = "2 Corinthians";

        public override int BookNum { get; set; } = 47;

        public override int ChapterCount { get; set; } = 13;
    }
}

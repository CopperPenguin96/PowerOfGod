using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Ephesians : Book
    {
        public override string Name { get; set; } = "Ephesians";

        public override int BookNum { get; set; } = 49;

        public override int ChapterCount { get; set; } = 6;
    }
}

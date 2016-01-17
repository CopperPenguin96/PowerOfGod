using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Philippians : Book
    {
        public override string Name { get; set; } = "Philippians";

        public override int BookNum { get; set; } = 50;

        public override int ChapterCount { get; set; } = 4;
    }
}

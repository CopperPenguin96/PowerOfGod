using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Thessalonians1 : Book
    {
        public override string Name { get; set; } = "1 Thessalonians";

        public override int BookNum { get; set; } = 52;

        public override int ChapterCount { get; set; } = 5;
    }
}

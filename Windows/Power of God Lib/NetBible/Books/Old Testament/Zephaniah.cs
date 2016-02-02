using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.Old_Testament
{
    public class Zephaniah : Book
    {
        public override string Name { get; set; } = "Zephaniah";

        public override int BookNum { get; set; } = 36;

        public override int ChapterCount { get; set; } = 3;
    }
}

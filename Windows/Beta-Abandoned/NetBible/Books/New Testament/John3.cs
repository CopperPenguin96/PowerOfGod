using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class John3 : Book
    {
        public override string Name { get; set; } = "3 John";

        public override int BookNum { get; set; } = 64;

        public override int ChapterCount { get; set; } = 1;
    }
}

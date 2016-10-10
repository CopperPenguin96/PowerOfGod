using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class John : Book
    {
        public override string Name { get; set; } = "John";

        public override int BookNum { get; set; } = 43;

        public override int ChapterCount { get; set; } = 21;
    }
}

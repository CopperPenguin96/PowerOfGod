using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Peter1 : Book
    {
        public override string Name { get; set; } = "1 Peter";

        public override int BookNum { get; set; } = 60;

        public override int ChapterCount { get; set; } = 5;
    }
}

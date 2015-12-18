using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Romans : Book
    {
        public override string Name { get; set; } = "Romans";

        public override int BookNum { get; set; } = 45;

        public override int ChapterCount { get; set; } = 16;
    }
}

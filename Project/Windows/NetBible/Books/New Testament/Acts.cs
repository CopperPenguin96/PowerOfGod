using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.New_Testament
{
    public class Acts : Book
    {
        public override string Name { get; set; } = "Acts";

        public override int BookNum { get; set; } = 44;

        public override int ChapterCount { get; set; } = 28;
    }
}

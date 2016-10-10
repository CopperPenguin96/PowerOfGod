using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.Old_Testament
{
    public class Kings1 : Book
    {
        public override string Name { get; set; } = "1 Kings";

        public override int BookNum { get; set; } = 11;

        public override int ChapterCount { get; set; } = 21;
    }
}

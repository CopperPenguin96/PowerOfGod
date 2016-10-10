﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.Old_Testament
{
    public class Ecclesiastes : Book
    {
        public override string Name { get; set; } = "Ecclesiastes";

        public override int BookNum { get; set; } = 21;

        public override int ChapterCount { get; set; } = 12;
    }
}
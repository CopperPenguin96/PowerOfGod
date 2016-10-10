﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBible.Books;

namespace NetBible.Books.Old_Testament
{
    public class Micah : Book
    {
        public override string Name { get; set; } = "Micah";

        public override int BookNum { get; set; } = 33;

        public override int ChapterCount { get; set; } = 7;
    }
}
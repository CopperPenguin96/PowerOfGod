using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Power_of_God.Books.New_Testament;
using Power_of_God.Books.Old_Testament;

namespace Power_of_God.Books
{
    public class Bible
    {
        public static List<Book> OldTestament = new List<Book>()
        {
            new Genesis(), new Exodus(), new Leviticus(), new Numbers(), new Deuteronomy(),
            new Joshua(), new Judges(), new Ruth(), new Samuel1(), new Samuel1(),
            new Kings1(), new Kings2(), new Chronicles1(), new Chronicles2(), new Ezra(),
            new Nehemiah(), new Esther(), new Job(), new Psalms(), new Proverbs(),
            new Ecclesiastes(), new SongOfSolomon(), new Isaiah(), new Jeremiah(), new Lamentations(),
            new Ezekiel(), new Daniel(), new Hosea(), new Joel(), new Amos(),
            new Obadiah(), new Jonah(), new Micah(), new Nahum(), new Habakkuk(),
            new Zephaniah(), new Haggai(), new Zechariah(), new Malachi()
        };

        public static List<Book> NewTestament = new List<Book>()
        {
            new Matthew(), new Mark(), new Luke(), new John(), new Acts(), new Romans(),
            new Corinthians1(), new Corinthians2(), new Galatians(), new Ephesians(), new Philippians(),
            new Colossians(), new Thessalonians1(), new Thessalonians2(), new Timothy1(),
            new Timothy2(), new Titus(), new Philemon(), new Hebrews(), new James(), new Peter1(), new Peter2(),
            new John1(), new John2(), new John3(), new Jude(), new Revelation()
        };

        public static List<Book> AllBooks()
        {   
            return OldTestament.Concat(NewTestament).ToList();
        }
    }
}

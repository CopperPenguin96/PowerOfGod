package NetBible.Bible;

public enum BookList {
	Genesis, Exodus, Leviticus, Numbers, Deuteronomy,
    Joshua, Judges, Ruth, Samuel1, Samuel2, Kings1, Kings2,
    Chronicles1, Chronicles2, Ezra, Nehemiah, Esther, Job,
    Psalms, Proverbs, Ecclesiastes, SongofSolomon,
    Isaiah, Jeremiah, Lamentations, Ezekiel, Daniel,
    Hosea, Joel, Amos, Obadiah, Jonah, Micah, Nahum,
    Habakkuk, Zephaniah, Haggai, Zechariah, Malachi,

    

    Matthew, Mark, Luke, John, Acts, Romans, Corinthians1,
    Corinthians2, Galatians, Ephesians, Philippians,
    Colossians, Thessalonians1, Thessalonians2, Timothy1,
    Timothy2, Titus, Philemon, Hebrews, James, Peter1,
    Peter2, John1, John2, John3, Jude, Revelation;
    
    public static BookList fromInteger(int x) {
        switch(x) {
        // Old Testament
        // Beginnings of Promise/Law
        case 0: return Genesis;
        case 1: return Exodus;
        case 2: return Leviticus;
        case 3: return Numbers;
        case 4: return Deuteronomy;
        // Promise/Law
        case 5: return Joshua;
        case 6: return Judges;
        case 7: return Ruth;
        case 8: return Samuel1;
        case 9: return Samuel2;
        case 10: return Kings1;
        case 11: return Kings2;
        case 12: return Chronicles1;
        case 13: return Chronicles2;
        case 14: return Ezra;
        case 15: return Nehemiah;
        case 16: return Esther;
        case 17: return Job;
        case 18: return Psalms;
        case 19: return Proverbs;
        case 20: return Ecclesiastes;
        case 21: return SongofSolomon;
        case 22: return Isaiah;
        case 23: return Jeremiah;
        case 24: return Lamentations;
        case 25: return Ezekiel;
        case 26: return Daniel;
        case 27: return Hosea;
        case 28: return Joel;
        case 29: return Amos;
        case 30: return Obadiah;
        case 31: return Jonah;
        case 32: return Micah;
        case 33: return Nahum;
        case 34: return Habakkuk;
        case 35: return Zephaniah;
        case 36: return Haggai;
        case 37: return Zechariah;
        case 38: return Malachi;
        // New Testament
        case 39: return Matthew;
        case 40: return Mark;
        case 41: return Luke;
        case 42: return John;
        case 43: return Acts;
        // Pauline
        case 44: return Romans;
        case 45: return Corinthians1;
        case 46: return Corinthians2;
        case 47: return Galatians;
        case 48: return Ephesians;
        case 49: return Philippians;
        case 50: return Colossians;
        case 51: return Thessalonians1;
        case 52: return Thessalonians2;
        case 53: return Timothy1;
        case 54: return Timothy2;
        case 55: return Titus;
        case 56: return Philemon;
        // Kingdom
        case 57: return Hebrews;
        case 58: return James;
        case 59: return Peter1;
        case 60: return Peter2;
        case 61: return John1;
        case 62: return John2;
        case 63: return John3;
        case 64: return Jude;
        // Prophecy
        case 65: return Revelation;
        }
		return null;
    }
}

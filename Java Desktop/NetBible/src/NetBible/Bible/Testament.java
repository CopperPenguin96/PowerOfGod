package NetBible.Bible;

public enum Testament {
	New,
	Old;
	
	public static Testament fromInteger(int x) {
        switch(x) {
        case 0:
            return New;
        case 1:
            return Old;
        }
        return null;
    }
}

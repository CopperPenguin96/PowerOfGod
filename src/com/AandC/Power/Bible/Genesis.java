package com.AandC.Power.Bible;

public class Genesis
{
	public static String verse(int chap, int v) {
		SetUp();
		return Text[chap][v];
	}
	public static String[][] Text = new String[50][40];
	static void SetUp() {
		Text[1][1] = "In the beginning God created the heaven and the earth.";
		Text[1][2] = "And the earth was without form, and void, and darkness
	}
}

package network;

import java.io.Serializable;

public class DataTest implements Serializable {
	int i;
	String s;
	boolean b;
	byte y;
	
	public DataTest(int i, String s, boolean b, byte y) {
		this.i = i;
		this.s = s;
		this.b = b;
		this.y = y;
	}

	public void show() {
		System.out.println(i + ", " + s + ", " + b + ", " + y);
	}
}

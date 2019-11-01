package network;

import java.io.Serializable;

public class DataTest implements Serializable {
	int i;
	String s;
	boolean b;
	byte y;
	D d;
	
	public DataTest(int i, String s, boolean b, byte y, D d) {
		this.i = i;
		this.s = s;
		this.b = b;
		this.y = y;
		this.d = d;
	}

	public void show() {
		System.out.println(i + ", " + s + ", " + b + ", " + y + ", " + d.d);
	}
}
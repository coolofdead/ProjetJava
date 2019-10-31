package utility;

public class Vector {

	public final static Vector zero = new Vector(0, 0);
	
	public float x;
	public float y;
	
	public Vector(float x, float y) {
		this.x = x;
		this.y = y;
	}
	
	@Override
	public String toString() {
		return "(x: " + x + ", y: " + y + ")";
	}
}

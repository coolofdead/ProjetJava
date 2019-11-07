package _sandbox;

import java.util.Timer;

public class MainSandbox {
	
	public static void main(String[] args) {
		System.out.println("sandbox main");
		
		Timer timer = new Timer();
		timer.schedule(new LoopTimer(), 500, 0);
	}
}

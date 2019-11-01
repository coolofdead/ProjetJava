package sandbox;

import java.util.concurrent.TimeUnit;

import javax.swing.JFrame;

public class GameLoop {
	static final int FRAME_AVG = 60;

	public GameLoop () {
		boolean debug = false;
		
		JFrame j = new JFrame("Titre");
		j.setVisible(true);
		j.setSize(500, 500);
		j.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		float frames;
		long oldTime = System.currentTimeMillis();
		long now;
		
		while (true) {
			
			long delay = (long)(Math.random()+10);
			try {
				TimeUnit.MILLISECONDS.sleep(delay);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			
			now = System.currentTimeMillis();		
			
			float delta = now - oldTime;
			
			if (delta < 1000 / FRAME_AVG) {
				while (oldTime + 1000 / FRAME_AVG > System.currentTimeMillis());
				delta = System.currentTimeMillis() - oldTime;
			}
			
			frames = 1 / (delta / 1000);
	
			oldTime = now;
			
			if (debug) {
				System.out.println("old: " + oldTime + ", now: " + now);
				System.out.println(delta);
				System.out.println(frames);
			}
		}
	}
}

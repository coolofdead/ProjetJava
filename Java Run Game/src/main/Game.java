package main;

import java.util.concurrent.TimeUnit;

import javax.swing.JFrame;

public class Game {
	static final int FRAME_AVG = 60;

	public Game () {
		boolean debug = false;
		
		Canvas c = new Canvas();
		
		JFrame j = new JFrame("Titre");
		j.setVisible(true);
		j.setSize(500, 500);
		j.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		j.add(c);
		
		float frames;
		long oldTime = System.currentTimeMillis();
		long now;
		
		while (true) {
			c.repaint();
			
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

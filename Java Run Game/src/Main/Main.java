package Main;

import java.awt.Graphics;
import java.util.concurrent.TimeUnit;

import javax.swing.JFrame;
import javax.swing.JPanel;


public class Main {

	public static void main(String[] args) {
		boolean debug = true;
		
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

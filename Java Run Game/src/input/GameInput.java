package input;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import game.Game;
import game.Main;

public class GameInput {
	
	public void init() {
		new Thread() {
			KeyListener k = new KeyListener() {
				
				@Override
				public void keyTyped(KeyEvent e) {
					
				}
				
				@Override
				public void keyReleased(KeyEvent e) {
					
				}
				
				@Override
				public void keyPressed(KeyEvent e) {
					System.out.println(e.getKeyChar());
				}
			};
			
			@Override
			public void run() {
				Main.game.window.addKeyListener(this.k);
				while (true) {
					
				}
			}
		}.start();
	}
}

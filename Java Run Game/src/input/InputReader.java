package input;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import game.Game;
import game.Main;
import utility.Vector;

/*
 * Read les inputs
 * sub aux inputs
 * trigger l'event : OnInput
 */
public class InputReader extends Thread {
	
	private KeyListener k;
	private static PlayerBind[] playersInput = new PlayerBind[2];
	
	public InputReader() {
		playersInput[0] = new PlayerBind(1, 65, 38, 40, 37, 39);
		playersInput[1] = new PlayerBind(2, 90, 104, 101, 100, 102);
		
		this.k = new KeyListener() {
			@Override public void keyTyped(KeyEvent e) {}
			@Override public void keyReleased(KeyEvent e) {}
			@Override public void keyPressed(KeyEvent e) {
				for (PlayerBind p : InputReader.playersInput) {
					for (int input : p.getInputsKeyCode()) {
						if (input == e.getKeyCode()) {
							boolean btn = input == p.button;
							Vector v = new Vector(
									input == p.leftJoystick ? -1 : input == p.rightJoystick ? 1 : 0, 
									input == p.topJoystick ? 1 : input == p.botJoystick ? -1 : 0);
							
							InputEvent i = new InputEvent(p.id, btn, v);
							Game.inputManager.onGameInput(i);
						}
					}
				}
			}
		};
	}
	
	@Override
	public void run() {
		Main.game.window.addKeyListener(this.k);
		
		while (Main.game.isRunning) {
			// TODO update: use socket to read values from raspberry
		}
	}
}

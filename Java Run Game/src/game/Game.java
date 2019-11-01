package game;

import javax.swing.JFrame;

import input.InputManager;
import utility.Constant;

public class Game {
	
	public JFrame window;
	public static InputManager inputManager = new InputManager();
	
	public boolean isRunning = false;
	
	public Game() {
		isRunning = true;
		
		// TODO update: window en class Screen qui contient tout le setup dans une méthode init
		window = new JFrame(Constant.GAME_NAME);
		window.setVisible(true);
		window.setSize(Constant.GAME_WIDTH, Constant.GAME_HEIGHT);
		window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		inputManager.init();
	}
}

package game;

import javax.swing.JFrame;

import utility.Constant;

public class Game {
	
	public JFrame window;
	
	public Game() {
		window = new JFrame(Constant.GAME_NAME);
		window.setVisible(true);
		window.setSize(Constant.GAME_WIDTH, Constant.GAME_HEIGHT);
		window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
}

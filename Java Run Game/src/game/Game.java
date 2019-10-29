package game;

import javax.swing.JFrame;

import input.GameInput;

public class Game {
	
	private static JFrame game = new JFrame("Game");
	
	public Game() {
		game.setVisible(true);
		game.setSize(500, 500);
		game.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	
	public static void main(String[] args) {
		Game g = new Game();
		
		GameInput gi = new GameInput();
	}
	
	public static JFrame getGame() {
		return game;
	}
}

package game;

import input.InputManager;
import screen.Screen;
import utility.Initialisable;

public class Game implements Initialisable {
	
	public Screen screen;
	public static InputManager inputManager = new InputManager();
	
	public boolean isRunning = false;
	
	// instantie les objets 
	public Game() {
		this.isRunning = true;
		
		this.screen = new Screen();
	}

	@Override
	public void init() {
		// init les comp non static
		this.screen.init();
		
		// init les comp static
		inputManager.init();
	}
	
}

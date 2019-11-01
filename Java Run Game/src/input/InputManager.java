package input;

import java.util.ArrayList;

import _sandbox.PlayerController;
import utility.Initialisable;

public class InputManager implements Initialisable {
	
	private ArrayList<InputListener> listeners;
	private InputReader inputReader;
	
	@Override
	public void init() {
		this.listeners = new ArrayList<InputListener>();
		inputReader = new InputReader();
		inputReader.start();
		
		// TODO remove 
		addInputListener(new PlayerController());
	}
	
	public void clearListeners() {
		this.listeners.clear();
	}
	
	public void addInputListener(InputListener listener) {
		this.listeners.add(listener);
	}
	
	public void onGameInput(InputEvent e) {
		System.out.println("manager: player id=" + e.playerId);
		for(InputListener i : this.listeners) {
			i.OnInput(e);
		}
	}
}

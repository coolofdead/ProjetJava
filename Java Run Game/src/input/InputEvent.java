package input;

import utility.Vector;

public final class InputEvent {
	
	public boolean button;
	public Vector joystick;
	
	public int playerId;
	
	public InputEvent(int playerId, boolean button, Vector joystick) {
		this.playerId = playerId;
		this.button = button;
		this.joystick = joystick;
	}
}

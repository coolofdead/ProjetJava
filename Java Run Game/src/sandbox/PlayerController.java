package sandbox;

import input.InputEvent;
import input.InputListener;

public class PlayerController implements InputListener {

	@Override
	public void OnInput(InputEvent e) {
		System.out.println("Controller got: " + e.button + ", " + e.joystick.toString());
	}
}

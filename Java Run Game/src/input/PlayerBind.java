package input;

// TODO update: raspberry
public class PlayerBind {

	public int id;
	
	public int button;
	public int topJoystick;
	public int botJoystick;
	public int leftJoystick;
	public int rightJoystick;
	
	public PlayerBind(int id, int button, int topJoystick, int botJoystick, int leftJoystick, int rightJoystick) {
		this.id = id;
		this.button = button;
		this.topJoystick = topJoystick;
		this.botJoystick = botJoystick;
		this.leftJoystick = leftJoystick;
		this.rightJoystick = rightJoystick;
	}
	
	public int[] getInputsKeyCode() {
		return new int[] {button, topJoystick, botJoystick, leftJoystick, rightJoystick};
	}
}

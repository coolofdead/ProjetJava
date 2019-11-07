package screen;

import javax.swing.JFrame;

import utility.Constant;
import utility.Initialisable;

public class Screen implements Initialisable {

	private JFrame window;
	private Panel currentPanel;

	public JFrame getWindow() {
		return this.window;
	}
	
	public void changePanel(Panel newPanel) {
		for (PanelComponent c : this.currentPanel) {
			this.window.remove(c);
		}
		this.window.remove(this.currentPanel);
		
		this.currentPanel = newPanel;
		this.window.add(this.currentPanel);
		
		for (PanelComponent c : this.currentPanel) {
			this.window.add(c);
		}
	}
	
	@Override
	public void init() {
		this.window = new JFrame(Constant.GAME_NAME);
		this.window.setVisible(true);
		this.window.setSize(Constant.GAME_WIDTH, Constant.GAME_HEIGHT);
		this.window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		this.currentPanel = new Menu();
	}
}

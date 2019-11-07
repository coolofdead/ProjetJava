package screen;

import javax.swing.JComponent;
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
		for (JComponent c : this.currentPanel) {
			this.window.remove(c);
		}
		this.window.remove(this.currentPanel);
		
		this.currentPanel = newPanel;
		this.window.add(this.currentPanel);
		
		for (JComponent c : this.currentPanel) {
			this.window.add(c);
		}
	}
	
	@Override
	public void init() {
		this.window = new JFrame(Constant.GAME_NAME);
		this.window.setVisible(true);
		this.window.setSize(Constant.GAME_WIDTH, Constant.GAME_HEIGHT);
		this.window.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		this.currentPanel = new MenuPanel();
		
		// TODO create a method add the panel & their components to the window
		this.window.add(this.currentPanel);
		
		// TODO create a timer to redraw every X ticks
	}
}

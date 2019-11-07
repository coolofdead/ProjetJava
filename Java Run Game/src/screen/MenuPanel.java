package screen;

import java.awt.Graphics;

import javax.swing.JComponent;

import game.Main;
import input.InputEvent;

public class MenuPanel extends Panel implements input.InputListener {

	private static final long serialVersionUID = 4025229043284954823L;

	public MenuPanel() {
//		this.components = new JComponent[2];
//		this.components[0] = new PanelComponent();
		
		// TODO add an input listener to change menu when p1 click
	}

	@Override
	public void paint(Graphics g) {
		System.out.println("draw menu");
	}

	@Override
	public void OnInput(InputEvent e) {
		if (e.button && e.playerId == 1) {
			Main.game.screen.changePanel(new PauseMenuPanel());
		}
	}
	
}

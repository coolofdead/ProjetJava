package game;

import java.awt.Graphics;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JLabel;
import javax.swing.JPanel;

import utility.AssetLoader;

public class Main {

	public static Game game;
	
	public static void main(String[] args) {
		game = new Game();
		game.init();
		
		game.window.add(new JPanel() {
			private static final long serialVersionUID = 5998186084488982798L;
			
			@Override
			public void paint(Graphics g) {
				var img = AssetLoader.loadImage("pikachu.jpg");
				g.drawImage(img, 0, 0, this);
			}
		});
		
		Icon imgIcon = new ImageIcon("src/assets/pikachu.gif");
		JLabel label = new JLabel(imgIcon);
		game.window.add(label);
		
		ImageIcon i = new ImageIcon("src/assets/mushroom.ico");
		game.window.setIconImage(i.getImage());
		
		// TODO animate a sprite sheet
	}

}

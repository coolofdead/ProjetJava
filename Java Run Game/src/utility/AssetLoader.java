package utility;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

public class AssetLoader {

	private static final String ASSET_PATH = "src/assets/";
	
	// TODO créer une méthode T ou créer une méthode par type d'asset (jpg, gif, ico, mp4)
	public static BufferedImage loadImage(String name) {
		String assetPath = ASSET_PATH + name;
		
		BufferedImage img = null;
		try {
		    img = ImageIO.read(new File(assetPath));
	
		    if (img != null) {
		    	System.out.println("Succes !");		    	
		    }
		    else {
		    	System.out.println("Bad file type");
		    }
		
		} catch (IOException e) {
			System.out.println("Wrong path");
		}
		return img;
	}
	
}

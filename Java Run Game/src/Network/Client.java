package Network;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class Client {
	
	public static void main(String[] args) {
		try {
			Socket s =  new Socket("localhost", 4242);
			
			PrintWriter pr = new PrintWriter(s.getOutputStream());
			pr.println("Hello");
			pr.flush();
			
			InputStreamReader in = new InputStreamReader(s.getInputStream());
			BufferedReader bf = new BufferedReader(in);
			
			String str = bf.readLine();
			System.out.println("Server " + str);
		}
		catch (Exception e) {
			e.printStackTrace();
		}
	}
}

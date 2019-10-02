package Network;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
	public static void main(String[] args) {
		try { 
			ServerSocket ss =  new ServerSocket(4242);
			Socket s = ss.accept();
			
			System.out.println("Client connected");
			
			InputStreamReader in = new InputStreamReader(s.getInputStream());
			BufferedReader bf = new BufferedReader(in);
			
			String str = bf.readLine();
			System.out.println("Client " + str);
			
			PrintWriter pr = new PrintWriter(s.getOutputStream());
			pr.println("Pas de soucis poto");
			pr.flush();
		}
		catch (Exception e) {
			e.printStackTrace();
		}
	}
}

package network;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.ObjectOutputStream;
import java.io.PrintWriter;
import java.net.Socket;

public class Client {
	public static void main(String[] args) {
		try { 
			Socket s = new Socket("localhost", 4242);
			
//			PrintWriter pw = new PrintWriter(s.getOutputStream());
			
//			byte a = 0b00000001;
//			char b = 'a';
//			boolean c = true;
//			
//			pw.println("Hello " + a);
//			pw.println(b);
//			pw.println(c);
//			pw.flush();
			
			ObjectOutputStream os=new ObjectOutputStream(s.getOutputStream());
			
		    DataTest obj = new DataTest(3, "cc", true, (byte)0b00000011);
		    os.writeObject(obj);
			
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

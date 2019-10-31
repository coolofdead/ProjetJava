package network;

import java.io.ObjectOutputStream;
import java.net.Socket;

public class Client {
	public static void main(String[] args) {
		try { 
			Socket s = new Socket("localhost", 4242);
			
			ObjectOutputStream os=new ObjectOutputStream(s.getOutputStream());
			
			os.write(10);
			
		    DataTest obj1 = new DataTest(3, "cc", true, (byte)0b00000011, new D(4));
		    DataTest obj2 = new DataTest(9, "slt", false, (byte)0b00001111, new D(7));
		    
		    os.writeObject(obj1);
		    os.writeObject(obj2);
		    os.flush();
		    
		    os.close();
		}
		catch (Exception e) {
			e.printStackTrace();
		}
	}
}

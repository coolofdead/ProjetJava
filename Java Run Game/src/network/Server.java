package network;

import java.io.ObjectInputStream;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
	public static void main(String[] args) {
		new Thread(new Runnable(){
			@Override
			public void run() {
				try {
					ServerSocket ss =  new ServerSocket(4242);

					while (true) {
						Socket s = ss.accept();
						
						System.out.println("Client connected");
						
						ObjectInputStream os = new ObjectInputStream(s.getInputStream());
						
						// read 1 value (int)
						System.out.println(os.read());
						try {
							// read multiples objects (Serializable)
							while (true) {
							    DataTest obj = (DataTest)os.readObject();
								obj.show();
							}
						}
						catch (Exception e) {
							System.out.println("End of stream");
						}
					    
						System.out.println("Client socket closed");
					}
				}
				catch (Exception e) {
					e.printStackTrace();
				}
			}
		}).start();
	}
}

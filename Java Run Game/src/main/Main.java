package main;

public class Main {

	public static void main(String[] args) {

		class T extends Thread {
			private boolean isRunning = true;
			
			@Override
			public synchronized void run() {
				System.out.println("T1 start");
				while (isRunning) {
					System.out.println("T1 run");		
				}
				System.out.println("T1 stop");
			}
			
			public void exit() {
				isRunning = false;
			}
		}
		
		T t = new T();
		
		new Thread(new Runnable () {
			@Override
			public synchronized void run() {
				System.out.println("T2 start");
				long t = System.currentTimeMillis();
				while (t + 1 > System.currentTimeMillis()) {
					System.out.println("T2 run");
				}
				System.out.println("T2 stop");
			}
		}).start();
		
		t.start();
//		long old = System.currentTimeMillis();
//		while(old + 1 > System.currentTimeMillis());
		
		t.exit();
		
		// create 3 threads slave and 1 master
		// each slaves will wait X time then sleep
		// master w8 for slaves to sleep then awake them
	}
}

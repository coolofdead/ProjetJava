package sandbox;

public class ThreadTest {
	public ThreadTest () {
		new Thread(new Runnable() {

			private int c;
			
			@Override
			public synchronized void run() {
				boolean running = true;
				while (running) {
					c++;
					
					if (c == 100) {
						c = 0;
						try {
							System.out.println("Sleep " + System.currentTimeMillis());
							this.wait(1000);
							System.out.println("Awake " + System.currentTimeMillis());
							running = false;
						} catch (InterruptedException e) {
							e.printStackTrace();
						}
					}
				}
			}
			
		}).run();
	}
}

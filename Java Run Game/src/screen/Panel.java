package screen;

import java.util.Iterator;
import java.util.NoSuchElementException;

import javax.swing.JPanel;

public abstract class Panel extends JPanel implements Iterable<PanelComponent>, Iterator<PanelComponent> {

	private static final long serialVersionUID = 4025229043284954823L;

	protected PanelComponent[] components;
	
	protected int cursor;
	
	public boolean hasNext() {
		return this.cursor < this.components.length;
	}
	
	public PanelComponent next() {
        if(this.hasNext()) {
            int current = cursor;
            cursor++;
            return this.components[current];
        }
        throw new NoSuchElementException();
	}

	@Override
	public Iterator<PanelComponent> iterator() {
		this.cursor = 0;
		return this;
	}
}

// abstract product interfaces

public interface Button {
	void paint();
	void onClick();

}

public interface Checkbox {
	void paint();
	void onSelect();
}


// Concrete Product classes imlmentation

public class WindowsButton : Button {   }
public class WindowsCheckbox : Checkbox { }

public class MacOsButton :  Button { }
public class MacOsCheckbox : Checkbox { }

// Abstract factory -> interface for creating families 
public Interface GUIfactory {

	Button createButton();
	Checkbox createCheckbox();
}

// concrete factory
public class WindowsFactory: GUIFactory {
	public Button createButton() { return new WindowsButton();}
	public Checkbox createCheckbox() { return new WindowsCheckbox(); }
}

public class MacOSFactory : GUIFactory { 

}

//  client code
public class Application{
	private final Button button;
	private final Checkbox checkbox;
	public Application(GUIFactory factory) {
		this.button = factory.createButton();
		this.checkbox = factory.createCheckbox();
	}
	public void renderUI() {
		button.paint();
		checkbbox.paint();
	}
}

// application entry point program.cs
GUIFactory factory;
if(os.contains("mac")){
	factory =  new MacOSFactory();
}else{
	factory = new WindowsFactory();
}

Application app  =  new Applicaton(factory);
app.renderUI();




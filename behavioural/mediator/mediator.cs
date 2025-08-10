//Meditator Interface
public interface UIMediator {
    void componentChanged(UIComponent component);
}
// abstract component
public abstract class UIComponent {
    protected UIMediator mediator;
    public UIComponent(UIMediator mediator){
        this.mediator = mediator;
    }
    public void notifyObserver(){
        mediator.componentChanged(this);
    }
}

// implement components
public class TextField: UIComponent{
    string text;
    public TextField(UIMediator mediator){
        super(mediator);
    }
    public void setText(string newText){
        this.text = newText;
        notifyObserver();
    }
} 

// implment concrete mediator 

public class FormMediator : UIMediator {
    public void componentChanged(UIComponent component){
        //condition check form changes
        
    }
}
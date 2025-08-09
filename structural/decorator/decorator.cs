// component interface

public interface TextView {
    void render();
}

// concrete base component


public class PlainTextView: TextView {
    private string text;
    public PlainTextView(string text){
        this.text = text;
    }
    void render() {

    }
}

// abstract decorator
public abstract class TextDecorator: TextView {
    protected final TextView inner;
    public TextDecorator(TextView inner){
        this.inner = inner;
    }
}
// concrete decorators

public class BoldDecorator : TextDecorator{
    public BoldDecorator(TextView view){
        super(view);
    }
    public void render() {
        cout<< "<b> ";
        inner.render();
        
        cout<< "</b> ";
    }
}
public class ItalicDecorator : TextDecorator{
    public ItalicDecorator(TextView view){
        super(view);
    }
    public void render() {
        cout<< "<i>";
        inner.render();
        cout<< "</i> ";
    }
}


TextView plain =  new PlainTextView();
TextView bold =  new BoldDecorator(plain);
TextView italicb =  new ItalicDecorator(bold);

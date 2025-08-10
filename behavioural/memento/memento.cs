// memento class  - texteditomemento

public class TextEditorMemento {
    private final string state;
    public TextEditorMemento(string state){
        this.state = state;
    }
    public string getState(){
        return state;
    }
}

// originator is object whose state want to save and restore
public class TextEditor {
    string content = "";
    void type(string n){
        content+=n;
    }

    public TextEditorMemento save(){
        return new TextEditorMemento(content);
    }
    public void restore(TextEditorMemento memento){
        content = memento.getState();
    }
}
// create caretaker
// managing history states
public class TextEditorUndoManager {
    stack<TextEditorUndoManager> history = new stack<>();
    public void save(TextEditor editor){
        history.push(editor.save());
    }
    public void undo(TextEditor editor){
        if(!history.isEmpty()){
            editor.restore(history.pop());
        } 
    }
}
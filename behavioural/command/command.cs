// command interface
public interface Command {
    void excute();
    void undo();
}

// receivers (devices) --> perform the actions
public class Light {
    public void on() {
        cout << "on";
    }
    public void off() {
        cout<< "off" ;
    }
}
public class Thermostat {
    private int currentTemp = 20;
    void setTemp(int t){
        currentTemp = t;
    }
    get( ) { return currentTemp; }
}

// implement concrete command class
public class LightOnCommand : Command{
    private final  Light light;
    public LightOnCommand(Light light){
        this.light = light;
    }
    public void excute(){
        light.on();
    }
    public void undo(){
        light.off();
    }
}
public class LightOffCommand : Command{
    private final  Light light;
    public LightOffCommand(Light light){
        this.light = light;
    }
    public void excute(){
        light.on();
    }
    public void undo(){
        light.off();
    }
}
// Invoker

public class SmartButton {
    private Command currentCommand;
    private Stack<Command> history = new Stack<Command>();

    void setCommand(Command command){
        this.currentCommand =  command;
    }

    void press(){
        if(currentCommand!=null){
            currentCommand.excute();
            history.push(currentCommand);
        } else{
            cout << "No command assigned";
        }
    }
    void undoLast(){
        if(!history.isEmpty()){
            Command lastCommand = history.pop();
            lastCommand.undo();
        } else{
            cout << "Nothing to undo";
        }

    }
}
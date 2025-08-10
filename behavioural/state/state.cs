// state interface
public interface MachineState {
    void selectItem(VendingMachine context,string item);
    void insertCoin(VendingMachine contenxt, double amount);
    void dispenseItem(VendingMachine context);
}

// implement concrete state classes
public class IdleState : MachineState {
    void selectItem(VendingMachine context,string item) {
        context.setState(new ItemSelectedState();
    }
    void insertCoin(VendingMachine contenxt, double amount);
    void dispenseItem(VendingMachine context);
 }

public class ItemSelectedState :  MachineState{ 
    void selectItem(VendingMachine context,string item);
    void insertCoin(VendingMachine contenxt, double amount){
        contenxt.setState(new HasMoneyState());
    }
    void dispenseItem(VendingMachine context);
}
public class HasMoneyState :  MachineState{ 
    void selectItem(VendingMachine context,string item);
    void insertCoin(VendingMachine contenxt, double amount);
    void dispenseItem(VendingMachine context){
        context.setState(new DispenseState());
    }
}
public class DispenseState :  MachineState{ }

//implement context 
public class VendingMachine {
    private MachineState currentState;
    public VendingMachine(){
        this.currentState = new IdleState();
    }
    public setState(MachineState newstate){
        this.currentState = newstate;
    }

    public selectItem(string itemCode){
        currentState.selectItem(itemCode);
    }

}
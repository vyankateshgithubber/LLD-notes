public Interface PaymentProcessor {
    void processPayment(double amount, string curreny);
    boolean isPaymentSUccessful();
}
public class InHousePaymentProcess :PaymentProcessor{

}

// adaptee
public class LeagacyGatway{
    void excuteTransaction();
    void checkStatus();
}
//adptor  user composition over inhertance
public class LeagacyGatwayAdaptr:  PaymentProcessor {
    private final LeagacyGatway  legacyGatway'
    public LeagacyGatwayAdaptr(LeagacyGatway legacy){
        this.legacyGatway =  legacy;
    }
    public void processPayment(double amount,string curreny){
        legacyGatway.excuteTransaction(amount,curreny);

    }
    public boolean isPaymentSUccessful(){
        return legacyGatway.checkStatus();
    }
    ...
}
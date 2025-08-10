// stretegy interface 
public interface ShippingStrategy{
    double calculateCost(Order order);
}

// implement concrete strategy class

public class FlatRateShipping : ShippingStrategy{
    private double rate;

    public FlatRateShipping(double rate){
        this.rate = rate;
    }

    public void calculateCost(Order order){
        // do calculations
        return rate;
    }
}

public class WeightBasedShipping : ShippingStrategy {
    private double rate;

    public WeightBasedShipping(double rate){
        this.rate = rate;
    }

    public void calculateCost(Order order){
        // do calculations
        return rate;
    }
}

// context class

public class ShippingCostService {
    private ShippingStrategy strategy;
    public ShippingCostService(ShippingStrategy strategy){
        this.strategy=strategy;
    }
    public setStrategy(ShippingStrategy strategy){
        this.strategy =  strategy;
    } 
    public double calculateCost(Order order){
        return strategy.calculateCost();
        
    }
}
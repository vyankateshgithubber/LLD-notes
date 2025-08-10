// implementing observer
public interface FitnessDataObserver {
    void update(FitnessData data);
}

// implementing fitnessdatasubject 
public interface FitnessDataSubject {
    void registerObserver(FitnessDataObserver oberser);
    void removeObserver(FitnessDataObserver oberser);
    void notifyObserver();
}

// concreter subject

public class FitnessData : FitnessDataSubject{
    private int steps;
    private int activeMinutes;
    private int calories;
    private final List<FitnessDataObserver> observers = new ArrayList<>();

    public void registerObserver(FitnessDataObserver observer){
        observers.add(observer);
    }

    public void removeObserver(FitnessDataObserver observer){
        observers.remove(observer);
    }
    public void notifyObserver(){
        for(FitnessDataObserver observer: observers){
            observer.update(this);
        }
    }
    public void newFintessDataPushed(){
        notifyObserver();
    }
    reset(){
        notifyObserver();
    }
} 

// implement observer modules

public class LiveActivityDisplay : FitnessDataObserver{
    public void update(FitnessData data){

    }
}
public class ProgressLogger : FitnessDataObserver{
    public void update(FitnessData data){
        
    }
}
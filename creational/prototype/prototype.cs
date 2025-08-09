// prototype interface , which every clonable object must implment
public interface EnemyPrototype {
    EnemyPrototype clone();
}
// concrete prototypes , each object needs to be cloneable , implment prototype interface and logic to clonde

public class Enemy : EnemyPrototype{
    private string type;
    private string health;
    private double speed;
    public Enemy(string type,string health,double speed){
        this.type = type;
        this.health = health;
        this.speed = speed;
    }

    public Enemy clone(){
        return new Enemy(type, health,speed);
    }
}

// client request a clone


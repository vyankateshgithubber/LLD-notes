// flyweight interface position is extrinsic state 
public interface CharacterFlyweight {
    void draw(int x,int y);
}

// concrete flyweight 
public class CharacterGlyph implements CharacterFlyweight {
    private char symbol;
    private string fontFamily;
    private int fontSize;
    private string color;
    public CharacterFlyweight(char symbol,string fontFamily,int fontSize, string color){
        this.symbol = symbol;
        this.fontFamily = fontFamily;
        this.fontSize = fontSize;
        this.color = color;
    }
    public void draw(int x,int y){
        print(x,y);
    }
}

// create flyweight factory  this ensures flyweight are shared and reused.
public class CharacterFlyweightFactory {
    private final Map<String,CharacterFlyweight> map = new map();
    public CharacterFlyweight getFlyweight(char sy,string fontFamily,innt fontSize,string color){
        string key = symbol+fontFamily+fontSize+color;
        map.putifabsent(key, new CharacterFlyweight(symbol,fontFamily,fontSize,color));
        return map.get(key);
    }
}
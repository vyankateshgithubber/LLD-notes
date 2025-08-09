public abstract class Shape {
    public abstract void draw();
}

class VectorCircle : Shape {
    public void draw(){

    }
}

class RasterCircle : Shape {
    public void draw(){
        
    }
}
// client code 
Shape s1 =  new VectorCircle();
Shape s2 = new  RasterCircle();


public interface Renderer{
    void renderCircle(floagt radius);
    void renderReactangle(float w,fload h);
}

public class VectorRender  : Renderer { }
public class RasterRender : Renderer { }


// abstraction

public abstract class Shape {
    protected Randerer renderer;
    public Shape(Renderer renderer){
        this.renderer = renderer;
    }
    public abstract void draw();
}
// concrete shapes 
public class Circle :  Shape {
    Circle(Renderer renderer,float radius){
        super(renderer);
        this.radius =  radius;
    }
    void draw(){
        renderer.renderCircle(radius);
    }
}
public class Reactangle :  Shape {
    Reactangle(Renderer renderer,float w,float h){
        super(renderer);
        this.width =  w;
        this.height = h;
    }
    void draw(){
        renderer.renderReactangle(width,height);
    }
}
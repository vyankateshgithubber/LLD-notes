// element iterface
public interface Shape {
    void accept(ShapeVisitor visitor);
}

// concrete elements 
public class Circle : Shape {
    private final double radius ;
    public Circle(double radius){
        this.radius = radius;
    }

    public void accept(ShapeVisitor visitor){
        visitor.visitCircle(this);
    }
}

public class Rectangle: Shape{
    privat double width,height;
    public Reactangle(double width,double height){
        this.width = width;
        this.height = height;
    }
    public void accept(ShapeVisitor visitor){
        visitor.visitReactangle(this);
    }
}

// visitor interface 
public interface ShapeVisitor{
    void visitCircle(Circle circle);
    void visitReactangle(Reactangle reactangle);
}

// implment concrete visitors
public class AreaCalculatorVisitor : ShapeVisitor {
    public void visitCircle(Circle circle){

    }
    public void visitReactangle(Reactangle reactangle){

    }
}
public class SvgExporterVisitor : ShapeVisitor {
    public void visitCircle(Circle circle){

    }
    public void visitReactangle(Reactangle reactangle){
        
    }
}
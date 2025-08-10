// common handler interface
public interface RequestHandler {
    void setNext(RequestHandler next);
    void handle(Request request);
}

// concreate abstract base handler (optional)
public abstract class BaseHandler: RequestHandler{
    protected RequestHandler next;
    void setNext(RequestHandler next){
        this.next = next;
    }
    protected void forward(Request request){
        if(next!=null){
            next.handle(request);
        }
    }
}

// concrete handlers

public class AuthHandler : BaseHandler{
    public void handle(Request request){
        // condition check
        forward(request);
    }
}

public class AuthorizationHandler : BaseHandler{
    public void handle(Request request){
        // condition check
        forward(request);
    }
}
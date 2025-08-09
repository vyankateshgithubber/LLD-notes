// product interface
public interface Notification {
	public void send(string message);
}

// concerte products
public class EmailNotification : Notification {
	
	public void send(string message) {  Console.WriteLine('Test')}
}

public class SMSNotification : Notification { 
	public void send(string message) { }
}

// abstract creator
public abstract class NotficationCreator {
	public abstract Notification createNotification();
	public void send(string message){ 
		Notification notify =  createNotification();
	}
}

// concrete creators
public class EmailNotificationCreator : NotificationCreator {
	public Notification createNotification() {
		return new EmailNotification();
	}
}

public class SMSNotificationCreator : NotificationCreator  {
	public Notification createNotification () {
		return new SMSNotification();
	}
}
// this is easily extendable when ever new type added implement concreate Product and concreateCreator only


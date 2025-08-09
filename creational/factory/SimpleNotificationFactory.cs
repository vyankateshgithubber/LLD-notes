public class SimpleNotificationFactory {
    public static Notification createNotification(string type){
        return switch(type){
            case "Email" :  new emailNotification();
            case "SMS" :  new SMSNotification();
            default : throw new Exception("Unknown Type");
        }
    }
}
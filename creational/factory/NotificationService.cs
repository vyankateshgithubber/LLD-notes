public class NotificationService {
    public void sendNotification(string message){
        Notification notification = SimpleNotificationFactory.createNotification(type);
        notification.send(message);
    }
}
public interface Image {
    void display();
    string getFileName();
}
public class HighResolutionImage : Image{
    
}

//proxy class
public class ImageProxy implements Image {
    private String fileName;
    private HighResolutionImage realImage;

    public ImageProxy(string fileName){
        this.fileName = fileName;
    }

    public string getFileName(){
        return fileName;
    }

    public void display() {
        if(realImage == null){
            realImage =  new HighResolutionImage();
        }
        realImage.display();
    }
} 
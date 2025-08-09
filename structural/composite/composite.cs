// component interface
public interface FileSystemItem {
    int getSize();
    void printStructure(string indent);
    void delete();
}

// Leaf class 

public class File implements FileSystemItem {
    private final string name;
    private final int size;

    public File(string name,int size){
        this.name = name;
        this.size = size;
    }

    public int getSize() {
        return size;
    }
    public void printStructure(string indent){

    }
    public void delete() {

    }
}
// composite class folder
public class Folder implements FileSystemItem {
    private final string name;
    private final List<FileSystemItem> children = new List<FileSystemItem>();
    public Folder(string name){
        this.name = name;
    } 

    public void addItem(FileSystemItem item){
        children.add(item);
    } 

    public int getSize() {
        int total = 0;
        for (FileSystemItem item:children){
            total += item.getSize();
        }
        return total;
    }
    public void printStructure(string indent){
        console.writeline(indent + " + " +  name + "/");
        for(FileSystemItem item:children){
            item.printStructure(indent + " ");
        }
    }
    public void delete() {
    for(FileSystemItem item:children){
            item.delete(indent + " ");
        }
    }
}
// traditional approach
public class Playlist {
    private List<String> songs =  new ArrayList<>();
    public void addSong(string song){
        songs.add(song);
    }
    public List<string> getSongs(){
        return songs;
    }
}

for(string song: playlist.getSongs()){

}

// iterator interaface --> std operation needed to iterate over a collection
public interface Iterator<T> {
    bool hasNext();
    T next();
}

// iterableCollection 
public interface IterableCollection<T> {
    Iterator<T> createIterator();
}

// concrete collection (like list implemention)
public class Playlist : IterableCollection<string> {
    private List<string> songs =  new List<string>();
    public void addSong(string song){
        songs.add(song);
    }
    public string getSongAt(int i){
        return songs.get(i);
    }
    public Iterator<string> createIterator(){
        return new PlaylistIterator(this);
    }
    
}

// implement concrete Iterator 
public class PlaylistIterator : Iterator<string>{
    private final Playlist playlist;
    private int index=0;

    public PlaylistIterator(Playlist playlist){
        this.playlist = playlist;
    }

    public bool hasNext() {
        return index < playlist.getSize();
    }

    public string next(){
        return playlist.getSongAt(index++);
    }
}

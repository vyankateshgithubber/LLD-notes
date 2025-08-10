// abstract base class
public abstract class AbtractReportExporter {
    public final void exportReport(Report Data,string filepath){
        preparedata();
        openfile();
        writeHeader();
        writerFooter();
        closeFile();
    } 
    void preparedata(){}
    void openfile() {}
    abstract void writeHeader() {}
    abstract void writerFooter() {}
    void closeFile() {}
}

public class CSVReporterExporter : AbstractReportExporter {

    void writeHeader() {}
    void writerFooter() {}
}
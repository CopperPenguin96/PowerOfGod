package GUI.DialogBox;
 
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
 
import javax.swing.JOptionPane;
import javax.swing.SwingWorker;
 
/**
 * Execute file download in a background thread and update the progress. 
 * @author www.codejava.net
 *
 */
public class DownloadTask extends SwingWorker<Void, Void> {
    private static final int BUFFER_SIZE = 4096;    
    private String downloadURL;
    private String saveDirectory;
    private DownloadDialogBox gui;
    private String fileName;
    public DownloadTask(DownloadDialogBox gui, String downloadURL, String saveDirectory, String fileName) {
        this.gui = gui;
        this.downloadURL = downloadURL;
        this.saveDirectory = saveDirectory;
        this.fileName = fileName;
    }
     
    /**
     * Executed in background thread
     */
    @Override
    protected Void doInBackground() throws Exception {
        try {
            HTTPDownloadUtil util = new HTTPDownloadUtil();
            util.downloadFile(downloadURL);
             
            // set file information on the GUI
            //gui.setFileInfo(util.getFileName(), util.getContentLength());
            String saveFilePath = saveDirectory + fileName;
            File drObj = new File(saveDirectory);
            System.out.println(saveFilePath);
            if (saveDirectory == null || !drObj.exists())
            {
                drObj.mkdirs();
            }
            File fObj = new File(saveFilePath);
            if (!fObj.exists())
            {
                fObj.createNewFile();
            }
            
            InputStream inputStream = util.getInputStream();
            // opens an output stream to save into file
            FileOutputStream outputStream = new FileOutputStream(saveFilePath);
 
            byte[] buffer = new byte[BUFFER_SIZE];
            int bytesRead = -1;
            long totalBytesRead = 0;
            int percentCompleted = 0;
            long fileSize = util.getContentLength();
 
            while ((bytesRead = inputStream.read(buffer)) != -1) {
                outputStream.write(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;
                percentCompleted = (int) (totalBytesRead * 100 / fileSize);
 
                setProgress(percentCompleted);          
            }
 
            outputStream.close();
 
            util.disconnect();
        } catch (IOException ex) {
            JOptionPane.showMessageDialog(gui, "Error downloading file: " + ex.getMessage(),
                    "Error", JOptionPane.ERROR_MESSAGE);            
            ex.printStackTrace();
            setProgress(0);
            cancel(true);           
        }
        return null;
    }
 
    /**
     * Executed in Swing's event dispatching thread
     */
    @Override
    protected void done() {
        if (!isCancelled()) {
            JOptionPane.showMessageDialog(gui,
                    "File has been downloaded successfully!", "Message",
                    JOptionPane.INFORMATION_MESSAGE);
        }
    }   
}

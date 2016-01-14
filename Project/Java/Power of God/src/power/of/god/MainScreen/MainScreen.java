/*
 * The MIT License
 *
 * Copyright 2015 apotter96.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
package power.of.god.MainScreen;

//import Books.NewTestament.*;
//import Books.OldTestament.*;
import java.awt.Color;
import java.io.*;
import java.net.*;
import java.text.*;
import java.util.*;
import java.util.logging.*;
import java.util.zip.*;
import javax.swing.*;
import org.jsoup.Jsoup;
import org.jsoup.nodes.*;
import static power.of.god.DailyScripture.DailyScripture.*;
import power.of.god.DailyScripture.*;
import power.of.god.Settings.*;
import power.of.god.*;
/**
 *
 * @author apotter96
 */
public class MainScreen extends javax.swing.JFrame {

    /**
     * Creates new form UserInfoScreen
     */
    
    public MainScreen() {
        initComponents();
        SetDefaultContentScreen();
        this.setTitle("Power of God " + Updater.LatestStable());
        try {
            Updater.UpdateNotice();
            if (!Updater.UpdateNotice().equals("Updated"))
            {
                MsgBox("Local Version: " + Updater.ServerResponse.toLowerCase(), Updater.UpdateNotice());
            }
        } catch (Exception ex) {
            Logger.getLogger(MainScreen.class.getName()).log(Level.SEVERE, null, ex);
        }
        Settings.LoadFromJson();
        //UserInfo uI = Start.CurrentUserInfo;
        /*jLabel1.setText("Welcome, " + uI.username);
        jLabel3.setText("Real Name: " + uI.name);
        jLabel4.setText("Email: " + uI.email);*/
        clearList();
        jList1.setPreferredSize(null);
        getContentPane().setBackground(Color.DARK_GRAY);
        System.out.println(new Date().toString());
        
    }
    
    
    private void clearList()
    {
        setItems(new ArrayList<>());
    }
    private void setItems(ArrayList<String> items)
    {
        DefaultListModel dm = new DefaultListModel();
        items.stream().forEach((x) -> {
            dm.addElement(x);
        });
        jList1.setModel(dm);
    }
    
    private void updateListItems(String btn)
    {
        valueOfList = btn.toLowerCase();
        switch (btn.toLowerCase())
        {
            case "lessons":
                Document doc;
                try {
                    doc = Jsoup.connect("http://godispower.us/Sundays/").get();
                    ArrayList<String> files = new ArrayList<>();
                    doc.getAllElements().stream().map((file) 
                            -> file.attr("href")).filter((item) 
                                    -> (item.contains(".html"))).forEach((item) 
                                            -> {
                        try {
                            SimpleDateFormat formatter = new SimpleDateFormat("MM.dd.yyyy");
                            String subItem = item.substring(0, 10);
                            Date date = formatter.parse(subItem);
                            if (new Date().after(date))
                            {
                                files.add(subItem.replace(".", "/"));
                            }
                        } catch (ParseException ex) {
                            Logger.getLogger(MainScreen.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                    setItems(files);
                } catch (Exception ex) {
                    Logger.getLogger(MainScreen.class.getName()).log(Level.SEVERE, null, ex);
                }
            case "daily":
                int fileCount = new File("Verses/").list().length;
                ArrayList<String> newList = new ArrayList<>();
                for (int x = 1; x <= fileCount; x++)
                {
                    newList.add("Day #" + x);
                }
                setItems(newList);
        }
    }
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        menuBar1 = new java.awt.MenuBar();
        menu1 = new java.awt.Menu();
        menu2 = new java.awt.Menu();
        menuBar2 = new java.awt.MenuBar();
        menu3 = new java.awt.Menu();
        menu4 = new java.awt.Menu();
        jMenu1 = new javax.swing.JMenu();
        jLabel2 = new javax.swing.JLabel();
        jButton1 = new javax.swing.JButton();
        jButton3 = new javax.swing.JButton();
        jButton4 = new javax.swing.JButton();
        jButton5 = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        jEditorPane1 = new javax.swing.JEditorPane();
        jScrollPane3 = new javax.swing.JScrollPane();
        jScrollPane2 = new javax.swing.JScrollPane();
        jList1 = new javax.swing.JList();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu2 = new javax.swing.JMenu();
        jMenuItem3 = new javax.swing.JMenuItem();

        menu1.setLabel("File");
        menuBar1.add(menu1);

        menu2.setLabel("Edit");
        menuBar1.add(menu2);

        menu3.setLabel("File");
        menuBar2.add(menu3);

        menu4.setLabel("Edit");
        menuBar2.add(menu4);

        jMenu1.setText("jMenu1");

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Power of God - Alpha 1.2");
        setBackground(new java.awt.Color(102, 102, 102));

        jLabel2.setIcon(new javax.swing.ImageIcon(getClass().getResource("/power/of/god/main.png"))); // NOI18N

        jButton1.setText("Purpose");
        jButton1.setPreferredSize(new java.awt.Dimension(117, 26));
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });

        jButton3.setFont(new java.awt.Font("Tahoma", 0, 10)); // NOI18N
        jButton3.setText("Current Lesson");
        jButton3.setPreferredSize(new java.awt.Dimension(117, 26));
        jButton3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton3ActionPerformed(evt);
            }
        });

        jButton4.setText("Bible Plans");
        jButton4.setPreferredSize(new java.awt.Dimension(101, 26));
        jButton4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton4ActionPerformed(evt);
            }
        });

        jButton5.setText("Daily Scripture");
        jButton5.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton5ActionPerformed(evt);
            }
        });

        jEditorPane1.setEditable(false);
        jEditorPane1.setBackground(new java.awt.Color(204, 204, 204));
        jScrollPane1.setViewportView(jEditorPane1);

        jScrollPane3.setVerticalScrollBarPolicy(javax.swing.ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS);
        jScrollPane3.setHorizontalScrollBar(null);

        jScrollPane2.setHorizontalScrollBarPolicy(javax.swing.ScrollPaneConstants.HORIZONTAL_SCROLLBAR_NEVER);
        jScrollPane2.setAutoscrolls(true);
        jScrollPane2.setFocusTraversalPolicyProvider(true);

        jList1.setModel(new javax.swing.AbstractListModel() {
            String[] strings = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            public int getSize() { return strings.length; }
            public Object getElementAt(int i) { return strings[i]; }
        });
        jList1.setSelectionMode(javax.swing.ListSelectionModel.SINGLE_SELECTION);
        jList1.setFocusCycleRoot(true);
        jList1.setFocusTraversalPolicyProvider(true);
        jList1.setPreferredSize(new java.awt.Dimension(113, 80));
        jList1.setValueIsAdjusting(true);
        jList1.setVisibleRowCount(1);
        jList1.addListSelectionListener(new javax.swing.event.ListSelectionListener() {
            public void valueChanged(javax.swing.event.ListSelectionEvent evt) {
                jList1ValueChanged(evt);
            }
        });
        jScrollPane2.setViewportView(jList1);

        jMenuBar1.setBackground(new java.awt.Color(0, 0, 0));

        jMenu2.setText("App");

        jMenuItem3.setText("Settings");
        jMenuItem3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem3ActionPerformed(evt);
            }
        });
        jMenu2.add(jMenuItem3);

        jMenuBar1.add(jMenu2);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 310, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jButton1, javax.swing.GroupLayout.PREFERRED_SIZE, 113, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jButton3, javax.swing.GroupLayout.PREFERRED_SIZE, 117, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jButton4, javax.swing.GroupLayout.PREFERRED_SIZE, 113, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jButton5, javax.swing.GroupLayout.PREFERRED_SIZE, 113, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 421, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 0, Short.MAX_VALUE)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(jScrollPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 0, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jLabel2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jButton1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jButton5))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jButton3, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(jButton4, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jScrollPane3)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 321, Short.MAX_VALUE)
                    .addComponent(jScrollPane2))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        // TODO add your handling code here:
        SetDefaultContentScreen();
        
    }//GEN-LAST:event_jButton1ActionPerformed
    final void SetDefaultContentScreen()
    {
        SetCurrentContent("<html><body>Welcome to Power of God! Thank you for " +
                        "taking the time to view this app! It could actually change your life!<br><br>If you are using " +
                        "this app expecting favor for a specific denomination, you are in for a surprise! " +
                        "This app is intended to be non-denominational! <br><br>You also may be wondering why such an " +
                        "app exists. Well, I believe that the Holy Bible is true. " +
                        PurposeVerses.GetVerse(0) + " With that in mind, I also believe that the " +
                        "holy power God has is beyond compare. " + PurposeVerses.GetVerse(1) + " I " +
                        "live to serve Jesus Christ, who is God, and will come back to earth take all who " +
                        "believe he died and rose again, to heaven. I use this app as a way to witness, to share " +
                        "this amazing truth. God bless and I hope you learn some stuff about God.</body></html>");
    }
    private static String getUrlSource(String urlF) throws IOException {
        URL url = new URL(urlF);
        URLConnection urlCon = url.openConnection();
        BufferedReader in = null;

        if (urlCon.getHeaderField("Content-Encoding") != null
                && urlCon.getHeaderField("Content-Encoding").equals("gzip")) {
            in = new BufferedReader(new InputStreamReader(new GZIPInputStream(
                    urlCon.getInputStream())));
        } else {
            in = new BufferedReader(new InputStreamReader(
                    urlCon.getInputStream()));
        }

        String inputLine;
        StringBuilder sb = new StringBuilder();

        while ((inputLine = in.readLine()) != null)
            sb.append(inputLine);
        in.close();

        return sb.toString();
    }
    private void jButton3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton3ActionPerformed
        CurrentCount = 0;
        displayedGood = false;
        ShowLesson("sunday");
        updateListItems("lessons");
    }//GEN-LAST:event_jButton3ActionPerformed
    int CurrentCount = 0;
    boolean displayedGood = false;
    void ShowOldLesson(String url)
    {
        try {
            SetCurrentContent("<h1>" + TitleExtractor.getPageTitle(url) + "</h1>" +
                    getUrlSource(url));
        } catch (IOException ex) {
            Logger.getLogger(MainScreen.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    void ShowLesson(String day)
    {
        String dayChosen = "http://godispower.us/Sundays/" + theLastSunday(CurrentCount) + ".html";
        final int AllowedAttemptCount = 10;
        if (!displayedGood)
        {
            try {
                System.out.println("---Connecting attempt for attempt " + CurrentCount + 
                    " of " + AllowedAttemptCount + " for");
                SetCurrentContent("<h1>" + TitleExtractor.getPageTitle(dayChosen) + "</h1>" + 
                        getUrlSource(dayChosen));
                displayedGood = true;
                if (CurrentCount > 1)
                {
                    MsgBox("Sorry for the delay", "The lesson you are trying to view " +
                            "has not been uploaded yet. Please be patient");
                }
                CurrentCount = 0;
            } catch (Exception ex) {
                //Logger.getLogger(MainScreen.class.getName()).log(Level.SEVERE, null, ex);
                if (CurrentCount < AllowedAttemptCount) 
                {
                    CurrentCount++;
                    ShowLesson(day);
                    
                }
                else {
                    MsgBox("Error loading Lesson!", "No lesson could be loaded");
                    CurrentCount = 0;
                }
            }
        }
    }
    private String theLastSunday(int neededDay)
    {
        Calendar c = Calendar.getInstance();
        c.set(Calendar.DAY_OF_WEEK,Calendar.SUNDAY);
        c.set(Calendar.HOUR_OF_DAY,0);
        c.set(Calendar.MINUTE,0);
        c.set(Calendar.SECOND,0);
        DateFormat df = new SimpleDateFormat("MM.dd.yyyy");
        if (neededDay >= 1)
        {
            for (int loopCount = 1; loopCount <= neededDay; loopCount++)
            {
                c.add(Calendar.DATE,-7 );
            }
        }
        return df.format(c.getTime());
    }
    public static void MsgBox(String titleBar, String infoMessage)
    {
        JOptionPane.showMessageDialog(null, infoMessage, "InfoBox: " + titleBar, JOptionPane.PLAIN_MESSAGE);
    }
    private void jButton4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton4ActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_jButton4ActionPerformed

    private void jButton5ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton5ActionPerformed
        try {
            // TODO add your handling code here:
            jEditorPane1.setText(GetDailyScripture());
            valueOfList = "daily";
            updateListItems("daily");
        } catch (DailyScriptureReadException ex) {
            jEditorPane1.setText("There was no verse for today. I am sorry!");
            File fDir = new File("Verses/");
            fDir.listFiles()[fDir.listFiles().length].delete();
            Logger.getLogger(MainScreen.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jButton5ActionPerformed

    private void jMenuItem3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem3ActionPerformed
        // TODO add your handling code here:
        SettingsScreen.main(new String[0]);
    }//GEN-LAST:event_jMenuItem3ActionPerformed

    private String valueOfList;
    private void jList1ValueChanged(javax.swing.event.ListSelectionEvent evt) {//GEN-FIRST:event_jList1ValueChanged
        // TODO add your handling code here:
        switch (valueOfList.toLowerCase())
        {
            case "lessons":
                String webAddress = "http://godispower.us/Sundays/" + 
                        jList1.getSelectedValue().toString().replace("/", ".") +
                        ".html";
                ShowOldLesson(webAddress);
            case "daily":
        {
            try {
                jEditorPane1.setText(GetOldScripture(jList1.getSelectedIndex() + 1));
            } catch (DailyScriptureReadException ex) {
                //
            }
        }
                
        }
    }//GEN-LAST:event_jList1ValueChanged

    private void SetCurrentContent(String html)
    {
        jEditorPane1.setContentType("text/html");
        jEditorPane1.setText(html);
        jEditorPane1.setCaretPosition(0);
    }
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Create and display the form */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(SettingsScreen.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(SettingsScreen.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(SettingsScreen.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(SettingsScreen.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        java.awt.EventQueue.invokeLater(() -> {
            MainScreen mScreen = new MainScreen();
            mScreen.pack();
            mScreen.setVisible(true);
            mScreen.setLocationRelativeTo(null);
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JButton jButton3;
    private javax.swing.JButton jButton4;
    private javax.swing.JButton jButton5;
    private javax.swing.JEditorPane jEditorPane1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JList jList1;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu2;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private java.awt.Menu menu1;
    private java.awt.Menu menu2;
    private java.awt.Menu menu3;
    private java.awt.Menu menu4;
    private java.awt.MenuBar menuBar1;
    private java.awt.MenuBar menuBar2;
    // End of variables declaration//GEN-END:variables
}
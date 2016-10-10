/*
 * The MIT License
 *
 * Copyright 2016 apotter96.
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
package power.of.god;

import GUI.DialogBox.ChoiceBoxResult;
import GUI.DialogBox.ChoiceDialogBox;
import GUI.DialogBox.DialogBox;
import GUI.DialogBox.DownloadDialogBox;
import GUI.DialogBox.DownloadTask;
import Utilities.Network;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;
import java.io.IOException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;
import pSystem.ErrorLogging;

/**
 *
 * @author super
 */
public class UpdaterForm extends javax.swing.JFrame implements PropertyChangeListener {

    /**
     * Creates new form UpdaterForm
     */
    public UpdaterForm() {
        initComponents();
        initItems();
    }

    private JComboBox comboBox1 = new JComboBox();
    private JLabel label2 = new JLabel();
    private JProgressBar progressBar1 = new JProgressBar();
    private JButton btnBegin = new JButton();
    private JLabel lblNotice = new JLabel();
    
    private void initItems()
    {
        comboBox1.setSize(145, 21);
        comboBox1.setLocation(161, 78);
        
        label2.setSize(143, 13);
        label2.setLocation(12, 78);
        label2.setText("label2");
        
        progressBar1.setSize(290, 23);
        progressBar1.setLocation(15, 134);
        
        btnBegin.setSize(75, 23);
        btnBegin.setLocation(231, 105);
        btnBegin.setText("Begin");
        
        lblNotice.setSize(213, 23);
        lblNotice.setLocation(12, 105);
        this.setTitle("Updating Power of God...");
        this.add(comboBox1);
        this.add(label2);
        this.add(progressBar1);
        this.add(btnBegin);
        this.add(lblNotice);
        
        Versions().stream().forEach((i) -> {
            comboBox1.addItem(i);
        });
        btnBegin.addActionListener(new java.awt.event.ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    boolean safeToDownload = false;
                    if (!comboBox1.getSelectedItem().toString().equals(Network.LatestOnline()))
                    {
                        ChoiceDialogBox cBox = new ChoiceDialogBox("Warning!",
                            "This is not the recommended version that you have selected." +
                                    " Untold issues might come up if you proceed!",
                        "Yes", "No");
                        cBox.setVisible(true);
                        if (cBox.GetResult().equals(ChoiceBoxResult.Choice1))
                        {
                            safeToDownload = true;
                        }
                    }
                    else
                    {
                        safeToDownload = true;
                    }
                    
                    if (safeToDownload) Download();
                } catch (IOException ex) {
                    Alert(ex);
                }
            }
        });
        comboBox1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                try {
                    if (!comboBox1.getSelectedItem().toString().equals(Network.LatestOnline()))
                    {
                        lblNotice.setText("This is not a recommended version");
                        lblNotice.setForeground(Color.red);
                    }
                    else
                    {
                        lblNotice.setText("This is the recommended version");
                        lblNotice.setForeground(Color.green);
                    }
                } catch (IOException ex) {
                    Alert(ex);
                }
            }
        });
    }
    private void Download()
    {
        String temp_updates = "power.of.god/temp_updates/";
        String download_name = "power.of.god/temp_updates/update.zip";
        try {
            /*//Download dLoad = new Download();
            progressBar1.setValue(0);
            DownloadTask task = new DownloadTask(this, _downloadLocation, _localFolder, _localFileName);
            task.addPropertyChangeListener(this);
            task.execute();*/
        } catch (Exception ex) {
            Logger.getLogger(DownloadDialogBox.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    public void Alert(Exception ex)
    {
        ErrorLogging.Write(ex);
        new DialogBox("Sorry", "Couldn't run Updater. Please try again later").setVisible(true);
        System.exit(0);
    }
    private ArrayList<String> Versions()
    {
        try {
            String textFile = "http://powerofgodonline.net/Application/launcher.txt";
            return Network.getUrlSource(textFile);
        } catch (IOException ex) {
            Alert(ex);
            return null;
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

        jLabel1 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/power/of/god/logo.png"))); // NOI18N
        jLabel1.setText("jLabel1");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 294, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(14, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 60, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(106, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(UpdaterForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(UpdaterForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(UpdaterForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(UpdaterForm.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new UpdaterForm().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel jLabel1;
    // End of variables declaration//GEN-END:variables

    @Override
    public void propertyChange(PropertyChangeEvent evt) {
        if (evt.getPropertyName().equals("progress")) {
            int progress = (Integer) evt.getNewValue();
            progressBar1.setValue(progress);
        }
    }
}

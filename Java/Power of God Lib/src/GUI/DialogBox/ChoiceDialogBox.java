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
package GUI.DialogBox;

import GUI.Controls.Button;
import java.awt.Image;
import java.awt.Label;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.SwingConstants;

/**
 *
 * @author super
 */
public class ChoiceDialogBox extends javax.swing.JDialog {

    /**
     * Creates new form DialogBox
     */
    public ChoiceDialogBox() {
        
    }

    JLabel lblName = new JLabel();
    JLabel MessageLabel = new JLabel();
    
    public ChoiceDialogBox(String title, String message)
    {
        
        
        this.setModalityType(ModalityType.APPLICATION_MODAL);
        String choice1Text = "Ok";
        String choice2Text = "Cancel";
        this.setUndecorated(true);
        this.initComponents();
        ImageIcon icj = new ImageIcon(getClass().getResource("/Images/background.jpg"));
        Image i = icj.getImage().getScaledInstance(800, 456, java.awt.Image.SCALE_SMOOTH);
        
        JLabel background = new JLabel(new ImageIcon(i));
        setContentPane(background);
        //Controls
        //lblName
        
        lblName.setText("lblName");
        lblName.setSize(199, 37);
        lblName.setLocation(179, 1);
        this.add(lblName);
        //button1
        jButton1.setSize(82,32);
        jButton1.setText(choice2Text);
        jButton1.setLocation(296, 186);
        jButton2.setText(choice1Text);
        jButton2.setSize(82, 32);
        jButton2.setLocation(200, 186);
        
        //picMain
        jLabel1.setLocation(12, 1);
        jLabel1.setSize(161, 37);
        ImageIcon ic = new ImageIcon(getClass().getResource("/Images/dboxpic.png"));
        jLabel1.setIcon(ic);
        //MessageLabel
        
        MessageLabel.setLocation(12, 41);
        MessageLabel.setText("MessageLabel");
        MessageLabel.setSize(366, 142);
        this.add(MessageLabel);
        this.add(jLabel1);
        this.add(jButton1);
        this.add(jButton2);
        this.setDialogTitle(title);
        this.setMessage(message);
        MouseAdapter ma = new MouseAdapter() {
            int lastX, lastY;
            @Override
            public void mousePressed(MouseEvent e) {
                lastX = e.getXOnScreen();
                lastY = e.getYOnScreen();
            }
            @Override
            public void mouseDragged(MouseEvent e) {
                int x = e.getXOnScreen();
                int y = e.getYOnScreen();
                // Move frame by the mouse delta
                setLocation(getLocationOnScreen().x + x - lastX,
                    getLocationOnScreen().y + y - lastY);
                lastX = x;
                lastY = y;
            }
        };
        addMouseListener(ma);
        addMouseMotionListener(ma);
    }
    public ChoiceDialogBox(String title, String message, String choice1Text, String choice2Text)
    {
        this.setModalityType(ModalityType.APPLICATION_MODAL);
        this.setUndecorated(true);
        this.initComponents();
        ImageIcon icj = new ImageIcon(getClass().getResource("/Images/background.jpg"));
        Image i = icj.getImage().getScaledInstance(800, 456, java.awt.Image.SCALE_SMOOTH);
        
        JLabel background = new JLabel(new ImageIcon(i));
        setContentPane(background);
        //Controls
        //lblName
        
        lblName.setText("lblName");
        lblName.setSize(199, 37);
        lblName.setLocation(179, 1);
        this.add(lblName);
        //button1
        jButton1.setSize(82,32);
        jButton1.setText(choice2Text);
        jButton1.setLocation(296, 186);
        jButton2.setText(choice1Text);
        jButton2.setSize(82, 32);
        jButton2.setLocation(200, 186);
        
        //picMain
        jLabel1.setLocation(12, 1);
        jLabel1.setSize(161, 37);
        ImageIcon ic = new ImageIcon(getClass().getResource("/Images/dboxpic.png"));
        jLabel1.setIcon(ic);
        //MessageLabel
        
        MessageLabel.setLocation(12, 41);
        MessageLabel.setText("MessageLabel");
        MessageLabel.setSize(366, 142);
        this.add(MessageLabel);
        this.add(jLabel1);
        this.add(jButton1);
        this.add(jButton2);
        this.setDialogTitle(title);
        this.setMessage(message);
        this.setButtonText("Ok");
        MouseAdapter ma = new MouseAdapter() {
            int lastX, lastY;
            @Override
            public void mousePressed(MouseEvent e) {
                lastX = e.getXOnScreen();
                lastY = e.getYOnScreen();
            }
            @Override
            public void mouseDragged(MouseEvent e) {
                int x = e.getXOnScreen();
                int y = e.getYOnScreen();
                // Move frame by the mouse delta
                setLocation(getLocationOnScreen().x + x - lastX,
                    getLocationOnScreen().y + y - lastY);
                lastX = x;
                lastY = y;
            }
        };
        addMouseListener(ma);
        addMouseMotionListener(ma);
    }
    
    public ChoiceBoxResult GetResult()
    {
        return result;
    }
    @Override
    public void setVisible(boolean action)
    {
        if (action == true)
        {
            super.setVisible(true);
        }
        else
        {
             super.setVisible(false);
        }
    }
    private void setDialogTitle(String text)
    {
        lblName.setText(text);
    }
    
    private void setMessage(String text)
    {
        MessageLabel.setVerticalAlignment(SwingConstants.TOP);
        MessageLabel.setText("<html>" + text + "</html>");
    }
    
    private void setButtonText(String text)
    {
        jButton1.setText(text);
    }
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jButton1 = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jButton2 = new javax.swing.JButton();
        jLabel2 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.DO_NOTHING_ON_CLOSE);

        jButton1.setText("button1");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });

        jLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/Images/main_zoom.png"))); // NOI18N

        jButton2.setText("button1");
        jButton2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton2ActionPerformed(evt);
            }
        });

        jLabel2.setText("jLabel2");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap(232, Short.MAX_VALUE)
                .addComponent(jButton2)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jButton1)
                .addContainerGap())
            .addGroup(layout.createSequentialGroup()
                .addComponent(jLabel1, javax.swing.GroupLayout.PREFERRED_SIZE, 161, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(0, 0, Short.MAX_VALUE))
            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                .addGroup(layout.createSequentialGroup()
                    .addContainerGap()
                    .addComponent(jLabel2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addContainerGap()))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addComponent(jLabel1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 157, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jButton1)
                    .addComponent(jButton2))
                .addContainerGap())
            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                .addGroup(layout.createSequentialGroup()
                    .addGap(41, 41, 41)
                    .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 145, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addContainerGap(42, Short.MAX_VALUE)))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private ChoiceBoxResult result;
    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        // TODO add your handling code here:
        this.setVisible(false);
        result = ChoiceBoxResult.Choice2;
    }//GEN-LAST:event_jButton1ActionPerformed

    private void jButton2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton2ActionPerformed
        // TODO add your handling code here:
        this.setVisible(false);
        result = ChoiceBoxResult.Choice1;
    }//GEN-LAST:event_jButton2ActionPerformed

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
            java.util.logging.Logger.getLogger(ChoiceDialogBox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(ChoiceDialogBox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(ChoiceDialogBox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(ChoiceDialogBox.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                ChoiceDialogBox v = new ChoiceDialogBox();
                v.setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JButton jButton2;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    // End of variables declaration//GEN-END:variables
}

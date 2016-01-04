/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package power.of.god;

import javax.swing.JOptionPane;

/**
 *
 * @author apotter96
 */
public class PowerOfGod {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String os = System.getProperty("os.name").toLowerCase();
        if (os.contains("windows"))
        {
            msgBox("This app is not supported on Windows. For the Windows version, download it at http://godispower.us/", "Sorry");
        }
        else if (os.contains("mac"))
        {
            
        }
        else
        {
            new MainLinuxForm().show();
        }
    }
    public static void msgBox(String infoMessage, String titleBar)
    {
        JOptionPane.showMessageDialog(null, infoMessage, "InfoBox: " + titleBar, JOptionPane.INFORMATION_MESSAGE);
    }
    
}

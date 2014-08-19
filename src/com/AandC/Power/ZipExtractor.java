package com.AandC.Power;
import net.lingala.zip4j.exception.ZipException;
import net.lingala.zip4j.core.ZipFile;
import com.AandC.Power.Exceptions.*;
public class ZipExtractor
{
	public static void unzip(String zipFileDir, String planDirectory) throws InvalidBibPlanException{
		String source = zipFileDir;
		String destination = planDirectory;
		String password = "noPassHere";

		try {
			ZipFile zipFile = new ZipFile(source);
			if (zipFile.isEncrypted()) {
				zipFile.setPassword(password);
			}
			zipFile.extractAll(destination);
		} catch (ZipException e) {
			throw new InvalidBibPlanException("Bad File");
		}
	}
}

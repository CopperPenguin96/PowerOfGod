package com.AandC.Power.Extractors;
import net.lingala.zip4j.exception.ZipException;
import net.lingala.zip4j.core.ZipFile;
import com.AandC.Power.Exceptions.*;
/*
 Copyright 2014 apotter96

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */
public class ZipExtractor
{
	public static void unzip(String zipFileDir, String planDirectory) throws InvalidBibPlanException{
		String destination = planDirectory;
		String password = "noPassHere";

		try {
			ZipFile zipFile = new ZipFile(zipFileDir);
			if (zipFile.isEncrypted()) {
				zipFile.setPassword(password);
			}
			zipFile.extractAll(destination);
		} catch (ZipException e) {
			e.printStackTrace();
			System.out.println(zipFileDir);
			System.out.println(planDirectory);
		}
	}
}

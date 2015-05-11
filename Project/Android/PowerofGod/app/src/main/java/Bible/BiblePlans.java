package Bible;

/**
 * Created by apotter96 on 4/18/2015.
 */
public class BiblePlans {
    public static BibPlan ParseBibPlan(String file) throws InvalidBibPlanException {
        if (!fileExtension(file).equals("bibplan"))
        {
            throw new InvalidBibPlanException("Invalid File Type/Extension.");
        }
        else
        {

        }
        return null;
    }

    static String fileExtension(String fileName)
    {
        String file = fileName.toLowerCase();
        String extension = "";

        int i = file.lastIndexOf('.');
        if (i > 0) {
            extension = file.substring(i+1);
        }
        return extension;
    }
}

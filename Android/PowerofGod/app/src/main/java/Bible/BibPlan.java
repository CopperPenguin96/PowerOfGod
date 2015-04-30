package Bible;

/**
 * Created by apotter96 on 4/18/2015.
 */
public class BibPlan {
    public BibPlan(String name, String[] daysA, String author)
    {
        this.SetName(name);
        this.SetDays(daysA);
        this.SetPlanAuthor(author);
    }

    private String planName;
    public void SetName(String s)
    {
        planName = s;
    }
    public String GetName()
    {
        return planName;
    }

    private String[] days;
    public void SetDays(String[] s)
    {
        days = s;
    }
    public String[] GetDays()
    {
        return days;
    }

    private String planauthor;
    public void SetPlanAuthor(String s)
    {
        planauthor = s;
    }
    public String GetPlanAuthor()
    {
        return planauthor;
    }

    public int GetPlanDayCount()
    {
        return GetDays().length + 1;
    }

    public String ReadVerseFromDay(int dayCount)
    {
        int newCount = dayCount - 1;
        String todayVerse = GetDays()[newCount];
        return null;
    }
}

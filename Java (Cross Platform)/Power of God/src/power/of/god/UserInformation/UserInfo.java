package power.of.god.UserInformation;

/**
 * Created by apotter96 on 4/8/2015.
 */
public final class UserInfo {
    private static String name;
    public static void SetName(String s)
    {
        name = s;
    }
    public static String GetName()
    {
        return name;
    }

    private static int age;
    public static void SetAge(int a)
    {
        age = a;
    }
    public static int GetAge()
    {
        return age;
    }

    private static String den;
    public static void SetDenomination(String s)
    {
        den = s;
    }
    public static String GetDenomination()
    {
        return den;
    }
}

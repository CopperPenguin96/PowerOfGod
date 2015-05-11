package apdevelopment.powerofgod;

/**
 * Created by apotter96 on 4/16/2015.
 */
public class JsonReadException extends Exception
{
    public JsonReadException()
    {
        super();
    }
    public JsonReadException(String message)
    {
        super(message);
    }
    public JsonReadException(String message, Throwable t)
    {
        super(message, t);
    }
    public JsonReadException(Throwable t)
    {
        super(t);
    }
}

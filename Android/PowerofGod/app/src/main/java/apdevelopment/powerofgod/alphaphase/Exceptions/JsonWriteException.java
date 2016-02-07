package apdevelopment.powerofgod.alphaphase.Exceptions;

/**
 * Created by apotter96 on 4/16/2015.
 */
public class JsonWriteException extends Exception
{
    public JsonWriteException()
    {
        super();
    }
    public JsonWriteException(String message)
    {
        super(message);
    }
    public JsonWriteException(String message, Throwable t)
    {
        super(message, t);
    }
    public JsonWriteException(Throwable t)
    {
        super(t);
    }
}

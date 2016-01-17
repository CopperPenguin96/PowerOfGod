package apdevelopment.powerofgod.alpha.Exceptions;

/**
 * Created by apotter96 on 4/18/2015.
 */
public class InvalidBibPlanException extends Exception {
    public InvalidBibPlanException()
    {
        super();
    }
    public InvalidBibPlanException(String message)
    {
        super(message);
    }
    public InvalidBibPlanException(String message, Throwable t)
    {
        super(message, t);
    }
    public InvalidBibPlanException(Throwable t)
    {
        super(t);
    }
}

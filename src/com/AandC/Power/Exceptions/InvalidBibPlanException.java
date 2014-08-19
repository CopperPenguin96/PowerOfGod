package com.AandC.Power.Exceptions;

public class InvalidBibPlanException extends Exception
{
	public InvalidBibPlanException() { super(); }
	public InvalidBibPlanException(String message) { super(message); }
	public InvalidBibPlanException(String message, Throwable cause) { super(message, cause); }
	public InvalidBibPlanException(Throwable cause) { super(cause); }
}

namespace Perforce.Exceptions;

public abstract class PerforceException : ApplicationException
{
    public abstract string GetErrorMessage();
}
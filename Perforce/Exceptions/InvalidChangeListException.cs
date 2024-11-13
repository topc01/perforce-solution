namespace Perforce.Exceptions;

public class InvalidChangeListException : PerforceException
{
    public override string GetErrorMessage()
        => "Invalid changelist";
}
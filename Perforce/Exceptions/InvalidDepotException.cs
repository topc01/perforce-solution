namespace Perforce.Exceptions;

public class InvalidDepotException : PerforceException
{
    public override string GetErrorMessage()
        => "Invalid depot path";
}
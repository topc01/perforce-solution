namespace Perforce.Exceptions.ChangeListExceptions;

public class InvalidAddFileIsEmptyException(string file) : PerforceException
{
    public override string GetErrorMessage()
        => $"Invalid add change: File {file} has no content";
}
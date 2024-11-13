namespace Perforce.Exceptions.ChangeListExceptions;

public class InvalidAddFileExistsException(string file) : PerforceException
{
    public override string GetErrorMessage()
        => $"Invalid add change: File {file} already exists";
}
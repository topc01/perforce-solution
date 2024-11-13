namespace Perforce.Exceptions.ChangeListExceptions;

public class InvalidEditFileIsEmptyException(string file) : PerforceException
{
    public override string GetErrorMessage()
        => $"Invalid edit change: File {file} has no content";
}
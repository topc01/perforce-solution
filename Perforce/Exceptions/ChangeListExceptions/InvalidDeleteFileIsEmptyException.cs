namespace Perforce.Exceptions.ChangeListExceptions;

public class InvalidDeleteFileIsEmptyException(string file) : PerforceException
{
    public override string GetErrorMessage()
        => $"Invalid delete change: File {file} has content";
}
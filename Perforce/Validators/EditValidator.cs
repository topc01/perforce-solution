using Perforce.Exceptions.ChangeListExceptions;
using VersionControlSystem;

namespace Perforce.Validators;

class EditValidator(VersionSystem versionSystem, string depot) : IValidator
{
    public void Validate(Change change)
    {
        FilePath path = FilePath.Combine(depot, change.Path);
        if (!versionSystem.Exists(path))
            throw new InvalidEditFileDoesntExistException(change.Path);
        if (change.Content == null)
            throw new InvalidEditFileIsEmptyException(change.Path);
    }
}
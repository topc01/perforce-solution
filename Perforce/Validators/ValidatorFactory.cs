using VersionControlSystem;

namespace Perforce.Validators;

class ValidatorFactory
{
    public IValidator Create(VersionSystem versionSystem, string depot, string changeType)
    {
        if (changeType == "add")
            return new AddValidator(versionSystem, depot);
        if (changeType == "delete")
            return new DeleteValidator(versionSystem, depot);
        if (changeType == "edit")
            return new EditValidator(versionSystem, depot);
        throw new NotImplementedException();
    }
}
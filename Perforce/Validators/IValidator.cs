namespace Perforce.Validators;

interface IValidator
{
    void Validate(Change change);
}
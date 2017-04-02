using EPs.Domain.Validations;

namespace EPs.Domain.Commands
{
    public class CreateProductCommand : ProductCommand
    {
        public CreateProductCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

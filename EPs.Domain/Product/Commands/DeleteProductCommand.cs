using EPs.Domain.Validations;
using System;

namespace EPs.Domain.Commands
{
    public class DeleteProductCommand : ProductCommand
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

using EPs.Domain.Commands;

namespace EPs.Domain.Validations
{
    public class CreateProductValidation : ProductValidation<CreateProductCommand>
    {
        public CreateProductValidation()
        {
            ValidateName();
            ValidateDescription();
        }
    }
}

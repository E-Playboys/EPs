using EPs.Domain.Commands;

namespace EPs.Domain.Validations
{
    public class UpdateProductValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
        }
    }
}

using EPs.Domain.Commands;

namespace EPs.Domain.Validations
{
    public class DeleteProductValidation : ProductValidation<DeleteProductCommand>
    {
        public DeleteProductValidation()
        {
            ValidateId();
        }
    }
}

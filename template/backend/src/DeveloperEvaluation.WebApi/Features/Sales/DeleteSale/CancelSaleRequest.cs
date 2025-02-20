namespace DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public class CancelSaleRequest
    {
        public Guid Id { get; set; }

        public CancelSaleRequest(Guid id)
        {
            Id = id;
        }
    }
}

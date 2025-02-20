using DeveloperEvaluation.Domain.Common;

namespace DeveloperEvaluation.Domain.Entities
{
    public class Geolocation: BaseEntity
    {
        public new Guid Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
    }
}

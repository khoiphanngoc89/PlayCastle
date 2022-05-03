using Common.SharedKernel.DatabaseProvider;

namespace Inventory.API.Entities
{
    public class BagDetail : IEntity
    {
        public Guid Id { get; set; }
        public Guid CatalogId { get; set; }
        public int Amount { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
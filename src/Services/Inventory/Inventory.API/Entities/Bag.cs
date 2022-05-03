using Common.SharedKernel.DatabaseProvider;
namespace Inventory.API.Entities
{
    public class Bag : IEntity
    {
        public Guid Id { get ; set; }
        public Guid PlayerId { get; set; }
        public int AmountOfSlot { get; set; }
        public decimal Gold { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Models
{
    public record PlayCastleBagDto([Required] Guid Id, [Required] Guid PlayerId, [Range(0, 1000)] int AmountOfSlot, [Range(0, Double.MaxValue)] decimal Gold);
    public record CreatePlayCastleBagDto([Required] Guid PlayerId, [Range(0, 1000)] int AmountOfSlot, [Range(0, Double.MaxValue)] decimal Gold);
    public record UpdatePlayCastleBagDto([Required] Guid Id, [Required] Guid PlayerId, [Range(0, 1000)] int AmountOfSlot, [Range(0, Double.MaxValue)] decimal Gold);
    public record PlayCastleBagDetailDto([Required] Guid Id, [Required] Guid CatalogId, [Range(0,100)] int Amount, DateTimeOffset CreatedDate, DateTimeOffset? ModifiedDate);
    public record CreatePlayCastleBagDetailDto([Required] Guid CatalogId, [Range(0,100)] int Amount, DateTimeOffset CreatedDate);
    public record UpdatePlayCastleBagDetailDto([Required] Guid Id, [Required] Guid CatalogId, [Range(0,100)] int Amount, DateTimeOffset ModifiedDate);
}
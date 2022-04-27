using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Models
{
    public record PlayCastleItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate, DateTimeOffset? ModifiedDate = null);
    public record CreatePlayCastleItemDto([Required] string Name, string Description, [Range(0,Double.MaxValue)] decimal Price);
    public record UpdatePlayCastleItemDto([Required] string Name, string Description, [Range(0, Double.MaxValue)] decimal Price);
}
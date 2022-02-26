using Grpc.Core;
using Bookshop;

namespace BookshopServer.Services;

public class InventoryService : Inventory.InventoryBase
{
  private readonly ILogger<InventoryService> _logger;
  public InventoryService(ILogger<InventoryService> logger)
  {
    _logger = logger;
  }

  public override Task<GetBookListResponse> GetBookList(GetBookListRequest request, ServerCallContext context)
  {
    var response = new GetBookListResponse();
    response.Books.Add(new Book { Title = "The C# Book", Author = "Joe Smith" });
    response.Books.Add(new Book { Title = "The Go Book", Author = "Jane Doe" });
    return Task.FromResult(response);
  }
}

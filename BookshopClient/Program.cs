using Grpc.Core;
using Grpc.Net.Client;
using Bookshop;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5000");
var client = new Inventory.InventoryClient(channel);

try
{
  var reply = await client.GetBookListAsync(
      new GetBookListRequest(),
      deadline: DateTime.UtcNow.AddSeconds(5));

  Console.WriteLine("Books: " + reply.Books);
}
catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
{
  Console.Error.WriteLine("The book list request exceeded its five-second deadline.");
  Environment.ExitCode = 1;
}

using Grpc.Net.Client;
using Bookshop;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5000");
var client = new Inventory.InventoryClient(channel);
var reply = await client.GetBookListAsync(new GetBookListRequest { });
Console.WriteLine("Books: " + reply.Books);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
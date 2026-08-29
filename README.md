# gRPC on .NET

This repository contains the .NET client and ASP.NET Core server used by my [gRPC article series](https://sahansera.dev/introduction-to-grpc/) on [sahansera.dev](https://sahansera.dev/).

The recommended reading order is:

1. [Introduction to gRPC](https://sahansera.dev/introduction-to-grpc/)
2. [Building a gRPC Server in .NET](https://sahansera.dev/building-grpc-server-dotnet/)
3. [Building a gRPC Client in .NET](https://sahansera.dev/building-grpc-client-dotnet/)
4. [Deploy a gRPC .NET Server on Azure App Services](https://sahansera.dev/deploying-dotnet-grpc-service-azure-app-services/) (set the branch to [app-service](https://github.com/sahansera/dotnet-grpc/tree/app-service))

## Prerequisites

- .NET 10 SDK
- [`grpcurl`](https://github.com/fullstorydev/grpcurl) for command-line inspection

## Build and run

Restore and build both projects:

```bash
dotnet restore BookshopServer/BookshopServer.csproj
dotnet restore BookshopClient/BookshopClient.csproj
dotnet build BookshopServer/BookshopServer.csproj --no-restore
dotnet build BookshopClient/BookshopClient.csproj --no-restore
```

Start the server on the sample's fixed local HTTP/2 port:

```bash
dotnet run --project BookshopServer/BookshopServer.csproj
```

In another terminal, call it with the .NET client:

```bash
dotnet run --project BookshopClient/BookshopClient.csproj
```

Or inspect the service through development-only reflection:

```bash
grpcurl -plaintext localhost:5000 list
grpcurl -plaintext localhost:5000 Inventory.GetBookList
```

The fixed plaintext endpoint keeps this local sample easy to run. Use TLS and authentication before exposing a gRPC service outside a trusted development environment. The client also sets a five-second RPC deadline so an unavailable dependency cannot hold the call indefinitely.

# GrpcServer

## Project Setup

- Created a gRPC Service Project with Visual Studio:
  ```bash
  dotnet new grpc -o "$PROJECT_NAME"
  ```

- Created the server. No changes needed initially due to the default template.

- Added a console app to the solution for client testing:
  ```bash
  dotnet new console -o "$CLIENT_PROJECT_NAME"
  ```

- Added required packages to the client project:
  ```bash
  dotnet add "$CLIENT_PROJECT_NAME" package Google.Protobuf
  dotnet add "$CLIENT_PROJECT_NAME" package Grpc.Net.Client
  dotnet add "$CLIENT_PROJECT_NAME" package Grpc.Tools
  ```

## Client Setup

- Created a `Protos` folder in the client project.
- Copied `greet.proto` from the server to the client `Protos` folder.
- Updated the namespace in the client's `greet.proto` to match the client project namespace.
- Modified the project file to include the proto:
  ```xml
  <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
  ```

## Client Usage

- Created a gRPC channel:
  ```csharp
  var channel = GrpcChannel.ForAddress("Server address from Properties/launchSettings.json");
  ```

- Created a specific client:
  ```csharp
  var client = new Greeter.GreeterClient(channel);
  ```

- Called the desired function on the client:
  ```csharp
  var result = await client.SayHelloAsync(requestObject);
  ```

## Adding a New gRPC Service

1. Create a new `ServiceName.proto` file in the server's `Protos` folder.
2. Copy the new `.proto` file into the client's `Protos` folder.
3. Add both proto files to their respective project files under `<ItemGroup>`.
4. Create a new service implementation in the server's `Services` folder.
5. Override the RPC method(s) you want and add your logic.
6. Register the new service in `Program.cs`:
   ```csharp
   app.MapGrpcService<NewProtoService>();
   ```

7. Update the client:
   - Change the channel and gRPC client to use the new service.

namespace Hackathon.Warehouse.Api.Contracts.Documents
{
    public record ReceiveItemRequest(
        int ItemId,
        int ReceivedCount
        );
}

using Google.Protobuf;
using Main;
using System.IO;

public class MoveRequrst : IPakcetHandler
{
    public PacketType Type => PacketType.MoveRequrst;

    public void Handle(Packet packet)
    {
        var moveRequrst = Protobuf.Server.MoveRequest.Parser.ParseFrom(packet.Data);

        var responsePacket = new Protobuf.Client.MoveResponse();
        responsePacket.MoveDirection = moveRequrst.MoveDirection;

        var stream = new MemoryStream();
        responsePacket.WriteTo(stream);
        var data = stream.ToArray();
        
        Connection.Broadcast(new Packet(PacketType.MoveResponse, data));
    }
}

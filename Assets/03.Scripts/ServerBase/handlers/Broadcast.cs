using Main;

public class Broadcast : IPakcetHandler
{
    public PacketType Type => PacketType.Broadcast;

    public void Handle(Packet packet)
    {
        Connection.Broadcast(packet);
    }
}

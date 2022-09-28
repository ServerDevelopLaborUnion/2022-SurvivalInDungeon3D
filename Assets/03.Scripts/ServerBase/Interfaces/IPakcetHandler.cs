using Main;

public interface IPakcetHandler
{
    PacketType Type { get; }
    void Handle(Packet packet);
}
using System;

public struct RelayHostData
{
    public string joinCode;
    public string IPv4Address;
    public ushort port;
    public Guid allocationID;
    public byte[] allocationIDBytes;
    public byte[] connectionData;
    public byte[] key;
}

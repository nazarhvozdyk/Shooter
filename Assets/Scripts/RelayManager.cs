using UnityEngine;
using Unity.Netcode.Transports.UTP;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;

public class RelayManager : MonoBehaviour
{
    [SerializeField]
    private int _maxConnections = 10;

    [SerializeField]
    private UnityTransport _unityTransport;

    public async Task<RelayHostData> SetupRelay()
    {
        Debug.Log("Relay Server starting with max connections");
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        Allocation allocation = await Relay.Instance.CreateAllocationAsync(_maxConnections);
        RelayHostData relayHostData = new RelayHostData()
        {
            key = allocation.Key,
            port = (ushort)allocation.RelayServer.Port,
            allocationID = allocation.AllocationId,
            allocationIDBytes = allocation.AllocationIdBytes,
            IPv4Address = allocation.RelayServer.IpV4,
            connectionData = allocation.ConnectionData
        };

        relayHostData.joinCode = await Relay.Instance.GetJoinCodeAsync(relayHostData.allocationID);

        _unityTransport.SetRelayServerData(
            relayHostData.IPv4Address,
            relayHostData.port,
            relayHostData.allocationIDBytes,
            relayHostData.key,
            relayHostData.connectionData
        );

        Debug.Log("Relay server generated. Join code: " + relayHostData.joinCode);

        return relayHostData;
    }

    public async Task<RelayJoinData> JoinRelay(string joinCode)
    {
        await UnityServices.InitializeAsync();

        JoinAllocation joinAllocation = await Relay.Instance.JoinAllocationAsync(joinCode);

        RelayJoinData relayJoinData = new RelayJoinData()
        {
            key = joinAllocation.Key,
            port = (ushort)joinAllocation.RelayServer.Port,
            allocationID = joinAllocation.AllocationId,
            allocationIDBytes = joinAllocation.AllocationIdBytes,
            connectionData = joinAllocation.AllocationIdBytes,
            hostConnectionsData = joinAllocation.HostConnectionData,
            IPv4Address = joinAllocation.RelayServer.IpV4,
            joinCode = joinCode
        };

        _unityTransport.SetRelayServerData(
            relayJoinData.IPv4Address,
            relayJoinData.port,
            relayJoinData.allocationIDBytes,
            relayJoinData.key,
            relayJoinData.connectionData,
            relayJoinData.hostConnectionsData
        );

        Debug.Log("Client joined to the game with join code " + joinCode);

        return relayJoinData;
    }
}

using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class PlayerSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkRunner runner;
    public GameObject playerPrefab;
    public List<Transform> spawnPoints;

    private void Awake()
    {
        if (runner != null)
        {
            runner.AddCallbacks(this);
        }
    }

    public void SpawnPlayer(PlayerRef player)
    {
        int playerIndex = GetPlayerIndex(player);
        int spawnIndex = Mathf.Clamp(playerIndex, 0, spawnPoints.Count - 1);

        Vector3 pos = spawnPoints[spawnIndex].position;
        Quaternion rot = spawnPoints[spawnIndex].rotation;

        Debug.Log($"[PlayerSpawner] Spawning player {player.PlayerId} at {pos}");
        runner.Spawn(playerPrefab, pos, rot, player);
    }

    int GetPlayerIndex(PlayerRef player)
    {
        var players = runner.ActivePlayers;
        int i = 0;
        foreach (var p in players)
        {
            if (p == player)
                return i;
            i++;
        }
        return 0;
    }

    // ====== 实现所有 INetworkRunnerCallbacks 方法，留空没关系 ======
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player) { SpawnPlayer(player); }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnInput(NetworkRunner runner, NetworkInput input) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
    public void OnConnectedToServer(NetworkRunner runner) { }
    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason) { }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data) { }
    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken token) { }
    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }
    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }
}
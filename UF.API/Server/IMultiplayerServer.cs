using System;
using System.Net;
using System.Collections.Generic;

namespace UF.API.Server {
    /// <summary>
    /// Called when the given packet comes in from a remote client. Return false to cease communication
    /// with that client.
    /// </summary>
    public delegate void PacketHandler(IPacket packet, IRemoteClient client, IMultiplayerServer server);

    public interface IMultiplayerServer {
        event EventHandler<ItemAddedEventArgs> NewItemReceived;

        event EventHandler<PlayerJoinedQuitEventArgs> PlayerJoined;
        event EventHandler<PlayerJoinedQuitEventArgs> PlayerQuit;

        IList<IRemoteClient> Clients { get; }
        IPEndPoint EndPoint { get; }

        bool ItemUpdatesEnabled { get; set; }
        bool EnableClientLogging { get; set; }
        void Start(IPEndPoint endPoint);
        void Stop();
        void AddItem(IItem item);
        void SendMessage(string message, params object[] parameters);
        void DisconnectClient(IRemoteClient client);
        bool PlayerIsBlacklisted(string client);
        bool PlayerIsAdmin(string client);
    }
}
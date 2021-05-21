using System;
using UF.API.Networking;

namespace UF.API.Server {
    public class PlayerJoinedQuitEventArgs : EventArgs {
        public PlayerJoinedQuitEventArgs(IRemoteClient client) {
            Client = client;
        }

        public IRemoteClient Client { get; set; }
    }
}
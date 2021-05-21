using System;
using UF.API.Networking;

namespace UF.API.Server {
    public class ItemAddedEventArgs : EventArgs {
        public ItemAddedEventArgs(IRemoteClient client, string itemUID, string cardID) {
            Client = client;
            ItemUID = itemUID;
            PreventDefault = false;
        }

        public IRemoteClient Client { get; set; }

        public string ItemUID { get; set; }
        
        /// <summary>
        /// If set to true, the server won't send the default message back to the client.
        /// </summary>
        public bool PreventDefault { get; set; }
    }
}
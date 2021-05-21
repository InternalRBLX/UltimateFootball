using System;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using UF.API.Server;

namespace UF {
    public class MultiplayerServer : IMultiplayerServer, IDisposable {
        public event EventHandler<ItemAddedEventArgs> NewItemReceived;
        public event EventHandler<PlayerJoinedQuitEventArgs> PlayerJoined;
        public event EventHandler<PlayerJoinedQuitEventArgs> PlayerQuit;
        public IList<IRemoteClient> Clients { get; private set; }
        
        public bool EnableClientLogging { get; set; }
        public IPEndPoint EndPoint { get; private set; }

        private static readonly int MillisecondsPerTick = 1000 / 20;

        private struct ItemUpdate {
            public string cardID;
            public string itemUID;
        }

        private Queue<ItemUpdate> PendingItemUpdates { get; set; }

        private Timer EnvironmentWorker;
        private TcpListener Listener;
        internal object ClientLock = new object();
        internal bool ShuttingDown { get; private set; }

        public MultiplayerServer() { 
            Clients = new List<IRemoteClient>();
            Items = new List<IItem>();
            // var itemRepository = new ItemRepository();
            // itemRepository.DiscoverItemProviders();
            // ItemRepository = itemRepository;
            PendingBlockUpdates = new Queue<ItemUpdate>();
            EnableClientLogging = false;
        }
    }
}
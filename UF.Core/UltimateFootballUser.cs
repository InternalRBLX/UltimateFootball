using System;

namespace UF.Core {
    public class UltimateFootballUser {
        public static string AuthServer = "http://"; // Website goes here for authentication

        public string UserName { get; set; }
        public string SessionId { get; set; }
    }
}
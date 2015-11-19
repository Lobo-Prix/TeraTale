﻿namespace TeraTaleNet
{
    public class PlayerInfoResponse : Body
    {
        public string nickName;
        public string world;

        public PlayerInfoResponse(string nickName, string world)
        {
            this.nickName = nickName;
            this.world = world;
        }

        public PlayerInfoResponse(byte[] bytes)
            : base(bytes)
        { }

        protected override PacketType Type()
        {
            return PacketType.PlayerInfoResponse;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiscord
{
    using Discord;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args) => new Program().Start();

        private DiscordClient _client;

        public void Start()
        {
            _client = new DiscordClient();

            _client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor)
                {
                    await e.Channel.SendMessage(e.Message.Text);
                    string chanmsg = e.Message.Text;
                    if (chanmsg.StartsWith("\\"))
                    {
                        if (chanmsg.Contains("lol"))
                           await e.Channel.SendMessage("fisk");
                    }
                }
        Debug.WriteLine("msg");
            };

    _client.ExecuteAndWait(async() => {
                await _client.Connect("MjA3OTQzNDA5NjQ4OTI2NzIw.Cnqd5A.6M7E6XWfGVpEdeR1tS5OoENuik4");
    Debug.WriteLine("auth");
            });
        }
    }
}

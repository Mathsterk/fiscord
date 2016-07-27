using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiscord
{
    using Discord;
    using Discord.Audio;
    using System.Diagnostics;
    using NAudio;
    using NAudio.Wave;
    using NAudio.CoreAudioApi;


    class Program
    {
        static void Main(string[] args) => new Program().Start();

        private DiscordClient _client;

        public Channel VoiceChannel { get; private set; }

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
                    //if(chanmsg.Contains("top10anime") || chanmsg.Contains("top 10 anime") || chanmsg.Contains("topp 10 anime"))
                    if (chanmsg.IndexOf("top10anime", 0, StringComparison.CurrentCultureIgnoreCase) != -1
                    || chanmsg.IndexOf("top 10 anime", 0, StringComparison.CurrentCultureIgnoreCase) != -1
                    || chanmsg.IndexOf("topp 10 anime", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        for (int i = 10; i > 0; i--)
                        {
                            await Task.Delay(1500);
                            await e.Channel.SendMessage(i + ". Naruto");
                        }
                    }
                    if (chanmsg.IndexOf("how 2 be otaku", 0, StringComparison.CurrentCultureIgnoreCase) != -1
                    || chanmsg.IndexOf("how to be otaku", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        await e.Channel.SendMessage("https://www.youtube.com/watch?v=YvLsWydCkzQ");
                    }
                }
                Debug.WriteLine("msg");
            };

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect("MjA3OTQzNDA5NjQ4OTI2NzIw.Cnqd5A.6M7E6XWfGVpEdeR1tS5OoENuik4");

                _client.UsingAudio(x => // Opens an AudioConfigBuilder so we can configure our AudioService
                {
                    x.Mode = AudioMode.Outgoing; // Tells the AudioService that we will only be sending audio
                });

                var voiceChannel = _client.FindServers("Testservereren").FirstOrDefault().VoiceChannels.FirstOrDefault(); // Finds the first VoiceChannel on the server 'Music Bot Server'

                var _vClient = Discord.Audio.AudioService; // We use GetService to find the AudioService that we installed earlier. In previous versions, this was equivelent to _client.Audio()
                .Join(VoiceChannel); // Join the Voice Channel, and return the IAudioClient.


                Debug.WriteLine("auth");
            });

            _client.UsingAudio(x => // Opens an AudioConfigBuilder so we can configure our AudioService
            {

                x.Mode = AudioMode.Outgoing; // Tells the AudioService that we will only be sending audio
            });


        }
    }
}



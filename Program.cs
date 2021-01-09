//=========== originally based on SpicyBot by JayAvenian -- github.com/JayAvenian/SpicyBot ================


using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;




namespace Stalker_Bot
{

    class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandHandler;
            _client.Log += Log;


            var token = File.ReadAllText("token.txt");

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {

            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task CommandHandler(SocketMessage message)
        {
          // all commands starts from here
            ulong toddid = 461265486655520788;   // an ID of @ToddBot

 // ========== String arrays used as triggers for the bot. Bot would react If any are mentioned by users 

            string[] babs = {"баба", "бабу", "бабы", "бабам", "бабах", "бабе", "бабой"};
            string[] boots = {"ботинки", "сапог", "сапоги", "сапожища", "сапожки", "сапожищи"};
            string[] destiny = {"судьба", "судьбе", "судьбой", "судьбою", "судьбах", "судьбы"};
            string[] normalek = {"нормалёк", "офигенно", "охуенно", "прорвемся", "друганы", "топчу", "топчишь"};
            string[] kushat =
                {"кушать", "покушал", "поесть", "покушать", "пожрать", "кушал", "поел", "скушать", "перекусить"};
            string[] guitarmusic =
                {"guitar1.mp3", "guitar2.mp3", "guitar3.mp3", "guitar4.mp3", "guitar5.mp3", "guitar6.mp3", "guitar7.mp3", "guitar8.mp3", "guitar9.mp3"}; // absolute path for audiomessage. In the given example it's the root folder
//===============================================//
//====  random selection for 
            Random rnd = new Random();
           
            string[] anekRandStrings = { "anekdot.wav", "anekdot2.wav", "anekdot3.wav", "anekdot4.wav", "anekdot5.wav", "anekdot6.wav", "anekdot7.wav", "anekdot8.wav" };
            int mIndex = rnd.Next(anekRandStrings.Length);
            int gIndex = rnd.Next(guitarmusic.Length);

//=================//

            if (message.Author.IsBot && message.Author.Id != toddid) //This ignores all commands from bots
                return;

            if (message.Author.Id == toddid)
            {
                await message.Channel.SendFileAsync("pomatzaem.wav", "<@461265486655520788>"); //it makes our bot react on every phrase send by @ToddBot 
               
            //====  this is an implementation for bot's cooldown. Not perfect at all, but working one///

                _client.StopAsync();   // makes the bot to disconnect (go offline)
                await Task.Delay(5000); // Time delay
                await MainAsync(); // reconnect the bot
             //=============================//
            }

            else if (babs.Any(x => message.Content.ToLower().Contains(x))) //case insensitive
            {
                message.Channel.SendMessageAsync(" Эх Бабу бы! Приголубил бы любую, лишь бы всё нужное на месте было!");
                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }

            else if (boots.Any(x => message.Content.ToLower().Contains(x)))
            {
                message.Channel.SendMessageAsync(
                    " Опять сапожищи хреновые подсунули! Что у них совсем совести нету, у этих... За неделю подошве гаплык!");

                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }
             

            else if (destiny.Any(x => message.Content.ToLower().Contains(x)))
            {
                message.Channel.SendMessageAsync(
                    " Судьба... Нет, от судьбы точно никуда не скроешься... Что на роду написано — так оно и будет.");
                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }
            else if (normalek.Any(x => message.Content.ToLower().Contains(x)))
            {
                message.Channel.SendMessageAsync(
                    " Ниче! Нормалек. Прорвемся. Не зря ж я вон сколько небо копчу. И я, и друганы мои... Прорвемся..");
                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }

            else if (kushat.Any(x => message.Content.ToLower().Contains(x)))
            {
                await message.Channel.SendFileAsync("havay.wav", message.Author.Mention); //Bot will mention a person that used the trigger word
                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }

            else if (message.Content.Equals("!несмешно")) //The main difference between "Equals" and "Contains" methods is that "Equals" is checking for the 100% match (that's why we don't need to use .()ToLower method)
            {
              await message.Channel.SendFileAsync("nofunny.wav","");
              _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }
            else if (message.Content.Equals("!анекдот"))
            {
              await message.Channel.SendFileAsync(anekRandStrings[mIndex], "https://i.imgur.com/PxlS6RT.jpg"); // it selects random string from the array////  Also, an url picture will be embedded to the message, but sometimes it sends raw url only
              _client.StopAsync();
              await Task.Delay(5000);
              await MainAsync();
            }
            else if (message.Content.Equals("!нудлядуши"))
            {
                await message.Channel.SendFileAsync(guitarmusic[gIndex], "https://i.imgur.com/VSyHxiI.jpg");
                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }
            else if (message.Content.Equals("!бар100"))
            {
                await message.Channel.SendFileAsync("bar100.mp3", "https://i.imgur.com/kzqWuOo.jpg");
                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }
            // help command for users
            else if (message.Content.Equals("!памагити"))
            {
                message.Channel.SendMessageAsync(
                    "Команды для мужиков от Серёги ```\n !бар100 = музыка из бара '100Рентген' \n !нудлядуши = музыка для души! \n !анекдот = Анекдот \n !несмешно = блин, так не смешно же!```");
                _client.StopAsync();
                await Task.Delay(5000);
                await MainAsync();
            }


        }

    }
}

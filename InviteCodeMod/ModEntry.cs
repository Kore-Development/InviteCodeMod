using System;
using System.IO;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace InviteCodeMod
{
    public class ModEntry : Mod
    {
        private string inviteCode = "a";
        private string inviteCodeTXT = "a";

        public override void Entry(IModHelper helper) {
            helper.Events.GameLoop.OneSecondUpdateTicked += OnOneSecondUpdateTicked;
        }

        private void OnOneSecondUpdateTicked(object sender, OneSecondUpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (Game1.options.enableServer) {
                inviteCodeTXT = Game1.server.getInviteCode();

                try
                {
                    StreamWriter sw = new StreamWriter("Mods/InviteCodeMod/InviteCode.txt");

                    sw.WriteLine(inviteCodeTXT);
                    sw.Close();
                }
                catch (Exception b)
                {
                    Console.WriteLine("Exception: " + b.Message);
                }
            }
        }
    }
}
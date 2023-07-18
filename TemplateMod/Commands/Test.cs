using Outpath_Modding.GameConsole.Components;

namespace TemplateMod.Commands
{
    public class Test : ICommand
    {
        public string Command { get; set; } = "Test";
        public string[] Abbreviate { get; set; } = new string[] { "tst" };
        public string Description { get; set; } = "Test command";

        public bool Execute(string[] args, out string reply)
        {
            reply = "Work";
            return true;
        }
    }
}

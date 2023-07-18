using Outpath_Modding.API.Config;

namespace TemplateMod
{
    public class Config : IConfig
    {
        public bool Enable { get; set; } = true;

        public int TestInt { get; set; } = 10;
    }
}

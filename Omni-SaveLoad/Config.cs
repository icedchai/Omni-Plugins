using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;


namespace SCP_SL_SAVELOAD
{
    public class Config : IConfig
    {
        [Description("Indicates plugin enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("Indicates debug mode enabled or not")]
        public bool Debug { get; set; } = false;

        [Description("what custom info needs to be present to allow a player to save/load. MUST BE LOWERCASE!")]
        public List<string> CustomInfoAllowed { get; set; } = new List<string> { 
            "the chosen one",
            "gordon freeman",
            "agent issac",
        };
        [Description("% chance of the player encountering an out of date Node Graph")]
        public int NodeGraphChance { get; set; } = 20;
    }
}

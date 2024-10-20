using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace Omni_Utils
{
    public class Config : IConfig
    {
        [Description("Indicates plugin enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("Indicates debug mode enabled or not")]
        public bool Debug { get; set; } = false;

        [Description("Whether jumping shall consume stamina")]
        public bool FuckJumpingQuestionMark { get; set; } = true;
        [Description("Percent of stamina to consume when jumping")]
        public float StaminaUseOnJump { get; set; } = 30;

        [Description("Whether to use Save/Load for players that get disconnected.")]
        public bool DisconnectSafety { get; set; } = true;

        [Description("Whether to allow modmail")]
        public bool ModMailEnabled { get; set; } = true;
        [Description("Whether to utilize Custom Keycard functions")]
        public bool CustomKeycardsQuestionMark { get; set; } = true;

    }
}

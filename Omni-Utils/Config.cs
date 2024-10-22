using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
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
        [Description("Keycard ItemTypes and the permissions that go with them.")]
        public Dictionary<ItemType,KeycardPermissions> Permissions { get; set; } = new Dictionary<ItemType, KeycardPermissions> {
            { ItemType.KeycardScientist , KeycardPermissions.ContainmentLevelOne|KeycardPermissions.ContainmentLevelTwo|KeycardPermissions.Checkpoints}
        };
        public List<ItemType> ScpPedestalCardBlacklist { get; set; } = new List<ItemType>
        {
            ItemType.KeycardScientist
        };
        public Dictionary<DoorType, KeycardPermissions> DoorPermsOverride { get; set; } = new Dictionary<DoorType, KeycardPermissions>
        {
            {DoorType.Intercom, KeycardPermissions.ArmoryLevelTwo|KeycardPermissions.ContainmentLevelThree }
        };
        public List<DoorType> InvincibleDoors { get; set; } = new List<DoorType> { 
            DoorType.Intercom,
            DoorType.HID,
        };

    }
}

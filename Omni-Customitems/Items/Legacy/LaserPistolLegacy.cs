using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Firearms.Attachments;
using MEC;

namespace Omni_Customitems.Items.Globergooban
{
    [CustomItem(ItemType.GunCom45)]
    public class LaserPistolLegacy : LegacyAbstractLaserGun
    {
        public override float Damage { get; set; } = 4;
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 07;
        public override byte ClipSize { get; set; } = 9;
        public override string Name { get; set; } = "Laser Pistol w/ Illegal Switch";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 4;
        public override SpawnProperties SpawnProperties { get; set; }
    }
}

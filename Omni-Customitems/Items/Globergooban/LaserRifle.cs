using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using InventorySystem.Items.Firearms.Attachments;

namespace Omni_Customitems.Items.Globergooban
{
    [CustomItem(ItemType.GunE11SR)]
    public class LaserRifle : AbstractLaserGun
    {
        public override float Damage { get; set; } = CustomItemsPlugin.pluginInstance.Config.LaserRifleDmg;
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 04;
        public override byte ClipSize { get; set; } = CustomItemsPlugin.pluginInstance.Config.LaserRifleClip;
        public override string Name { get; set; } = "Type 15 Laser Rifle";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 4;
        public override SpawnProperties? SpawnProperties { get; set; }

        public override AttachmentName[] Attachments { get; set; } = new[]
        {
            AttachmentName.LowcapMagAP,
            AttachmentName.NightVisionSight,
            AttachmentName.AmmoCounter,
            AttachmentName.RifleBody,
            AttachmentName.StandardStock,
            AttachmentName.Laser,
            AttachmentName.FlashHider,
        };

    }
}

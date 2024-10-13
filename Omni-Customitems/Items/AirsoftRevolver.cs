using Exiled.API.Features.Attributes;
using Exiled.CustomItems.API.Features;
using InventorySystem.Items.Firearms.Attachments;
using YamlDotNet.Serialization;

namespace Omni_Customitems.Items
{
    [CustomItem(ItemType.GunRevolver)]
    public class AirsoftRevolver : AbstractAirsoftGun
    {
        [YamlIgnore]
        public override AttachmentName[] Attachments { get; set; } = new[]
{       AttachmentName.IronSights,
        AttachmentName.CylinderMag6,
    };
        public override byte ClipSize { get; set; } = 6;
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 03;
        public override string Name { get; set; } = "CO2 Airsoft Revolver";
        public override float Damage { get; set; } = 3;
        public override string Description { get; set; }
    }
}

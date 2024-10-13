using Exiled.API.Features.Attributes;
using Exiled.CustomItems.API.Features;
using InventorySystem.Items.Firearms.Attachments;
using YamlDotNet.Serialization;

namespace Omni_Customitems.Items
{
    [CustomItem(ItemType.GunE11SR)]
    public class AirsoftE11 : AbstractAirsoftGun
    {
        [YamlIgnore]
        public override AttachmentName[] Attachments { get; set; } = new[]
{
        AttachmentName.SoundSuppressor,
        AttachmentName.Flashlight,
        AttachmentName.Foregrip,
            AttachmentName.IronSights,
    };
        public override byte ClipSize { get; set; } = 100;
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 01;
        public override string Name { get; set; } = "Epsilon-11 Standard Rifle airsoft replica";
        public override string Description { get; set; }
    }
}

using Exiled.API.Features.Attributes;
using Exiled.CustomItems.API.Features;
using InventorySystem.Items.Firearms.Attachments;
using YamlDotNet.Serialization;

namespace Omni_Customitems.Items
{
    [CustomItem(ItemType.GunCOM18)]
    public class AirsoftCOM18 : AbstractAirsoftGun
    {
        [YamlIgnore]
        public override AttachmentName[] Attachments { get; set; } = new[]
    {
        AttachmentName.SoundSuppressor,
        AttachmentName.IronSights,
        AttachmentName.Flashlight,
    };
        public override byte ClipSize { get; set; } = 30;
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 02;
        public override string Name { get; set; } = "COM-18 airsoft replica";
        public override string Description { get; set; }
    }
}

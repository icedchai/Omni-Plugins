using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni_CustomSquads.Custom
{
    public class CustomCaptain : CustomRole
    {
        public override uint Id { get;set; }
        public override int MaxHealth { get; set; } = 100;
        public override string Name { get;set; }
        public override string Description { get;set; }
        public override string CustomInfo { get;set; }
        public override SpawnProperties SpawnProperties { get; set; }
        public override float SpawnChance { get; set; } = 0;
    }
}

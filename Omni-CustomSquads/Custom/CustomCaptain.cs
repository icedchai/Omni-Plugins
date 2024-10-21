using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncomplicatedCustomRoles.API.Enums;
using UncomplicatedCustomRoles.API.Features.Behaviour;
using UncomplicatedCustomRoles.API.Interfaces;
using UncomplicatedCustomRoles.Manager;
using UnityEngine;

namespace Omni_CustomSquads.Custom
{
    public class CustomCaptain : UncomplicatedCustomRoles.API.Features.CustomRole
    {
        public override int Id { get;set; }
        public override string Name { get;set; }
        public override string CustomInfo { get;set; }
        public override string Nickname { get; set; } = "%nick%";
        public override RoleTypeId RoleAppearance { get; set; }
        public override SpawnBehaviour SpawnSettings { get ; set ; } = new SpawnBehaviour { 
            SpawnChance = 0,
            Spawn=UncomplicatedCustomRoles.API.Enums.SpawnType.KeepRoleSpawn,
        };
        public override bool OverrideRoleName { get;set; }
        public override string BadgeName { get;set; }
        public override string BadgeColor { get;set; } 
        public override RoleTypeId Role { get;set; }
        public override Team? Team { get;set; }
        public override List<Team> IsFriendOf { get;set; }
        public override HealthBehaviour Health { get;set; } 
        public override AhpBehaviour Ahp { get;set; }
        public override List<Effect> Effects { get;set; }
        public override StaminaBehaviour Stamina { get;set; }
        public override int MaxScp330Candies { get;set; }
        public override bool CanEscape { get; set; } = false;
        public override Dictionary<string, string> RoleAfterEscape { get; set; }
        public override Vector3 Scale { get;set; }
        public override string SpawnBroadcast { get; set; }
        public override ushort SpawnBroadcastDuration { get; set; } = 15;
        public override string SpawnHint { get;set; } = "You are a member of a custom squad :)";
        public override float SpawnHintDuration { get; set; } = 15;
        public override Dictionary<ItemCategory, sbyte> CustomInventoryLimits { get;set; }
        public override List<ItemType> Inventory { get;set; }
        public override List<uint> CustomItemsInventory { get;set; }
        public override Dictionary<AmmoType, ushort> Ammo { get;set; }
        public override float DamageMultiplier { get;set; }
        public override CustomFlags? CustomFlags { get;set; }
        public override bool IgnoreSpawnSystem { get;set; }
    }
}

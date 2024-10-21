using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Interfaces;
using Exiled.CreditTags.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni_CustomSquads.Config
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public int IdPrefix { get; set; } = 1100;

        [Description("Please note that you MUST put an ID for each and every role here. The IdPrefix above will be added onto the ID for each role you put (added as in mathematical addition, not prepended)")]
        public List<CustomSquad> customSquads { get; set; } = new List<CustomSquad>
        {
            new CustomSquad()
            {
                Ranks = new List<String>
                {
                    "Leader",
                    "Soldier",
                    "Recruit",
                },
                SquadName="serpentshand",
                CustomInfo="Serpent's Hand",
                SpawnBroadcast = "You are a member of the Serpent's Hand.",
                Team=Team.SCPs,
                SquadType=Respawning.SpawnableTeamType.ChaosInsurgency,
                customCaptain = new Custom.CustomCaptain()
                {
                    Id=4,

                    Name="Serpent's Hand Leader",
                    Role=RoleTypeId.ChaosConscript,
                    RoleAppearance=RoleTypeId.ChaosConscript,
                    Inventory=new List<ItemType>
                    {
                         ItemType.KeycardChaosInsurgency ,
                         ItemType.GunCrossvec ,
                         ItemType.Medkit ,
                         ItemType.Adrenaline ,
                         ItemType.ArmorCombat
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato762,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customSergeant = new Custom.CustomCaptain()
                {
                    Id=5,

                    Name="Serpent's Hand Soldier",
                    Role=RoleTypeId.ChaosConscript,
                    RoleAppearance=RoleTypeId.ChaosConscript,
                    Inventory=new List<ItemType>
                    {
                         ItemType.KeycardChaosInsurgency ,
                         ItemType.GunCrossvec ,
                         ItemType.Medkit ,
                         ItemType.Adrenaline ,
                         ItemType.ArmorCombat
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato762,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customPrivate = new Custom.CustomCaptain()
                {
                    Id=6,

                    Name="Serpent's Hand Recruit",
                    Role=RoleTypeId.ChaosConscript,
                    RoleAppearance=RoleTypeId.ChaosConscript,
                    Inventory=new List<ItemType>
                    {
                         ItemType.KeycardChaosInsurgency ,
                         ItemType.GunCrossvec ,
                         ItemType.Medkit ,
                         ItemType.Adrenaline ,
                         ItemType.ArmorCombat
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato762,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
            },
            new CustomSquad()
            {
                Ranks = new List<string>
                {
                    "Commander",
                    "Lieutenant",
                    "Cadet",
                },
                SquadName= "minutemen",
                CustomInfo="Delta-4 Minutemen",
                Team=Team.FoundationForces,
                SquadType=Respawning.SpawnableTeamType.NineTailedFox,
                SpawnBroadcast=$"You are a member of Delta-4 Minutemen.",
                EntranceAnnouncement = $"MTFUnit nato_d 4 designated Minute Men hasentered AllRemaining",
                EntranceAnnouncementSubs = $"Mobile Task Force Unit Delta-4 designated 'Minutemen' has entered the facility. All remaining personnel are advised to proceed with standard evacuation protocols until an MTF squad reaches your destination.",
                customCaptain = new Custom.CustomCaptain()
                {
                    Id=1,
                    Name="Minutemen Captain",
                    Role=RoleTypeId.NtfCaptain,
                    Inventory=new List<ItemType>
                    {
                        ItemType.KeycardMTFOperative,
                        ItemType.GunE11SR,
                        ItemType.Medkit,
                        ItemType.Adrenaline,
                        ItemType.Radio,
                        ItemType.ArmorCombat
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato556,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customSergeant = new Custom.CustomCaptain()
                {
                    Id=2,
                    Name="Minutemen Sergeant",
                    Role=RoleTypeId.NtfSergeant,
                    Inventory=new List<ItemType>
                    {
                         ItemType.KeycardMTFOperative ,
                         ItemType.GunE11SR ,
                         ItemType.Medkit ,
                         ItemType.Adrenaline ,
                         ItemType.Radio ,
                         ItemType.ArmorCombat 
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato556,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customPrivate = new Custom.CustomCaptain()
                {
                    Id=3,
                    Name="Minutemen Private",
                    Role=RoleTypeId.NtfPrivate,
                    Inventory=new List<ItemType>
                    {
                         ItemType.KeycardMTFOperative ,
                         ItemType.GunE11SR ,
                         ItemType.Medkit ,
                         ItemType.Radio ,
                         ItemType.ArmorCombat 
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato556,80 },
                        {AmmoType.Nato9,100 }

                    }
                }
            },
            
        };

    }
}

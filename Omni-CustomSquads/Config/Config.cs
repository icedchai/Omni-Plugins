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
        public uint IdPrefix { get; set; } = 1100;

        [Description("Please note that you MUST put an ID for each and every role here. The IdPrefix above will be added onto the ID for each role you put (added as in mathematical addition, not prepended)")]
        public List<CustomSquad> customSquads { get; set; } = new List<CustomSquad>
        {
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
                SquadType=Respawning.SpawnableTeamType.NineTailedFox,
                EntranceAnnouncement = "MTFUnit nato_d 4 designated Minute Men hasentered AllRemaining",
                EntranceAnnouncementSubs = "Mobile Task Force Unit Delta-4 designated 'Minutemen' has entered the facility. All remaining personnel are advised to proceed with standard evacuation protocols until an MTF squad reaches your destination.",
                customCaptain = new Custom.CustomCaptain()
                {
                    SpawnProperties = new()
                    {
                        RoleSpawnPoints = new List<RoleSpawnPoint>
                        {
                            new()
                            {
                                Role = RoleTypeId.NtfCaptain,
                                Chance = 100
                            }
                        }
                    },
                    Id=1,
                    Name="Minutemen Captain",
                    Role=RoleTypeId.NtfCaptain,
                    Inventory=new List<string>
                    {
                        $"{ItemType.KeycardMTFOperative}",
                        $"{ItemType.GunE11SR}",
                        $"{ItemType.Medkit}",
                        $"{ItemType.Adrenaline}",
                        $"{ItemType.Radio}",
                        $"{ItemType.ArmorCombat}"
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato556,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customSergeant = new Custom.CustomSergeant()
                {
                    SpawnProperties = new()
                    {
                        RoleSpawnPoints = new List<RoleSpawnPoint>
                        {
                            new()
                            {
                                Role = RoleTypeId.NtfCaptain,
                                Chance = 100
                            }
                        }
                    },
                    Id=2,
                    Name="Minutemen Sergeant",
                    Role=RoleTypeId.NtfSergeant,
                    Inventory=new List<string>
                    {
                        $"{ItemType.KeycardMTFOperative}",
                        $"{ItemType.GunE11SR}",
                        $"{ItemType.Medkit}",
                        $"{ItemType.Adrenaline}",
                        $"{ItemType.Radio}",
                        $"{ItemType.ArmorCombat}"
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato556,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customPrivate = new Custom.CustomPrivate()
                {
                                        SpawnProperties = new()
                    {
                        RoleSpawnPoints = new List<RoleSpawnPoint>
                        {
                            new()
                            {
                                Role = RoleTypeId.NtfCaptain,
                                Chance = 100
                            }
                        }
                    },
                    Id=3,
                    Name="Minutemen Private",
                    Role=RoleTypeId.NtfPrivate,
                    Inventory=new List<string>
                    {
                        $"{ItemType.KeycardMTFOperative}",
                        $"{ItemType.GunE11SR}",
                        $"{ItemType.Medkit}",
                        $"{ItemType.Radio}",
                        $"{ItemType.ArmorCombat}"
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato556,80 },
                        {AmmoType.Nato9,100 }

                    }
                }
            },
            new CustomSquad()
            {
                Ranks = new List<string> 
                {
                    "Leader",
                    "Soldier",
                    "Recruit",
                },
                SquadName="serpentshand",
                CustomInfo="Serpent's Hand",
                SquadType=Respawning.SpawnableTeamType.ChaosInsurgency,
                customCaptain = new Custom.CustomCaptain()
                {
                    Id=4,
                    SpawnProperties = new()
                    {
                        RoleSpawnPoints = new List<RoleSpawnPoint>
                        {
                            new()
                            {
                                Role = RoleTypeId.ChaosConscript,
                                Chance = 100
                            }
                        }
                    },
                    
                    Name="Serpent's Hand Leader",
                    Role=RoleTypeId.Tutorial,
                    Inventory=new List<string>
                    {
                        $"{ItemType.KeycardChaosInsurgency}",
                        $"{ItemType.GunCrossvec}",
                        $"{ItemType.Medkit}",
                        $"{ItemType.Adrenaline}",
                        $"{ItemType.ArmorCombat}"
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato762,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customSergeant = new Custom.CustomSergeant()
                {
                    Id=5,
                    SpawnProperties = new()
                    {
                        RoleSpawnPoints = new List<RoleSpawnPoint>
                        {
                            new()
                            {
                                Role = RoleTypeId.ChaosConscript,
                                Chance = 100
                            }
                        }
                    },
                    
                    Name="Serpent's Hand Soldier",
                    Role=RoleTypeId.Tutorial,
                    Inventory=new List<string>
                    {
                        $"{ItemType.KeycardChaosInsurgency}",
                        $"{ItemType.GunCrossvec}",
                        $"{ItemType.Medkit}",
                        $"{ItemType.Adrenaline}",
                        $"{ItemType.ArmorCombat}"
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato762,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
                customPrivate = new Custom.CustomPrivate()
                {
                    Id=6,
                    SpawnProperties = new()
                    {
                        RoleSpawnPoints = new List<RoleSpawnPoint>
                        {
                            new()
                            {
                                Role = RoleTypeId.ChaosConscript,
                                Chance = 100
                            }
                        }
                    },
                    
                    Name="Serpent's Hand Recruit",
                    Role=RoleTypeId.Tutorial,
                    Inventory=new List<string>
                    {
                        $"{ItemType.KeycardChaosInsurgency}",
                        $"{ItemType.GunCrossvec}",
                        $"{ItemType.Medkit}",
                        $"{ItemType.Adrenaline}",
                        $"{ItemType.ArmorCombat}"
                    },
                    Ammo = new Dictionary<Exiled.API.Enums.AmmoType, ushort>
                    {
                        {AmmoType.Nato762,80 },
                        {AmmoType.Nato9,100 }

                    }
                },
            }
        };

    }
}

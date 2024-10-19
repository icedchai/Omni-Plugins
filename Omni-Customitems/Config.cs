using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Omni_Customitems
{
    public class Config : IConfig
    {
        [Description("Is plugin enabled or not?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Is plugin in debug mode?")]
        public bool Debug { get; set; } = true;
        [Description("Custom Item ID prefix")]
        public uint IdPrefix { get; set; } = 1100;
        [Description("Name of the schematic spawned by the smoke grenade")]
        public string GrenadeSmokeSchematic { get; set; } = "GrenadeSmoke";
        public float EnergyRifleDmg { get; set; } = 70;
        public byte LaserRifleClip { get; set; } = 15;
        public float LaserRifleDmg { get; set; } = 20;

        public byte LaserPistolClip { get; set; } = 20;
        public float LaserPistolDmg { get; set; } = 40;
    }
}
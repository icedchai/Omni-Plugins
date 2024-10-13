using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using MEC;
using System;
using System.Collections.Generic;

namespace Omni_Customitems
{
    public class CustomItemsPlugin : Plugin<Config>
    {
        public static CustomItemsPlugin pluginInstance;
        public static List<RoomType> lczRoomTypes = new List<RoomType> {
                //
        // Summary:
        //     Light Containment Zone's Armory.
            //
            // Summary:
            //     Light Containment Zone's Curved Hall.
        RoomType.LczCurve,
        //
        // Summary:
        //     Light Containment Zone's Straight Hall.
        RoomType.LczStraight,
        //
        // Summary:
        //     Light Containment Zone's 4-Way intersection.
        RoomType.LczCrossing,
        //
        // Summary:
        //     Light Containment Zone's 3-Way intersection.
        RoomType.LczTCross,
        //
        // Summary:
        //     Light Containment Zone's PC-15's room.
        RoomType.LczCafe,
        //
        // Summary:
        //     Light Containment Zone's VT-00's room.
        RoomType.LczPlants,
        //
        // Summary:
        //     Light Containment Zone's Water Closet.
        RoomType.LczToilets,
        //
        // Summary:
        //     Light Containment Zone's Airlock room.
        RoomType.LczAirlock,
        //
        // Summary:
        //     Light Containment Zone's PT-00 room.
        RoomType.Lcz173,
        //
        // Summary:
        //     Light Containment Zone's Class-D spawn room.
        RoomType.LczClassDSpawn,
        //
        // Summary:
        //     Light Containment Zone's Checkpoint B room.
        RoomType.LczCheckpointB,
        //
        // Summary:
        //     Light Containment Zone's GR-18's room.
        RoomType.LczGlassBox,
        //
        // Summary:
        //     Light Containment Zone's Checkpoint A room.
        RoomType.LczCheckpointA,
        };
        public static List<RoomType> hczRoomTypes = new List<RoomType> {//
                                                                 // Summary:
                                                                 //     Heavy Containment Zone's SCP-079 room.
        RoomType.Hcz079,
        //
        // Summary:
        //     Heavy Containment Zone's Entrance Checkpoint A room.
        RoomType.HczEzCheckpointA,
        //
        // Summary:
        //     Heavy Containment Zone's Entrance Checkpoint B room.
        RoomType.HczEzCheckpointB,
            //
            // Summary:
            //     Heavy Containment Zone's 3-Way Intersection + Armory room.
        RoomType.HczArmory,
        //
        // Summary:
        //     Heavy Containment Zone's SCP-939 room.
        RoomType.Hcz939,
            //
            // Summary:
            //     Heavy Containment Zone's MicroHID straight hall.
        RoomType.HczHid,
        //
        // Summary:
        //     Heavy Containment Zone's SCP-049 + SCP-173's room.
        RoomType.Hcz049,
            //
            // Summary:
            //     Heavy Containment Zone's 4-way intersection.
        RoomType.HczCrossing,
        //
        // Summary:
        //     Heavy Containment Zone's SCP-106 room.
        RoomType.Hcz106,
        //
        // Summary:
        //     Heavy Containment Zone's nuke room.
        RoomType.HczNuke,
        //
        // Summary:
        //     Heavy Containment Zone's Servers room.
        RoomType.HczServers,
        //
        // Summary:
        //     Heavy Containment Zone's 3-way intersection.
        RoomType.HczTCross,
            //
            // Summary:
            //     Heavy Containment Zone's cruved hall.
        RoomType.HczCurve,
        //
        // Summary:
        //     Heavy Containment Zone's test room's straight hall.
        RoomType.HczTestRoom,
        //
        // Summary:
        //     Heavy Containment Zone's Elevator System A room.
        RoomType.HczElevatorA,
        //
        // Summary:
        //     Heavy Containment Elevator Zone's System B room.
        RoomType.HczElevatorB};
        public static List<RoomType> ezRoomTypes = new List<RoomType> {//
                                                                // Summary:
                                                                //     Entrance Zone's Red Vent room.
        RoomType.EzVent,
        //
        // Summary:
        //     Entrance Zone's Intercom room.
        RoomType.EzIntercom,
            //
            // Summary:
            //     Entrance Zone's straight hall with PC's on a lower level.
        RoomType.EzDownstairsPcs,
        //
        // Summary:
        //     Entrance Zone's curved hall.
        RoomType.EzCurve,
        //
        // Summary:
        //     Entrance Zone's straight hall with PC's on the main level.
        RoomType.EzPcs,
        //
        // Summary:
        //     Entrance Zone's 4-way intersection.
        RoomType.EzCrossing,
        //
        // Summary:
        //     Entrance Zone's Red Collapsed Tunnel Room.
        RoomType.EzCollapsedTunnel,
        //
        // Summary:
        //     Entrance Zone's straight hall with Dr.L's locked room.
        RoomType.EzConference,
        //
        // Summary:
        //     Entrance Zone's straight hall
        RoomType.EzStraight,
        //
        // Summary:
        //     Entrance Zone's Cafeteria Room.
        RoomType.EzCafeteria,
        //
        // Summary:
        //     Entrance Zone's straight hall with PC's and upper level.
        RoomType.EzUpstairsPcs,
        //
        // Summary:
        //     Entrance Zone's Shelter rfoom.
        RoomType.EzShelter,        //
        // Summary:
        //     Entrance Zone's 3-way intersection.
        RoomType.EzTCross,        //
        // Summary:
        //     Entrance Zone's straight hall before the entrance/heavy checkpoint.
        RoomType.EzCheckpointHallway,};
        public static List<RoomType> szRoomTypes = new List<RoomType> {
            RoomType.Surface

        };

        public static Dictionary<ZoneType, List<RoomType>> zoneToRooms = new Dictionary<ZoneType, List<RoomType>>{
            { ZoneType.Surface,szRoomTypes },
            { ZoneType.LightContainment,lczRoomTypes },
            { ZoneType.Entrance,ezRoomTypes },
            { ZoneType.HeavyContainment,hczRoomTypes },
    };
        public override string Name => "Omni-2 Custom Items";

        public override string Author => "icedchqi";

        public override string Prefix => "omni-customitems";

        public override Version Version => new(1, 0, 0);
        public override void OnEnabled()
        {
            pluginInstance = this;
            Timing.CallDelayed(6f, () => CustomItem.RegisterItems());
        }

        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();
        }

    }
}
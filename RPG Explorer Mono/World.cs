using System.Collections.Generic;

namespace RPGExplorer
{
    enum RoomId
    {
        Null,
        Crypt,
        Cemetery,
        NearChurch,
        Church1F,
        Church2F,
        ChurchBackyard
    }

    /*
    static class World
    {
        private static Dictionary<RoomId, Room> Rooms { get; } = new Dictionary<RoomId, Room>();

        public static void SetRoom(RoomId id, Room room) => Rooms[id] = room;

        public static Room GetRoom(RoomId id)
        {
            Rooms.TryGetValue(id, out Room room);
            return room;
        }
    }
    */
}
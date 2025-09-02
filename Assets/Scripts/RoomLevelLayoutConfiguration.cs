using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Room Level Layout", menuName = "Custom/Procedural Generation/RoomLevelLayoutConfiguration")]
public class RoomLevelLayoutConfiguration : ScriptableObject
{
    [SerializeField] int width = 64;
    [SerializeField] int length = 64;

    [SerializeField] RoomTemplate[] roomTemplates;
    [SerializeField] int doorDistanceFromEdge = 1;
    [SerializeField] int minCorridorLength = 2;
    [SerializeField] int maxCorridorLength = 5;
    [SerializeField] int maxRoomCount = 10;
    [SerializeField] int minRoomDistance = 1;

    // Getters (Expression bodied members)
    public int Width => width;
    public int Length => length;

    public RoomTemplate[] RoomTemplates => roomTemplates;
    public int DoorDistanceFromEdge => doorDistanceFromEdge;
    public int MinCorridorLength => minCorridorLength;
    public int MaxCorridorLength => maxCorridorLength;
    public int MaxRoomCount => maxRoomCount;
    public int MinRoomDistance => minRoomDistance;

    public Dictionary<RoomTemplate, int> GetAvailableRooms()
    {
        Dictionary<RoomTemplate, int> availableRooms = new Dictionary<RoomTemplate, int>();
        for (int i = 0; i < roomTemplates.Length; i++)
        {
            availableRooms.Add(roomTemplates[i], roomTemplates[i].NumberOfRooms);
        }
        availableRooms = availableRooms.Where(kvp => kvp.Value > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        return availableRooms;
    }
}

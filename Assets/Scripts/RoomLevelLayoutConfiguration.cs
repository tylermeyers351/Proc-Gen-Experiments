using UnityEngine;

[CreateAssetMenu(fileName = "Room Level Layout", menuName = "Custom/Procedural Generation/RoomLevelLayoutConfiguration")]
public class RoomLevelLayoutConfiguration : ScriptableObject
{
    [SerializeField] int width = 64;
    [SerializeField] int length = 64;

    [SerializeField] int roomWidthMin = 3;
    [SerializeField] int roomWidthMax = 5;
    [SerializeField] int roomLengthMin = 3;
    [SerializeField] int roomLengthMax = 5;
    [SerializeField] int doorDistanceFromEdge = 1;
    [SerializeField] int minCorridorLength = 2;
    [SerializeField] int maxCorridorLength = 5;
    [SerializeField] int maxRoomCount = 10;
    [SerializeField] int minRoomDistance = 1;

    // Getters (Expression bodied members)
    public int Width => width;
    public int Length => length;

    public int RoomWidthMin => roomWidthMin;
    public int RoomWidthMax => roomWidthMax;
    public int RoomLengthMin => roomLengthMin;
    public int RoomLengthMax => roomLengthMax;
    public int DoorDistanceFromEdge => doorDistanceFromEdge;
    public int MinCorridorLength => minCorridorLength;
    public int MaxCorridorLength => maxCorridorLength;
    public int MaxRoomCount => maxRoomCount;
    public int MinRoomDistance => minRoomDistance;
}

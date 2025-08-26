using System.Collections.Generic;
using UnityEngine;

public class Room
{
    RectInt area;
    public RectInt Area { get { return area; } }

    public Room(RectInt area)
    {
        this.area = area;
    }

    // The paramters (inputs) are the room width, room length, and distance from the corner (edge) to allow doors.
    public List<Hallway> CalculateAllPossibleDoorways(int width, int length, int minDistanceFromEdge)
    {
        List<Hallway> hallwayCandidates = new List<Hallway>();
        hallwayCandidates.Add(new Hallway(new Vector2Int(0, 0)));
        hallwayCandidates.Add(new Hallway(new Vector2Int(width, length)));
        return hallwayCandidates;
    }
}

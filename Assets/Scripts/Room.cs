using UnityEngine;

public class Room
{
    RectInt area;
    public RectInt Area { get { return area; } }

    public Room(RectInt area)
    {
        this.area = area;
    }
}

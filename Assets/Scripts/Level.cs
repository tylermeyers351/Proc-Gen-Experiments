using System.Collections.Generic;
using UnityEngine;

public class Level
{
    int width;
    int length;
    List<Hallway> hallways;
    List<Room> rooms;

    public int Width { get { return width; } set { width = value; } }
    public int Length { get { return length; } set { length = value; } }

    public Level(int width, int length)
    {
        this.width = width;
        this.length = length;
        hallways = new List<Hallway>();
        rooms = new List<Room>();
    }
}

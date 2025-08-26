using System;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGeneratorRoom : MonoBehaviour
{
    [SerializeField] int width = 64;
    [SerializeField] int length = 64;

    [SerializeField] int roomWidthMin = 3;
    [SerializeField] int roomWidthMax = 5;
    [SerializeField] int roomLengthMin = 3;
    [SerializeField] int roomLengthMax = 5;

    [SerializeField] GameObject levelLayoutDisplay;
    [SerializeField] List<Hallway> openDoorways;

    System.Random random;
    Level level;

    [ContextMenu("Generate Level Layout")]
    public void GenerateLevel()
    {
        random = new System.Random();
        openDoorways = new List<Hallway>();
        level = new Level(width, length);
        var roomRect = GetStartRoomRect();
        Debug.Log(roomRect);
        Room room = new Room(roomRect);
        List<Hallway> hallways = room.CalculateAllPossibleDoorways(room.Area.width, room.Area.height, 1);
        hallways.ForEach((h) => h.StartRoom = room);
        hallways.ForEach((h) => openDoorways.Add(h));
        level.AddRoom(room);

        Room testRoom1 = new Room(new RectInt(3, 6, 6, 10));
        Room testRoom2 = new Room(new RectInt(15, 4, 10, 12));
        Hallway testHallway = new Hallway(HallwayDirection.Right, new Vector2Int(6, 3), testRoom1);
        testHallway.EndPosition = new Vector2Int(0, 5);
        testHallway.EndRoom = testRoom2;
        level.AddRoom(testRoom1);
        level.AddRoom(testRoom2);
        level.AddHallway(testHallway);

        DrawLayout(roomRect);
    }

    RectInt GetStartRoomRect()
    {
        int roomWidth = random.Next(roomWidthMin, roomWidthMax);
        int availableWidthX = (width / 2) - roomWidth;
        int randomX = random.Next(0, availableWidthX);
        int roomX = randomX + (width / 4);

        int roomLength = random.Next(roomLengthMin, roomLengthMax);
        int availableLengthY = (length / 2) - roomLength;
        int randomY = random.Next(0, availableLengthY);
        int roomY = randomY + (length / 4);

        return new RectInt(roomX, roomY, roomWidth, roomLength);
    }

    void DrawLayout(RectInt roomCandidateRect = new RectInt())
    {
        var renderer = levelLayoutDisplay.GetComponent<Renderer>();

        var layoutTexture = (Texture2D) renderer.sharedMaterial.mainTexture;

        layoutTexture.Reinitialize(width, length);
        levelLayoutDisplay.transform.localScale = new Vector3(width, length, 1);
        layoutTexture.FillWithColor(Color.black);

        Array.ForEach(level.Rooms, room => layoutTexture.DrawRectangle(room.Area, Color.white));
        Array.ForEach(level.Hallways, hallway => layoutTexture.DrawLine(hallway.StartPositionAbsolute, hallway.EndPositionAbsolute, Color.white));

        layoutTexture.DrawRectangle(roomCandidateRect, Color.white);

        foreach (Hallway hallway in openDoorways)
        {
            layoutTexture.SetPixel(hallway.StartPositionAbsolute.x, hallway.StartPositionAbsolute.y, hallway.StartDirection.GetColor());
        }

        layoutTexture.SaveAsset();
    }

}

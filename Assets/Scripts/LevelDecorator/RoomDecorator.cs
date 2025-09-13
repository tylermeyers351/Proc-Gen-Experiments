using UnityEditorInternal;
using UnityEngine;
using Random = System.Random;

public class RoomDecorator : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] LayoutGeneratorRoom layoutGenerator;

    Random random;

    [ContextMenu("Place Items")]
    public void PlaceItemsFromMenu()
    {
        SharedLevelData.Instance.ResetRandom();
        Level level = layoutGenerator.GenerateLevel();
        PlaceItems(level);
    }

    public void PlaceItems(Level level)
    {
        random = SharedLevelData.Instance.Rand;

        // The transform of the game object named "Decorations". This is found by searching the children of "Level Geometry".
        Transform decorationsTransform = parent.transform.Find("Decorations");

        // If it doesn't exist...
        if (decorationsTransform == null)
        {
            GameObject decorationsGameObject = new GameObject("Decorations");
            decorationsTransform = decorationsGameObject.transform;
            decorationsTransform.SetParent(parent.transform);
        }
        // if it returns null (there is no "Decorations" game object childed within the parent transform.)
        else
        {
            decorationsTransform.DestroyAllChildren();
        }

        GameObject testGameObject = new GameObject("Test Game Object");
        testGameObject.transform.SetParent(decorationsTransform);
    }
}

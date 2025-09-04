using UnityEngine;

public class MarchingSquares : MonoBehaviour
{
    [SerializeField] Texture2D levelTexture;
    [ContextMenu("Create Level Geometry")]
    public void CreateLevelGeometry()
    {
        TextureBasedLevel level = new TextureBasedLevel(levelTexture);
    }
}

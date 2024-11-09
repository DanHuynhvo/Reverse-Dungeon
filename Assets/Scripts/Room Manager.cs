using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject floorTile;
    public int width;
    public int height;
    public Vector3 position = Vector3.zero;

    void Start()
    {
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                position.x = i; position.y = j;
                Instantiate(floorTile, position, Quaternion.identity);
            }
        }
    }
}

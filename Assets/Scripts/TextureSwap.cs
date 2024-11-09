using UnityEngine;

public class TextureSwap : MonoBehaviour
{
    public Sprite tileSprite;
    public Sprite wallSprite;
    public GameObject room;


    private void Start()
    {
        for (int i = 0; i < room.transform.childCount; i++)
        {

            if (room.transform.GetChild(i).gameObject.tag == "Floor")
            {
                room.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = tileSprite;
            }

            else
            {
                room.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = wallSprite;
            }
        }
    }
}

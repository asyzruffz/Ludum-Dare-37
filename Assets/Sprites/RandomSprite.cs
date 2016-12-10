using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

    public Sprite[] sprites;
    public string ResourceName;
    public int currentsprite = -1;


    // Use this for initialization
    void Start()
    {
        if (ResourceName != "")
        {
            sprites = Resources.LoadAll<Sprite>(ResourceName);
            if (currentsprite == -1)
            {
                currentsprite = Random.Range(0, sprites.Length);
            }
            else if (currentsprite > sprites.Length)
            {
                currentsprite = 1;
            }
            GetComponent<SpriteRenderer>().sprite = sprites[currentsprite];
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var heightmap = Resources.Load<Texture2D>("Textures/Heightmap_16");
        string[] prefabNames = { "Water", "Sand", "Grass", "Forest", "Stone", "Mountain" };

        for(int x=1;x<=heightmap.width;x++)
        {
            for(int z=1;z<=heightmap.height;z++)
            {
                var pixelColor = heightmap.GetPixel(x, z);
                var colorValue = Math.Max(pixelColor.r, Math.Max(pixelColor.g, pixelColor.b));
                string name = prefabNames[(int) Math.Ceiling(colorValue*5)];
                GameObject tile = Instantiate(Resources.Load("Prefabs/" + name + "Tile"), new Vector3(z*8,colorValue*50,x*10+(z%2==0 ? 0 : 5)), Quaternion.identity) as GameObject;
                tile.name = name;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

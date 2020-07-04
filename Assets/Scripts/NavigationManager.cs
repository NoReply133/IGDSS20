using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    //GameManager gameManager; //Reference to GameManager
    public static NavigationManager Instance; //Singleton of this manager. Can be called with static reference NavigationManager.Instance
    Dictionary<Tile.TileTypes, int> _weightValues = new Dictionary<Tile.TileTypes, int>()
                                            {
                                                {Tile.TileTypes.Water,30},
                                                {Tile.TileTypes.Sand, 2},
                                                {Tile.TileTypes.Grass,1},
                                                {Tile.TileTypes.Forest,2},
                                                {Tile.TileTypes.Stone,1},
                                                {Tile.TileTypes.Mountain,3}
                                            };

    //Awake is called when creating this object
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[,] generateMap(Tile tile, GameManager gameManager)
    {
        int[,] pathFindingMap = new int[gameManager._heightMap.height, gameManager._heightMap.width];

        // each tile is assigned a weight value, depending on its type
        for (int h = 0; h < gameManager._heightMap.height; h++)
        {
            for (int w = 0; w < gameManager._heightMap.width; w++)
            {
                pathFindingMap[h, w] = _weightValues[gameManager._tileMap[h, w]._type];
            }
        }

        // The tile the building is standing on however has a weight value of 0. 
        pathFindingMap[tile._coordinateHeight, tile._coordinateWidth] = 0;

        // From there, recursively take all neighboring tiles and set their weight to the total weight up to this point plus their own weight value. This simulates the ease of travel each tile type allows.
        // ???
        // ???
        // ???

        return pathFindingMap;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a chessboard-like grid





public class Tiler : MonoBehaviour
{

    public GameObject tile_light;
    public GameObject tile_dark;

    public int rows;
    public int columns;
    float tile_size = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int row=0; row < rows; row++)
        {
            for (int column=0; column < columns; column++)
            {
                if ((row + column) % 2 == 0)
                {
                    Instantiate(tile_light, new Vector3(row * tile_size, 1.0f, column * tile_size), Quaternion.identity);
                }
                else
                {
                    Instantiate(tile_dark, new Vector3(row * tile_size, 1.0f, column * tile_size), Quaternion.identity);
                };
            };
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

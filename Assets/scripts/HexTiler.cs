using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTiler : MonoBehaviour
{
    private static float hex_ratio = 0.866025f;


    // q, r, and s sizes for 3 axis hex addressing
    public int q_size;
    public int r_size;
    public int s_size;

    public GameObject hextile;
    public float hex_size;

    public Material mat_r;
    public Material mat_g;
    public Material mat_b;

 


    // Start is called before the first frame update
    void Start()
    {
        Material[] mats = new Material[3];

        mats[0] = mat_r;
        mats[1] = mat_g;
        mats[2] = mat_b;                

        bool offset = false;
        GameObject newHex;
        float x = 0.0f;
        float z = 0.0f;
        float hex_shift = hex_size * hex_ratio;

        // draw the grid
        for (int column = 0; column < q_size; column++)
        {
            if (offset == true)
            {
                z = hex_size * 0.5f;
            }
            else {
                z = 0;
            }

            for (int row = 0; row < r_size; row++)
            {
                
                // place hex
                newHex = Instantiate(hextile, new Vector3(x, 1.0f, z), Quaternion.identity);
                var hexcolor = newHex.GetComponent<Renderer>();
                //hexcolor.material.setColor("_Color", Color.red);
                hexcolor.material = mats[Random.Range(0,3)];

                // z += hex_shift;
                z += hex_size;
            }

            // shift coords along
            x += (hex_size * hex_ratio);

            offset = !offset;

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

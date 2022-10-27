using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseClick : MonoBehaviour
{

    public GameObject player_piece;
    Vector3 UpABit = new Vector3(0, 1.0f, 0);
    private RaycastHit hit;
    private GameObject stored;
    private Color revert;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.layer == 8)
                {
                    // HOVERING OVER HEXTILE
                    if (hit.transform.gameObject != stored)
                    {
                        // new target
                        if (stored != null)
                        {
                            stored.GetComponent<Renderer>().material.color = revert;
                        }
                        revert = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                        hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                        stored = hit.transform.gameObject;
                    }

                    //PrintName(hit.transform.gameObject);

                    // CLICKED
                    if(Input.GetMouseButtonDown(0))
                    {
                        player_piece.transform.position = hit.transform.position + UpABit;
                    }
                }
            }
        }
        
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }
}

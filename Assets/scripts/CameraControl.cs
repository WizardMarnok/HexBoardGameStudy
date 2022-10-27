using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject cam;
    public GameObject camFocus;    // an "empty" to look at 
    public GameObject myCharacter;  // the "player object". 

    public float cameraAngle;

    public float scrollSpeed = 10.0f;
    public float x_min;
    public float x_max;
    public float z_min;
    public float z_max;
   
    public float rotateSpeed = 1.0f;    // how fast it turns
    public float rotateDelay = 1.0f;    // how long to wait before allowing another turn
 
    public float zoomSpeed = 10.0f;
    public float zoomMax = 20.0f;       // don't go further back than this
    public float zoomMin = 3.0f;        // don't go further in than this
    private float zoomCurrent;

    private float x_current;
    private float z_current;
    private float rotation_current = 0.0f;
    private bool rotating = false;

    // Start is called before the first frame update
    void Start()
    {
        zoomCurrent = (zoomMax + zoomMin) * 0.5f;
        x_current = (x_max - x_min) * 0.5f;
        z_current = (z_max - z_min) * 0.5f;
        //cam.transform.LookAt(camFocus.transform);
        
    }



    // Update is called once per frame
    void LateUpdate()
    {
        // WASD - scroll
        // QE - rotate (lerp to 30 degrees)
        // mouse wheel - zoom in/out
        // ? mouse click and hold - scroll

        // ROTATION
        // Find centre of view target; 
        // Ray, measure along distance

        if(Input.GetKey(KeyCode.W))
        {
            camFocus.transform.position -= camFocus.transform.TransformDirection(new Vector3(0, 0, scrollSpeed * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.S))
        {
            camFocus.transform.position += camFocus.transform.TransformDirection(new Vector3(0, 0, scrollSpeed * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.A))
        {
            camFocus.transform.position += camFocus.transform.TransformDirection(new Vector3(scrollSpeed * Time.deltaTime, 0, 0));
        }

        if(Input.GetKey(KeyCode.D))
        {
            camFocus.transform.position -= camFocus.transform.TransformDirection(new Vector3(scrollSpeed * Time.deltaTime, 0, 0));
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            camFocus.transform.Rotate(0, 30.0f, 0);
            //cam.transform.Rotate(-300f, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            camFocus.transform.Rotate(0, -30.0f, 0);
            //cam.transform.Rotate(30.0f, 0, 0);
        }

                // Snap to player object
         if(Input.GetKeyDown(KeyCode.F))
        {
            camFocus.transform.position = myCharacter.transform.position;
        }     


        // Zoom
        float scrolling = Input.GetAxis("Mouse ScrollWheel");
        zoomCurrent -= scrolling * zoomSpeed;
        zoomCurrent = Mathf.Clamp(zoomCurrent, zoomMin, zoomMax);
        cam.transform.localPosition = new Vector3(0, zoomCurrent * 0.5f, zoomCurrent);

        // finally
        cam.transform.LookAt(camFocus.transform);
    }
}

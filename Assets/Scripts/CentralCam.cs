using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[RequireComponent(typeof(Camera))]
public class CentralCam : MonoBehaviour
{
    public Controller player1;
    public Controller player2;
    private Camera cam;

    public Vector3 Offset = new Vector3(0, 5,0);

	// Use this for initialization
	void Start ()
	{
	    cam = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	    var center = (player1.transform.position + player2.transform.position) / 2.0f;


        //cam.transform.rotation = Quaternion.identity;
	    cam.transform.position = Offset + center + new Vector3(0, 0, 0);


	}
}

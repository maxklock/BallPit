using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[RequireComponent(typeof(Camera))]
public class CentralCam : MonoBehaviour
{
    public Controller Player1;
    public Controller Player2;

    public float MaxXDistance = 8;
    public float MaxZDistance = 6;

    private Camera _cam;

    public Vector3 Offset;

	// Use this for initialization
	void Start ()
	{
        _cam = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!Player1.isActiveAndEnabled && !Player2.isActiveAndEnabled)
	    {
	        _cam.transform.position = Offset;
	        return;
	    }
	    if (!Player1.isActiveAndEnabled)
	    {
	        _cam.transform.position = Player2.transform.position + Offset;
	        return;
        }
        if (!Player2.isActiveAndEnabled)
        {
            _cam.transform.position = Player1.transform.position + Offset;
            return;
        }

        var center = (Player1.transform.position + Player2.transform.position) / 2.0f;
	    var z = Mathf.Min(Player1.transform.position.z, Player2.transform.position.z);
	    var distX = Mathf.Max(0, Mathf.Abs(Player1.transform.position.x - Player2.transform.position.x) - MaxXDistance);
        var distZ = Mathf.Max(0, Mathf.Abs(Player1.transform.position.z - Player2.transform.position.z) - MaxZDistance);

        center.z = z - distX;
        center.y += Mathf.Max(distX, distZ);
        
        _cam.transform.position = Offset + center;

	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlateController : MonoBehaviour
{
    public List<PressurePlate> PressurePlates = new List<PressurePlate>();
    public List<InfluencedObject> InfluencedObjects = new List<InfluencedObject>();


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!(PressurePlates.Count > 0)) return;


	    bool platesActive = true;
	    foreach (var plate in PressurePlates)
	    {
	        if (!plate.IsActivated)
	        {
	            platesActive = false;
	            break;
	        }
	    }

	    if (platesActive)
	    {
	        foreach (var obj in InfluencedObjects)
	        {
	            obj.IsActivated = true;
	        }

	    }
	
	}
}

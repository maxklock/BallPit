using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour
{

    public bool IsActivated { get; set; }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collisionInfo)
    {

        if (collisionInfo.transform.parent.gameObject.GetComponent<Controller>() != null)
            IsActivated = true;
    }


    void OnTriggerStay(Collider collisionInfo)
    {

        if (collisionInfo.transform.parent.gameObject.GetComponent<Controller>() != null)
            IsActivated = true;
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.transform.parent.gameObject.GetComponent<Controller>() != null)
            IsActivated = false;
    }
}

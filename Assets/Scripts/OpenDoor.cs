using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InfluencedObject))]
public class OpenDoor : MonoBehaviour
{
    private InfluencedObject state;

	// Use this for initialization
	void Start ()
	{
	    state = this.gameObject.GetComponent<InfluencedObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(state.IsActivated)
            GameObject.Destroy(this.gameObject);
	}
}

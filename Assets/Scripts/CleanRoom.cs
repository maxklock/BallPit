using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Objects;

[RequireComponent(typeof(InfluencedObject))]
public class CleanRoom : MonoBehaviour
{


    public float TimeToDespawn = 1f;
    [Range(0.01f,1f)]
    public float DespawnSpeed = 0.9f;

    List<Ball> balls;


    private InfluencedObject _state;
    private bool _ended = false;

    // Use this for initialization
    void Start()
    {
        _state = this.gameObject.GetComponent<InfluencedObject>();
    }


    // Update is called once per frame
    void Update ()
    {

        if (_state.IsActivated && !_ended) StartCoroutine(CleanUpRoom());


	    if (balls != null && balls.Count > 0)
	    {
	        foreach (var ball in balls)
	        {
	            ball.gameObject.transform.localScale *= DespawnSpeed;
	        }
	    }
	
	}


    private IEnumerator CleanUpRoom()
    {
        _ended = true;
        balls = new List<Ball>();

        balls.AddRange(FindObjectsOfType<Ball>());

        yield return new WaitForSeconds(TimeToDespawn);

        if (balls != null && balls.Count > 0)
        {
            foreach (var ball in balls)
            {


                GameObject.Destroy(ball.gameObject);
                
            }
        }
        balls.Clear();


    }

 

    public void DeleteAllBalls()
    {


    }

}

using System.Collections;
using System.Collections.Generic;

using Objects;

using Spawner;

using UnityEngine;

[RequireComponent(typeof(InfluencedObject))]
public class CleanRoom : MonoBehaviour
{
    #region member vars

    private bool _ended;

    private InfluencedObject _state;

    List<GameObject> balls;

    [Range(0.01f, 1f)]
    public float DespawnSpeed = 0.9f;

    public float TimeToDespawn = 1f;


    #endregion

    #region methods


    private IEnumerator CleanUpRoom()
    {
        _ended = true;
        balls = new List<GameObject>();

        balls.AddRange(GameObject.FindGameObjectsWithTag("Ball"));

        

        yield return new WaitForSeconds(TimeToDespawn);

        if (balls != null && balls.Count > 0)
        {
            for (int i = balls.Count - 1; i >= 0; i--)
            {
                Destroy(balls[i].gameObject);
                balls.RemoveAt(i);
            }
        }

        balls.Clear();
        BallSpawner.BallCount = 0;
        RoomCleaned = true;
    }

    // Use this for initialization
    void Start()
    {
        _state = gameObject.GetComponent<InfluencedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RoomCleaned) return;

        if (_state.IsActivated && !_ended) StartCoroutine(CleanUpRoom());

        if (balls != null && balls.Count > 0 && _ended)
        {
            for (int i = balls.Count - 1; i >= 0; i--)
            {
                if (balls[i] == null) balls.Remove(balls[i]);
                else balls[i].gameObject.transform.localScale *= DespawnSpeed;
            }
        }

        
    }

    #endregion

    #region properties

    public bool RoomCleaned { get; private set; }

    #endregion
}
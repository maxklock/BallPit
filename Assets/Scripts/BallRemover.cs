using System;

using UnityEngine;

public class BallRemover : MonoBehaviour
{
    #region events

    public static event EventHandler BallRemoved;

    #endregion

    #region methods

    private void OnTriggerEnter(Collider coll)
    {
        BallSpawner.BallCount--;
        Destroy(coll.gameObject);
        if (BallRemoved != null)
        {
            BallRemoved.Invoke(this, null);
        }
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #endregion
}
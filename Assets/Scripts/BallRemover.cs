using System;

using Objects;

using Spawner;

using UnityEngine;

public class BallRemover : MonoBehaviour
{

    #region methods

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Ball>() != null)
        {
            BallSpawner.BallCount--;
        }
        if (coll.GetComponent<Item>() != null)
        {
            ItemSpawner.ItemCount--;
        }

        Destroy(coll.gameObject);
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
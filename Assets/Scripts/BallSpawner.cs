using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region member vars

    private Collider _collider;
    public int MaxObjects = 1000;

    public GameObject SpawnObject;
    public int SpawnPerFrame = 2;

    #endregion

    #region constants

    public static int BallCount;

    #endregion

    #region methods

    public void Spawn()
    {
        var pos = Utils.RandomBoundsPosition(_collider.bounds);
        var obj = Instantiate(SpawnObject);
        obj.transform.position = pos;
        obj.transform.parent = transform;

        BallCount++;
    }

    // Use this for initialization
    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    private void Update()
    {
        for (var i = 0; i < SpawnPerFrame && BallCount < MaxObjects; i++)
        {
            Spawn();
        }
    }

    #endregion
}
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    #region member vars

    private Collider _collider;
    private float _timer;

    public int MaxBalls = 1000;
    public Ball Ball;
    public int BallsPerFrame = 2;
    public Item Item;
    public int ItemsPerMinute = 10;

    #endregion

    #region constants

    public static int BallCount;

    #endregion

    #region methods

    public void Spawn()
    {
        var pos = Utils.RandomBoundsPosition(_collider.bounds);
        var obj = Instantiate(Ball);
        obj.transform.position = pos;
        obj.transform.parent = transform;

        BallCount++;
    }

    public void SpawnItem()
    {
        var pos = Utils.RandomBoundsPosition(_collider.bounds);
        var obj = Instantiate(Item);
        obj.transform.position = pos;
        obj.transform.parent = transform;
    }

    // Use this for initialization
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _timer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        for (var i = 0; i < BallsPerFrame && BallCount < MaxBalls; i++)
        {
            Spawn();
        }

        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            SpawnItem();
            _timer = 60f / ItemsPerMinute;
        }
    }

    #endregion
}
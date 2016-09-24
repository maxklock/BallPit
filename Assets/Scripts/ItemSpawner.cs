using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    #region member vars

    private Collider _collider;
    private float _timer;
    public Item Item;
    public int ItemsPerMinute = 10;

    #endregion

    #region methods

    public void Spawn()
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
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Spawn();
            _timer = 60f / ItemsPerMinute;
        }
    }

    #endregion
}
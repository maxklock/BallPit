using UnityEngine;

public class ShakeIt : MonoBehaviour
{
    #region member vars

    private Vector3 _origin;
    public bool IsActive = true;

    public float Speed = 5;

    #endregion

    #region methods

    // Use this for initialization
    private void Start()
    {
        _origin = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(_origin, transform.position) < 0.001 && IsActive)
        {
            var vect = Random.onUnitSphere * Speed / 10f;
            transform.Translate(vect);
        }
        else
        {
            transform.position = _origin;
        }
    }

    #endregion
}
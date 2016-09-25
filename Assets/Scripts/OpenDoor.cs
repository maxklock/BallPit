using UnityEngine;

[RequireComponent(typeof(InfluencedObject))]
public class OpenDoor : MonoBehaviour
{
    #region member vars

    public float DoorMoveDistance = 3;
    public float DoorMoveSpeed = 0.012f;

    private float _doorDistance;
    private InfluencedObject _state;

    #endregion

    #region methods

    // Use this for initialization
    void Start()
    {
        _state = gameObject.GetComponent<InfluencedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_state.IsActivated)
        {
            gameObject.transform.localPosition += gameObject.transform.rotation * Vector3.forward * DoorMoveSpeed;
            _doorDistance += DoorMoveSpeed;

            if (_doorDistance > DoorMoveDistance) Destroy(gameObject);
        }
    }

    #endregion
}
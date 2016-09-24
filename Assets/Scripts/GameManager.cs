using System.Linq;

using UnityEngine;

using UserInterface;

public class GameManager : MonoBehaviour
{
    #region member vars

    public Loading Loading;
    public ShakeIt Room;

    private bool _isLoading;
    private Controller[] _controllers;

    #endregion

    #region methods

    // Use this for initialization
    private void Start()
    {
        _isLoading = true;
        _controllers = FindObjectsOfType<Controller>();
        foreach (var controller in _controllers)
        {
            controller.enabled = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isLoading && !Loading.enabled)
        {
            _isLoading = true;
            Loading.gameObject.SetActive(false);
            foreach (var controller in _controllers)
            {
                controller.enabled = true;
            }
            Room.IsActive = false;
        }
    }

    #endregion
}
using System.Linq;

using UnityEngine;

using UserInterface;

public class GameManager : MonoBehaviour
{
    #region member vars

    public Loading Loading;
    public Controller Player;
    public ShakeIt Room;

    #endregion

    #region methods

    // Use this for initialization
    private void Start()
    {
        Player.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Player.enabled && !Loading.enabled)
        {
            Loading.gameObject.SetActive(false);
            Player.enabled = true;
            Room.IsActive = false;
        }
    }

    #endregion
}
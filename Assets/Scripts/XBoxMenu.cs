using UnityEngine;

public class XBoxMenu : MonoBehaviour
{
    private MainMenu _menu;

    private bool _horizontalUp;
    private bool _horizontalDown;
    private bool _verticalLeft;
    private bool _verticalRight;

    #region methods

    // Use this for initialization
    private void Start()
    {
        _menu = FindObjectOfType<MainMenu>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Horizontal Menu") > 0.5f)
        {
            _horizontalUp = true;
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal Menu")) < 0.1f && _horizontalUp)
        {
            _menu.Player.value++;
            _horizontalUp = false;
        }

        if (Input.GetAxis("Horizontal Menu") < -0.5f)
        {
            _horizontalDown = true;
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal Menu")) < 0.1f && _horizontalDown)
        {
            _menu.Player.value--;
            _horizontalDown = false;
        }

        if (Input.GetAxis("Vertical Menu") > 0.5f)
        {
            _verticalRight = true;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical Menu")) < 0.1f && _verticalRight)
        {
            _menu.Game.value++;
            _verticalRight = false;
        }
        if (Input.GetAxis("Vertical Menu") < -0.5f)
        {
            _verticalLeft = true;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical Menu")) < 0.1f && _verticalLeft)
        {
            _menu.Game.value--;
            _verticalLeft = false;
        }

        if (Input.GetButton("Submit"))
        {
            _menu.StartGame();
        }
    }

    #endregion
}
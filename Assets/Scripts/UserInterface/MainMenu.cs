using System;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region member vars

    public Dropdown Game;

    public Slider Player;

    public Text Information;

    public Button StartButton;

    public int PlayerCount
    {
        get
        {
            return (int)Player.value;
        }
    }

    public GameType GameMode
    {
        get
        {
            switch (Game.value)
            {
                case 0:
                    return GameType.Sort;
                case 1:
                    return GameType.Collect;
                case 2:
                    return GameType.ChangeRoom;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    #endregion

    #region methods

    public void StartGame()
    {
        IsStarting = true;
    }

    // Use this for initialization
    private void Start()
    {
        IsStarting = false;
        // GameMode.options = Enum.GetValues(typeof(GameType)).OfType<GameType>().Select(type => new Dropdown.OptionData(type.ToString())).ToList();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            Exit();
        }

        switch (GameMode)
        {
            case GameType.Sort:
                Information.text = "You have to sort balls of your color to the corner of your color.";
                break;
            case GameType.Collect:
                Information.text = "You have to collect more green balls than your opponent.";
                break;
            case GameType.ChangeRoom:
                Information.text = "You have to collect more green balls than your opponent. To change the room, you have to activate both pressure plates.\n(2 Players only)";
                break;
        }

        StartButton.interactable = (GameMode != GameType.ChangeRoom || PlayerCount == 2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion

    #region properties

    public bool IsStarting { get; set; }

    #endregion
}
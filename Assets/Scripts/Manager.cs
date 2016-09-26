using System.Linq;

using Behaviours;

using Level;

using Objects;

using Spawner;

using UnityEngine;

using UserInterface;

public class Manager : MonoBehaviour
{
    #region methods

    public GameType Game;
    public Objects.Spawner Spawner;
    public BallRemover Remover;

    private Controller[] _players;
    private PlayerHub[] _playerHubs;
    private Room[] _rooms;
    private Room _currentRoom;
    private ShakeIt _shakeIt;

    public Loading LoadingScreen;
    public MainMenu MainMenu;
    public GameOver GameOver;

    private bool _isLoading;
    private bool _isMenu;
    private ILevel _level;

    // Use this for initialization
    private void Start()
    {
        _isMenu = true;
        _isLoading = false;

        _players = FindObjectsOfType<Controller>();
        _rooms = FindObjectsOfType<Room>();
        _playerHubs = FindObjectsOfType<PlayerHub>();

        MainMenu.gameObject.SetActive(true);
        LoadingScreen.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);

        foreach (var player in _players)
        {
            player.gameObject.SetActive(false);
        }

        foreach (var hub in _playerHubs)
        {
            hub.gameObject.SetActive(false);
        }

        foreach (var room in _rooms)
        {
            room.gameObject.SetActive(false);
        }

        Spawner.BallSpawner.gameObject.SetActive(false);
        Spawner.ItemSpawner.gameObject.SetActive(false);
        Spawner.SortSpawner.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isMenu)
        {
            if (!MainMenu.IsStarting)
            {
                return;
            }

            Game = MainMenu.GameMode;

            _isMenu = false;
            _isLoading = true;

            MainMenu.gameObject.SetActive(false);
            LoadingScreen.gameObject.SetActive(true);

            foreach (var room in _rooms)
            {
                room.gameObject.SetActive(room.Game == Game);
                if (room.Game == Game)
                {
                    _currentRoom = room;
                }
            }
            _shakeIt = _currentRoom.GetComponent<ShakeIt>();
            if (_shakeIt != null)
            {
                _shakeIt.IsActive = true;
            }
            _level = _currentRoom.GetComponent<ILevel>();

            Spawner.BallSpawner.gameObject.SetActive(true);
            Spawner.ItemSpawner.gameObject.SetActive(Game == GameType.Collect);
            Spawner.SortSpawner.gameObject.SetActive(Game == GameType.Sort);
            return;
        }

        if (LoadingScreen.IsLoading)
        {
            return;
        }

        if (_isLoading && !LoadingScreen.IsLoading)
        {
            _isLoading = false;
            LoadingScreen.gameObject.SetActive(false);

            if (_shakeIt != null)
            {
                _shakeIt.IsActive = false;
            }

            for (var i = 0; i < _players.Length && i < MainMenu.PlayerCount; i++)
            {
                _players[i].gameObject.SetActive(true);
                _players[i].GetComponent<CollectItems>().enabled = Game == GameType.Collect;
                _playerHubs.First(hub => hub.Player == _players[i]).gameObject.SetActive(true);
            }
            return;
        }

        if (_level.HasWinner)
        {
            foreach (var player in _players)
            {
                player.gameObject.SetActive(false);
            }
            GameOver.Winner = _level.Winner;
            GameOver.gameObject.SetActive(true);
        }
    }

    #endregion
}
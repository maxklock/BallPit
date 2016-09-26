using Behaviours;

using Level;

using Objects;

using Spawner;

using UnityEngine;

using UserInterface;

public class Manager : MonoBehaviour
{
    #region methods

    public Controller[] Players;

    public GameType Game;

    public Objects.Spawner Spawner;

    public BallRemover Remover;

    public Room[] Rooms;
    private Room _currentRoom;
    private ShakeIt _shakeIt;

    public Loading LoadingScreen;
    public MainMenu MainMenu;

    private bool _isLoading;
    private bool _isMenu;
    private ILevel _level;

    // Use this for initialization
    private void Start()
    {
        _isMenu = true;
        _isLoading = false;

        MainMenu.gameObject.SetActive(true);
        LoadingScreen.gameObject.SetActive(false);

        foreach (var player in Players)
        {
            player.gameObject.SetActive(false);
        }

        foreach (var room in Rooms)
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
            // TODO PlayerCount;

            _isMenu = false;
            _isLoading = true;

            MainMenu.gameObject.SetActive(false);
            LoadingScreen.gameObject.SetActive(true);

            foreach (var room in Rooms)
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

            foreach (var player in Players)
            {
                player.gameObject.SetActive(true);
                player.GetComponent<CollectItems>().enabled = Game == GameType.Collect;
            }
            return;
        }

        if (_level.HasWinner)
        {
            Debug.Log("And the winner is: " + _level.Winner);
        }
    }

    #endregion
}
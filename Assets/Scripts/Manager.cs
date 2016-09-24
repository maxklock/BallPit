using Behaviours;

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

    private bool _isLoading;

    // Use this for initialization
    private void Start()
    {
        _isLoading = true;
        LoadingScreen.gameObject.SetActive(true);
        foreach (var player in Players)
        {
            player.gameObject.SetActive(false);
        }

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

        Spawner.BallSpawner.gameObject.SetActive(true);
        Spawner.ItemSpawner.gameObject.SetActive(Game == GameType.Collect);
        Spawner.SortSpawner.gameObject.SetActive(Game == GameType.Sort);
    }

    // Update is called once per frame
    private void Update()
    {
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
        }
    }

    #endregion
}
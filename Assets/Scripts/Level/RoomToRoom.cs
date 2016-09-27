using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Behaviours;

using Level;

using Spawner;

using UnityEngine;

public class RoomToRoom : MonoBehaviour, ILevel
{
    #region member vars

    private CollectItems[] _collectItems;

    private bool _lastWaveSpawned;

    private StageRoom _stRoom = StageRoom.A;

    public BallSpawner ballSpawner;
    public List<InfluencedObject> RoomsInfluenced = new List<InfluencedObject>();
    public ItemSpawner Spawner;

    #endregion

    #region enums

    public enum StageRoom
    {
        A,
        B,
        C,
        D
    }

    #endregion

    #region explicit interfaces

    public bool HasWinner { get; private set; }

    public SortColor Winner { get; private set; }

    #endregion

    #region methods

    IEnumerator OnSpawn()
    {
        yield return new WaitForSeconds(3);
        Spawner.SpawnWave();
        if (_stRoom == StageRoom.D) _lastWaveSpawned = true;
    }

    // Use this for initialization
    void Start()
    {
        _collectItems = new CollectItems[0];
        StartCoroutine(OnSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (HasWinner) return;

        if (_collectItems.Length == 0)
        {
            _collectItems = FindObjectsOfType<CollectItems>();
            if (_collectItems.Length > 0)
            {
                _collectItems = _collectItems.Where(c => c.isActiveAndEnabled).ToArray();
            }
        }

        switch (_stRoom)
        {
            case StageRoom.A:
                if (RoomsInfluenced[0].gameObject.GetComponent<CleanRoom>().RoomCleaned)
                {
                    _stRoom = StageRoom.B;
                    ballSpawner.transform.parent.position = RoomsInfluenced[1].transform.position;
                    StartCoroutine(OnSpawn());
                }
                break;
            case StageRoom.B:
                if (RoomsInfluenced[1].gameObject.GetComponent<CleanRoom>().RoomCleaned)
                {
                    _stRoom = StageRoom.C;
                    ballSpawner.transform.parent.position = RoomsInfluenced[2].transform.position;
                    StartCoroutine(OnSpawn());
                }
                break;
            case StageRoom.C:
                if (RoomsInfluenced[2].gameObject.GetComponent<CleanRoom>().RoomCleaned)
                {
                    _stRoom = StageRoom.D;
                    ballSpawner.transform.parent.position = RoomsInfluenced[3].transform.position;
                    StartCoroutine(OnSpawn());
                }
                break;
            case StageRoom.D:
                if (ItemSpawner.ItemCount <= 0 && _lastWaveSpawned)
                {
                    if (_collectItems[0].Collected > _collectItems[1].Collected)
                    {
                        Winner = _collectItems[0].GetComponent<Controller>().Color;
                        HasWinner = true;
                    }
                    else if (_collectItems[1].Collected > _collectItems[0].Collected)
                    {
                        Winner = _collectItems[1].GetComponent<Controller>().Color;
                        HasWinner = true;
                    }
                    else
                    {
                        ItemSpawner.ItemCount = 0;
                        Spawner.SpawnWave();
                    }
                }
                break;
        }
    }

    #endregion
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Spawner;

public class GameManagerRoomToRoom : MonoBehaviour
{
    public BallSpawner ballSpawner; 
    public List<InfluencedObject> RoomsInfluenced = new List<InfluencedObject>();

    private StageRoom stRoom = StageRoom.A;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (stRoom)
        {
            case StageRoom.A:
                if (RoomsInfluenced[0].IsActivated)
                {
                    stRoom = StageRoom.B;
                    ballSpawner.transform.position = RoomsInfluenced[0].transform.position;

                }
                break;

        }

    }

    public enum StageRoom
    {
        A,
        B,
        C,
        D
    }

}


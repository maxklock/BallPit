using System.Collections.Generic;

using Spawner;

using UnityEngine;

public class GameManagerRoomToRoom : MonoBehaviour
{
    #region member vars

    public BallSpawner ballSpawner;
    public List<InfluencedObject> RoomsInfluenced = new List<InfluencedObject>();

    private StageRoom stRoom = StageRoom.A;

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

    #region methods

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
                if (RoomsInfluenced[0].gameObject.GetComponent<CleanRoom>().RoomCleaned)
                {
                    stRoom = StageRoom.B;
                    ballSpawner.transform.parent.position = RoomsInfluenced[1].transform.position;
                }
                break;
            case StageRoom.B:
                if (RoomsInfluenced[1].gameObject.GetComponent<CleanRoom>().RoomCleaned)
                {
                    stRoom = StageRoom.C;
                    ballSpawner.transform.parent.position = RoomsInfluenced[2].transform.position;
                }
                break;
            case StageRoom.C:
                if (RoomsInfluenced[2].gameObject.GetComponent<CleanRoom>().RoomCleaned)
                {
                    stRoom = StageRoom.D;
                    ballSpawner.transform.parent.position = RoomsInfluenced[3].transform.position;
                }
                break;

        }
    }

    #endregion
}
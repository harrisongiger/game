using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomGenerator : MonoBehaviour
{
    public GameObject emptyPrefab;
    public GameObject cornerPrefab;
    public GameObject onePrefab;
    public GameObject twoPrefab;
    public GameObject threePrefab;
    public GameObject fourPrefab;



    //private List<Tuple<GameObject, int, int, int, int>> roomsIn;
    private List<RoomFiller> rooms;
    [SerializeField]
    private List<GameObject> roomGrid;

    public int griddyWidth;
    public int griddyLength;
    //public RoomFiller[][] grid;
    RoomInfo[] roomInfos;

    public static int initRoomIndex;

    void Start()
    { 
        rooms = new List<RoomFiller>();

        roomInfos = new RoomInfo[6];
        roomInfos[0] = new RoomInfo(emptyPrefab, WallType.empty, WallType.empty, WallType.empty, WallType.empty);
        roomInfos[1] = new RoomInfo(onePrefab, WallType.door, WallType.wall, WallType.wall, WallType.wall);
        roomInfos[2] = new RoomInfo(twoPrefab, WallType.door, WallType.wall, WallType.door, WallType.wall);
        roomInfos[3] = new RoomInfo(threePrefab, WallType.door, WallType.door, WallType.wall, WallType.door);
        roomInfos[4] = new RoomInfo(fourPrefab, WallType.door, WallType.door, WallType.door, WallType.door);
        roomInfos[5] = new RoomInfo(cornerPrefab, WallType.door, WallType.door, WallType.wall, WallType.wall);



        // jesse's code
        //copy input into roomfiller objects
        //roomsIn = new List<Tuple<GameObject, int, int, int, int>>();
        //foreach (Tuple<GameObject,int,int,int,int> i in roomsIn)
        // {
        //    rooms.Add(new RoomFiller(i.Item1, i.Item2, i.Item3, i.Item4, i.Item5));
        // }
        // //create adjacent room lists
        // foreach(RoomFiller i in rooms)
        // {
        //     i.CalcLists(ref rooms);
        // }

        for (var i = 0; i < griddyWidth; i++)
        {
            for (var j = 0; j < griddyLength; j++)
            {
                int randomRoomType = UnityEngine.Random.Range(0, 6);
                var filler = new RoomFiller(roomInfos[0], new Vector3(i * 9, 0, j * 9));
                rooms.Add(filler);
                foreach (RoomFiller k in rooms)
                {
                    //k.CalcLists(ref rooms);
                }
                
            }
        }
        // collapse random room 
        int randomRoomCollapse = UnityEngine.Random.Range(0, 64);
        initRoomIndex = randomRoomCollapse;
        int grandomRoomType = UnityEngine.Random.Range(0, 6);
        var seed = new RoomFiller(roomInfos[grandomRoomType], rooms[randomRoomCollapse].roomPosition);
        seed.isCollapsed = true;
        rooms[randomRoomCollapse] = seed;


        // calculate 
        foreach (RoomFiller k in rooms)
        {
            k.CalcLists(ref rooms);
        }
        Generate();
    }

    void Generate()
    {
        foreach (RoomFiller i in rooms)
        {
            var roomObj = Instantiate(i.ginfo.roomPrefab, i.roomPosition, Quaternion.identity);
            roomGrid.Add(roomObj);
        }
    }
    
    /*RoomInfo roomTypeCalc(GameObject roomModel)
    {
        int roomType = 0;
        if (roomModel.name == "EmptyRoom")
        {
            roomType = 0;
        } else if (roomModel.name == "OnePrefab")
        {
            roomType = 1;
        } else if (roomModel.name == "TwoPrefab")
        {
            roomType = 2;
        } else if (roomModel.name == "ThreePrefab")
        {
            roomType = 3;
        } else if (roomModel.name == "FourPrefab")
        {
            roomType = 4;
        } else if (roomModel.name == "CornerPrefab")
        {
            roomType = 5;
        }

        return roomInfos[roomType];
    }*/
}

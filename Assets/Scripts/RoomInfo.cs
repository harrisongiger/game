using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallType
{
    undecided,
    empty,
    wall,
    door
}

public struct RoomInfo 
{
    public GameObject roomPrefab;
    public WallType NorthType;
    public WallType EastType;
    public WallType SouthType;
    public WallType WestType;

    public RoomInfo(GameObject roomPref, WallType n, WallType e, WallType s, WallType w)
    {
        roomPrefab = roomPref;
        NorthType = n;
        EastType = e;
        SouthType = s;
        WestType = w;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomFiller
{
    public RoomInfo ginfo;
    public Vector3 roomPosition;
    public List<int> NorthIndex;
    public List<int> EastIndex;
    public List<int> SouthIndex;
    public List<int> WestIndex;
    public bool isCollapsed;
    public WallType north;
    public WallType east;
    public WallType south;
    public WallType west;

    // construct class based on inputs
    public RoomFiller(RoomInfo info, Vector3 roomPos)
    {
        ginfo = info;
        roomPosition = roomPos;
        isCollapsed = false;
        north = WallType.undecided;
        east = WallType.undecided;
        south = WallType.undecided;
        west = WallType.undecided;
    }

    // run this once for each item once all types are added
    public void CalcLists(ref List<RoomFiller> optionsIn)
    {
        NorthIndex = new List<int>();
        EastIndex = new List<int>();
        SouthIndex = new List<int>();
        WestIndex = new List<int>();

        // push all the possible options for each direction to their respective lists
        /*for (int i = 0; i < optionsIn.Count; i++)
        {
            
            if (optionsIn[i].ginfo.NorthType == ginfo.SouthType)
            {
                SouthIndex.Append(i);
            }
            if (optionsIn[i].ginfo.EastType == ginfo.WestType)
            {
                WestIndex.Append(i);
            }
            if (optionsIn[i].ginfo.SouthType == ginfo.NorthType)
            {
                NorthIndex.Append(i);
            }
            if (optionsIn[i].ginfo.WestType == ginfo.EastType)
            {
                EastIndex.Append(i);
            }
            
        }*/
       // while (Simplify(ref optionsIn))
        {
        }
    }

    bool Simplify(ref List<RoomFiller> optionsIn)
    {
        bool notCollapsed = false;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int jindex = i * 8 + j;
                if (optionsIn[jindex].isCollapsed == false)
                {
                   // optionsIn[roomGenerator.initRoomIndex] = 
                   // notCollapsed = true;
                }
            }
        }
        // when all collapsed
        return (notCollapsed);
    }
}

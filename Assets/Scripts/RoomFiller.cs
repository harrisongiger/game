using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomFiller
{
    public GameObject roomModel;
    public int NorthType;
    public int EastType;
    public int SouthType;
    public int WestType;
    public List<int> NorthIndex;
    public List<int> EastIndex;
    public List<int> SouthIndex;
    public List<int> WestIndex;


    // construct class based on inputs
    RoomFiller(GameObject inRoomModel, int inNorth, int inEast, int inSouth, int inWest)
    {
        roomModel = inRoomModel;
        NorthType = inNorth;
        EastType = inEast;
        SouthType = inSouth;
        WestType = inWest;
    }

    // run this once for each item once all types are added
    public void CalcLists(ref List<RoomFiller> optionsIn)
    {
        // push all the possible options for each direction to their respective lists
        for(int i = 0; i < optionsIn.Count; i++)
        {
            if (optionsIn[i].NorthType == SouthType)
            {
                SouthIndex.Append(i);
            }
            if (optionsIn[i].EastType == WestType)
            {
                WestIndex.Append(i);
            }
            if (optionsIn[i].SouthType == NorthType)
            {
                NorthIndex.Append(i);
            }
            if (optionsIn[i].WestType == EastType)
            {
                EastIndex.Append(i);
            }
        }
    }
}

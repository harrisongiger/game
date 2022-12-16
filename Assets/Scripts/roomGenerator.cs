using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Tuple<GameObject, int, int, int, int>> roomsIn;
    private List<RoomFiller> rooms;
    

    // Start is called before the first frame update
    void Start()
    {
        // copy input into roomfiller objects
        foreach(Tuple<GameObject,int,int,int,int> i in roomsIn)
        {
            rooms.Add(new RoomFiller(i.Item1, i.Item2, i.Item3, i.Item4, i.Item5));
        }
        // create adjacent room lists
        foreach(RoomFiller i in rooms)
        {
            i.CalcLists(ref rooms);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }
}

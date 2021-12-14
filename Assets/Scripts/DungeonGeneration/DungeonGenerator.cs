﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;

    private List<Vector2Int> dungeonRooms;

    private void Start() {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> dungeonRooms){
        
        RoomController.instance.LoadRoom("Start", 0, 0);

        foreach (Vector2Int roomLocation in dungeonRooms)
        {
            RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawler
{
    Vector2Int position {get; set;}
    
    public DungeonCrawler(Vector2Int initialPos){
        position = initialPos;
    }

    public Vector2Int Move(Dictionary<Direction, Vector2Int> directionMovementMap){
        Direction toMove = (Direction)Random.Range(0, directionMovementMap.Count);
        position += directionMovementMap[toMove];
        return position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction{
    LEFT = 0, UP = 1, RIGHT = 2, DOWN = 3
}

public class DungeonCrawlerController : MonoBehaviour
{
    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();
    private static Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int>{
        {Direction.LEFT, Vector2Int.left},
        {Direction.UP, Vector2Int.up},
        {Direction.RIGHT, Vector2Int.right},
        {Direction.DOWN, Vector2Int.down}

    };

    public static List<Vector2Int> GenerateDungeon(DungeonGenerationData dungeonData){
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();

        for(int i = 0; i < dungeonData.crawlersNumber; i++){
            dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
        }

        int iterations = Random.Range(dungeonData.crawlersMin, dungeonData.crawlersMax);

        for(int i = 0; i < iterations; i++){
            foreach(DungeonCrawler dungeonCrawler in dungeonCrawlers){
                Vector2Int newPos = dungeonCrawler.Move(directionMovementMap);
                positionsVisited.Add(newPos);
            }
        }

        return positionsVisited;
    }
}

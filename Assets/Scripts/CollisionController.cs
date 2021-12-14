using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    
    private GameObject player;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        int scoreToAdd = 0;
        switch(other.tag){
            case "Player":
            Debug.Log("Player gets 10 points");
            scoreToAdd = 10;
            break;

            case "PlayerBullet":
            Debug.Log("Player gets 5 points");
            scoreToAdd = 5;
            break;

            default:
            Debug.Log("Player gets no points, tag: " + other.tag);
            break;
        }
        
        if(playerController != null){
            playerController.AddScore(scoreToAdd);
        }
        Destroy(gameObject);
    }
}

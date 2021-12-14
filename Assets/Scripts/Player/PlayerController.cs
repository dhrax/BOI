using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int score;

    GameObject UI;
    UIManager UIManager;

    public Player playerData;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        UIManager = UI.GetComponent<UIManager>();
    
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.spriteRenderer.sprite = playerData.selectionSprite;
    }

    public void AddScore(int points){
        score += points;
        UIManager.updateScore(score);
    }
}

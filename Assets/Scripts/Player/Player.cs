using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player", menuName = "Player/New Player")]
public class Player : ScriptableObject
{

    new public string name;

    public float speed;

    public Sprite selectionSprite;
    public RuntimeAnimatorController animatorController;

    /// <summary>
    /// Initialize the character with the passed in data.
    /// </summary>
    /// <param name="speed">Character speed.</param>
    /// <param name="name">Character name.</param>
    /// <param name="sprite">Character sprite.</param>
    public void Init(float speed, string name, Sprite sprite, RuntimeAnimatorController animatorController)
    {
        this.speed = speed; // Set the level.
        this.name = name; // Set the name.
        this.selectionSprite = sprite; // Set the sprite.
        this.animatorController = animatorController; // Set the animator controller.
    }

    public void toString()
    {
        Debug.Log("Player name: " + name);
        Debug.Log("Player speed: " + speed);
    }
}


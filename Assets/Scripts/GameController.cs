using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject characterPrefab;

    void Awake()
    {
        GameObject go = Instantiate(characterPrefab);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorType{
        LEFT, TOP, RIGHT, BOTTOM
    }

    public DoorType type;
}

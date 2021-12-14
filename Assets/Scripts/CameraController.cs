using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;

    public float cameraSpeedAtRoomChange;

    public Room currentRoom;


    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition(){
        if(currentRoom != null){
            Vector3 targetPos = GetTargetPos();
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * cameraSpeedAtRoomChange);
        }
    }

    Vector3 GetTargetPos(){
        if(currentRoom == null){
            return Vector3.zero;
        }

        Vector3 targetPos = currentRoom.GetRoomCenter();
        targetPos.z = transform.position.z;

        return targetPos;
    }

    //TODO not implemented
    bool IsSwitchingScene(){
        return transform.position.Equals(GetTargetPos()) == false;
    }
}

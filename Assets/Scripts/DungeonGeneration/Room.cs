using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{


    //TODO change Room and door size to better fit
    public int x;
    public int y;

    public int width;
    public int height;

    public Door rightDoor, leftDoor, topDoor, bottomDoor;

    public List<Door> doors = new List<Door>();

    // Start is called before the first frame update
    void Start()
    {
        //checks if we have a room in the wrong scene and we clicked play
        if (RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene");

            return;
        }

        Door[] aDoors = GetComponentsInChildren<Door>();
        foreach (Door door in aDoors)
        {
            doors.Add(door);
            switch (door.type)
            {
                case Door.DoorType.TOP:
                    topDoor = door;
                    break;
                case Door.DoorType.LEFT:
                    leftDoor = door;
                    break;
                case Door.DoorType.RIGHT:
                    rightDoor = door;
                    break;
                case Door.DoorType.BOTTOM:
                    leftDoor = door;
                    break;
            }
        }

        RoomController.instance.RegisterRoom(this);
    }

    public void RemoveUnconnectedDoors()
    {
        foreach (Door door in doors)
        {
            switch (door.type)
            {
                case Door.DoorType.TOP:
                    if (GetRoomAt(x, y + 1) == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.DoorType.LEFT:
                    if (GetRoomAt(x - 1, y) == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.DoorType.RIGHT:
                    if (GetRoomAt(x + 1, y) == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.DoorType.BOTTOM:
                    if (GetRoomAt(x, y - 1) == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }

    private Room GetRoomAt(int x, int y)
    {
        if(RoomController.instance.DoesRoomExist(x, y))
            return RoomController.instance.FindRoom(x, y);
        else
            return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    public Vector3 GetRoomCenter()
    {
        return new Vector3(width * x, height * y);
    }

    public void UpdateData(string name, int x, int y)
    {
        this.name = name;
        this.x = x;
        this.y = y;
    }

    public void UpdateCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }

}

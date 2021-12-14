using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo
{
    public string name;

    public int x;
    public int y;

    public RoomInfo(string name, int x, int y)
    {
        this.name = name;
        this.x = x;
        this.y = y;
    }
}

public class RoomController : MonoBehaviour
{

    public static RoomController instance;
    string currentWorldName = "Basement";

    RoomInfo currentLoadRoomData;

    Room currentRoom;

    Queue<RoomInfo> roomsToLoad = new Queue<RoomInfo>();

    public List<Room> loadedRooms = new List<Room>();

    bool isLoadingRoom = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        //LoadRoom("Empty", 0, -1);
        //LoadRoom("Empty", 1, 0);
        //LoadRoom("Empty", -1, 0);
        //LoadRoom("Empty", 0, 1);
        //LoadRoom("Empty", 3, 2);
        //LoadRoom("Start", 0, 0);
    }

    private void Update()
    {
        UpdateRoomQueue();
    }

    public void UpdateRoomQueue()
    {
        if (!isLoadingRoom && !(roomsToLoad.Count == 0))
        {
            currentLoadRoomData = roomsToLoad.Dequeue();
            isLoadingRoom = true;
            StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
        }
    }

    public void LoadRoom(string name, int x, int y)
    {

        if (!DoesRoomExist(x, y))
        {
            RoomInfo newRoomInfo = new RoomInfo(name, x, y);

            roomsToLoad.Enqueue(newRoomInfo);
        }

    }

    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while (!loadRoom.isDone)
        {
            yield return null;
        }
    }

    public void RegisterRoom(Room room)
    {
        if (!DoesRoomExist(currentLoadRoomData.x, currentLoadRoomData.y))
        {
            room.transform.position = new Vector3(currentLoadRoomData.x * room.width, currentLoadRoomData.y * room.height);
            room.UpdateData(currentWorldName + "-" + currentLoadRoomData.name + " " + currentLoadRoomData.x + ", " + currentLoadRoomData.y,
                            currentLoadRoomData.x, currentLoadRoomData.y);

            room.transform.parent = transform;
            isLoadingRoom = false;

            if (room.name.Equals("Start"))
            {
                CameraController.instance.currentRoom = room;
            }

            loadedRooms.Add(room);
            room.RemoveUnconnectedDoors();
        }else{
            Destroy(room.gameObject);
            isLoadingRoom = false;
        }

    }

    public bool DoesRoomExist(int x, int y)
    {
        //find returns the object if the condition is met otherwise it returns the default value of T
        return loadedRooms.Find(room => room.x == x && room.y == y) != null;
    }

    public void OnPlayerEnterRoom(Room room)
    {
        CameraController.instance.currentRoom = room;
        currentRoom = room;
    }

    public Room FindRoom(int x, int y)
    {
        //find returns the object if the condition is met otherwise it returns the default value of T
        return loadedRooms.Find(room => room.x == x && room.y == y);
    }

}

using System;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    [SerializeField] private Room _currentRoom = null;

    public Room CurrentRoom{
        get{ return _currentRoom; }
    }

    private GameController _controller;

    private void Awake()
    {
        _controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < _currentRoom.exits.Length; i++){
            _controller.InteractionDescriptionsInRoom.Add(_currentRoom.exits[i].exitDescription);
        }
    }
}

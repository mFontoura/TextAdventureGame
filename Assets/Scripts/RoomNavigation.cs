using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    [SerializeField] private Room _currentRoom = null;
    
    private Dictionary<string, Room> _exitDictionary = new Dictionary<string, Room>();

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
            _exitDictionary.Add(_currentRoom.exits[i].keyString, _currentRoom.exits[i].valueRoom);
            _controller.InteractionDescriptionsInRoom.Add(_currentRoom.exits[i].exitDescription);
        }
    }

    public void ClearExits()
    {
        _exitDictionary.Clear();
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (_exitDictionary.ContainsKey(directionNoun)){
            _currentRoom = _exitDictionary[directionNoun];
            _controller.LogStringWithReturn("You head off to the " + directionNoun);
            _controller.DisplayRoomText();
        } else{
            _controller.LogStringWithReturn("There is no path to the " + directionNoun);
        }
    }
    
    
}

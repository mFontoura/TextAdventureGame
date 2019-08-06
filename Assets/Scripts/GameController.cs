using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(RoomNavigation))]
public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayText = null;

    private RoomNavigation _roomNavigation;
    private List<string> _interactionDescriptionsInRoom = new List<string>();
    private List<string> _actionLog = new List<string>();

    public List<string> InteractionDescriptionsInRoom{
        get{ return _interactionDescriptionsInRoom; }
    }

    private void Awake()
    {
        _roomNavigation = GetComponent<RoomNavigation>();
    }

    private void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        _displayText.text = string.Join("\n", _actionLog.ToArray());
    }

    public void DisplayRoomText()
    {
        UnpackRoom();
        
        var joinedInteractionDescriptions = string.Join("\n", _interactionDescriptionsInRoom.ToArray());
        var combinedText = _roomNavigation.CurrentRoom.description + "\n" + joinedInteractionDescriptions;
        
        LogStringWithReturn(combinedText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        _actionLog.Add(stringToAdd + "\n");
    }

    private void UnpackRoom()
    {
        _roomNavigation.UnpackExitsInRoom();
    }
}

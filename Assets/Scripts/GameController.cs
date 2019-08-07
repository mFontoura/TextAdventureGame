using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(RoomNavigation))]
public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayText = null;
    [SerializeField] private InputAction[] _inputActions = null;

    private RoomNavigation _roomNavigation;
    private List<string> _interactionDescriptionsInRoom = new List<string>();
    private List<string> _actionLog = new List<string>();
    private InteractableItems _interactableItems;

    public List<string> InteractionDescriptionsInRoom{
        get{ return _interactionDescriptionsInRoom; }
    }

    public RoomNavigation Navigation{
        get{ return _roomNavigation; }
    }

    public InputAction[] InputActions{
        get{ return _inputActions; }
    }

    public InteractableItems Items{
        get{ return _interactableItems; }
    }

    private void Awake()
    {
        _interactableItems = GetComponent<InteractableItems>();
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
        ClearCollectionsForNewRoom();
        UnpackRoom();
        
        var joinedInteractionDescriptions = string.Join("\n", _interactionDescriptionsInRoom.ToArray());
        var combinedText = Navigation.CurrentRoom.description + "\n" + joinedInteractionDescriptions;
        
        LogStringWithReturn(combinedText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        _actionLog.Add(stringToAdd + "\n");
    }

    private void UnpackRoom()
    {
        Navigation.UnpackExitsInRoom();
        PrepareObjectsToTakeOrExamine(Navigation.CurrentRoom);
    }

    private void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        foreach (var interactableObject in currentRoom.interactableObjectsInRoom){
            string descriptionNotInInventory = _interactableItems.GetObjectNotInInventory(currentRoom, interactableObject);
            if (descriptionNotInInventory != null){
                _interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }
        }
        
    }

    private void ClearCollectionsForNewRoom()
    {
        _interactionDescriptionsInRoom.Clear();
        Navigation.ClearExits();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    private List<string> _nounsInRoom = new List<string>();
    private List<string> _nounsInInventory = new List<string>();

    public List<string> NounsInRoom{
        get{ return _nounsInRoom; }
    }

    public string GetObjectNotInInventory(Room currentRoom, InteractableObject interactableInRoom)
    {
        if (_nounsInInventory.Contains(interactableInRoom.noum)){
            return null;
        }

        _nounsInRoom.Add(interactableInRoom.noum);
        return interactableInRoom.description;

    }

}

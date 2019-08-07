
using UnityEngine;
[CreateAssetMenu(menuName = "TextAdventure/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string noum = "name";

    [TextArea] public string description = "Description in room";


}

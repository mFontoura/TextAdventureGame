using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{

    [TextArea]
    public string description = null;
    public string roomName = null;
    public Exit[] exits;
}

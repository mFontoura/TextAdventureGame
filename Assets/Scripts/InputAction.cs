
using UnityEngine;

public abstract class InputAction : ScriptableObject
{

    public string keyWord;

    public abstract void RespondToInput(GameController controller, string[] separatedInputWord);

}

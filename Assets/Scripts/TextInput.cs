using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class TextInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputfield = null;
    
    private GameController _gameController;

    private void Awake()
    {
        _gameController = GetComponent<GameController>();
        _inputfield.onEndEdit.AddListener(AcceptStringInput);
    }

    private void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        _gameController.LogStringWithReturn(userInput);
        InputComplete();
        
    }

    private void InputComplete()
    {
        _gameController.DisplayLoggedText();
        _inputfield.ActivateInputField();
        _inputfield.text = null;
    }

}

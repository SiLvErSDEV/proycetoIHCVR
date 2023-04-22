using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowMenu : MonoBehaviour
{
    public GameObject menuScreen;
    public InputActionProperty menuButton;


    private bool isMenuVisible = false;

    private void Start() {
        menuScreen.SetActive(isMenuVisible);
    }

    // call menu button pressed when the menu button is pressed
    private void Update() {
        // use the occulus menu button to open the menu
        float menuButtonPressed = menuButton.action.ReadValue<float>();
        Debug.Log(menuButtonPressed);
        if (menuButtonPressed == 1) {
            MenuButtonPressed();
            Debug.Log("here1");
        }
    }

    public void MenuButtonPressed()
    {
        isMenuVisible = !isMenuVisible;

        menuScreen.SetActive(isMenuVisible); // sets menu screen to active or inactive based on isMenuVisible variable

        if (isMenuVisible)
        {
            menuScreen.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
            // also set rotation lol that was silly
            // menuScreen.transform.rotation = Camera.main.transform.rotation;
        }
    }
}

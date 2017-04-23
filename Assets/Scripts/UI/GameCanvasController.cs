using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuContainer;
    private Animator _menuAnimator;

    private bool _mainMenuEnabled = false;

    private void Awake()
    {
        _menuAnimator = _menuContainer.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMainMenu();
        }
    }

    public void ToggleMainMenu()
    {
        _mainMenuEnabled = !_mainMenuEnabled;
        _menuAnimator.SetBool("MainMenuEnabled", _mainMenuEnabled);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

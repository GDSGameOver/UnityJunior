using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _creditsMenu; 
    [SerializeField] private GameObject _mainMenu;

    private void Awake()
    {
        _creditsMenu.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        _creditsMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void EnterCreditsMenu()
    {
        _creditsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

}

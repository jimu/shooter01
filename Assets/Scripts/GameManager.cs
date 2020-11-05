using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { Null = 0, Init, StartMenu, Play, Pause, Help, Win, Lose };
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Panels")]
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject helpMenu;
    public GameObject winMenu;
    public GameObject loseMenu;

    [Header("Sound Effects")]
    public AudioClip sfxClick;
    [HideInInspector] public AudioSource uiAudioSource;


    GameState state;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetState(GameState.StartMenu);
    }

    public void UIPlayOneShot(AudioClip sfx)
    {
        uiAudioSource.PlayOneShot(sfx);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Play)
            if (Input.GetKeyDown(KeyCode.Escape))
                OnEscapePressed();
    }


    public void UIPlayClick()
    {
        UIPlayOneShot(sfxClick);
    }

    void OnOkayPressed()
    {
        UIPlayClick();
    }

    void OnCancelPressed()
    {
        UIPlayClick();
    }

    void OnEscapePressed()
    {
        UIPlayClick();
        SetState(GameState.Pause);
    }

    public void SetState( GameState state)
    {
        Debug.Log($"SetState({state})");
        this.state = state;

        startMenu.SetActive(state == GameState.StartMenu);
        pauseMenu.SetActive(state == GameState.Pause);
        helpMenu.SetActive(state == GameState.Help);
        winMenu.SetActive(state == GameState.Win);
        loseMenu.SetActive(state == GameState.Lose);
    }

}

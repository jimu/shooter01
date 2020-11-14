﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject hud;
    public GameObject debugPanel;
    public TextMeshProUGUI scoreText;

    [Header("Sound Effects")]
    public AudioClip sfxClick;
    public AudioClip sfxWin;
    public AudioClip sfxLose;
    public AudioClip sfxScore;
    [HideInInspector] public AudioSource uiAudioSource;
    [SerializeField] EnemyData debugEnemy;

    int score = 0;

    GameState state;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitGame();
    }

    private void InitGame()
    {
        SetScore(0);
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
        {
            if (Input.GetButtonDown("Cancel"))
                OnEscapePressed();
            if (Input.GetButtonDown("Submit"))
                AddScore(1);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                Win();
            if (Input.GetKeyDown(KeyCode.Alpha3))
                Lose();
            if (Input.GetKeyDown(KeyCode.Alpha4))
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().TogglePerspective();
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                GameObject e = GetComponent<EnemyPoolManager>().Get(new Vector3(1, 0, 0));
                e.GetComponent<Enemy>().SetData(debugEnemy);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
                GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Damage(10);
            if (Input.GetKeyDown(KeyCode.Alpha7))
                foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy")) {
                    e.GetComponent<HealthController>().Damage(1);
                }
        }
    }

    public void Win()
    {
        UIPlayOneShot(sfxWin);
        winMenu.GetComponent<MenuInputManager>().SetContent($"Score: {score}");
        SetState(GameState.Win);
    }

    public void Lose()
    {
        UIPlayOneShot(sfxLose);
        loseMenu.GetComponent<MenuInputManager>().SetContent($"Score: {score}");
        SetState(GameState.Lose);
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

        if (state == GameState.Init)
        {
            InitGame();
            return;
        }

        startMenu.SetActive(state == GameState.StartMenu);
        pauseMenu.SetActive(state == GameState.Pause);
        helpMenu.SetActive(state == GameState.Help);
        winMenu.SetActive(state == GameState.Win);
        loseMenu.SetActive(state == GameState.Lose);
        hud.SetActive(state == GameState.Play);

        Time.timeScale = state == GameState.Play ? 1f : 0f;
    }


    public void AddScore(int increment)
    {
        UIPlayOneShot(sfxScore);
        SetScore(score + increment);
    }

    public void SetScore(int value)
    {
        score = value;
        scoreText.SetText(value.ToString());
    }
}

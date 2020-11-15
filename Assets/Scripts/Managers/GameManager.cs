using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 0649

public enum GameState { Null = 0, Init, StartMenu, Play, Pause, Help, Win, Lose };
public class GameManager : MonoSingleton<GameManager>
{
    [Header("UI Panels")]
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject helpMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject hud;
    public GameObject debugPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI flashText;

    [Header("Sound Effects")]
    public AudioClip sfxClick;
    public AudioClip sfxWin;
    public AudioClip sfxLose;
    public AudioClip sfxScore;
    [HideInInspector] public AudioSource uiAudioSource;
    [SerializeField] EnemyData debugEnemy;

    [HideInInspector] public float minX, minY, maxX, maxY;

    int score = 0;

    GameState state;

    protected override void Init()
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
            if (Input.GetKeyDown(KeyCode.Alpha4))
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementController>().TogglePerspective();
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                GameObject enemy = PoolManager.Instance.Get(debugEnemy.prefab, new Vector3(1, 0, 0));
                enemy.GetComponent<Enemy>().SetData(debugEnemy);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
                GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Damage(1);
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnEscapePressed()
    {
        UIPlayClick();
        SetState(GameState.Pause);
    }

    public void SetState( GameState state)
    {
        //Debug.Log($"SetState({state})");
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


    public void SetLives(int lives)
    {
        livesText.SetText(lives.ToString());

        if (lives < 1)
            GameManager.Instance.Lose();
    }

    public void SetExtents(float minX, float minY, float maxX, float maxY)
    {
        this.minX = minX;
        this.minY = minY;
        this.maxX = maxX;
        this.maxY = maxY;
    }


    public void FlashMessage(string message)
    {
        flashText.text = message;
        flashText.gameObject.SetActive(true);

        StartCoroutine(HideFlashMessage(1f));
    }

    IEnumerator HideFlashMessage(float delay)
    {
        yield return new WaitForSeconds(delay);
        flashText.gameObject.SetActive(false);
    }
}

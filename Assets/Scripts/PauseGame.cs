using UnityEngine;

public class PauseGame : Singleton<PauseGame>
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    protected override void Awake()
    {
        base.Awake();

        // Сохраняем объект PauseGame между сценами
        DontDestroyOnLoad(gameObject);

        if (pauseMenuUI == null)
        {
            Debug.LogError("PauseMenuUI не задан в инспекторе.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Игра завершена."); // Для отладки

#if UNITY_EDITOR
        // Если игра запущена в редакторе, остановить ее
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Закрыть приложение
        Application.Quit();
#endif
    }

    public void SetPauseMenu(GameObject newPauseMenuUI)
    {
        pauseMenuUI = newPauseMenuUI;
    }
}

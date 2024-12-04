using UnityEngine;

public class PauseGame : Singleton<PauseGame>
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    protected override void Awake()
    {
        base.Awake();

        // ��������� ������ PauseGame ����� �������
        DontDestroyOnLoad(gameObject);

        if (pauseMenuUI == null)
        {
            Debug.LogError("PauseMenuUI �� ����� � ����������.");
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
        Debug.Log("���� ���������."); // ��� �������

#if UNITY_EDITOR
        // ���� ���� �������� � ���������, ���������� ��
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ������� ����������
        Application.Quit();
#endif
    }

    public void SetPauseMenu(GameObject newPauseMenuUI)
    {
        pauseMenuUI = newPauseMenuUI;
    }
}

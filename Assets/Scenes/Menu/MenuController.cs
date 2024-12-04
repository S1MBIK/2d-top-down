using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Загружает сцену игры
        SceneManager.LoadScene("Scene1"); // Замените "GameSceneName" на название вашей сцены
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Останавливает игру в редакторе Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Закрывает приложение в сборке
        Application.Quit();
#endif

        Debug.Log("Игра завершена");
    }
}

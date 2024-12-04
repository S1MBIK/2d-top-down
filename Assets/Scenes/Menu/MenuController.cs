using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        // ��������� ����� ����
        SceneManager.LoadScene("Scene1"); // �������� "GameSceneName" �� �������� ����� �����
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // ������������� ���� � ��������� Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ��������� ���������� � ������
        Application.Quit();
#endif

        Debug.Log("���� ���������");
    }
}

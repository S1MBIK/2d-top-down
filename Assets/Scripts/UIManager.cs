using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject pauseMenuUI; // ������ �����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ����� �������
        }
        else
        {
            Destroy(gameObject); // ���������� ������������� ������
        }
    }
}

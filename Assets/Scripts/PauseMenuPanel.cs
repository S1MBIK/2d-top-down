using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ������� ��� ������������ ����

public class PauseMenuPanel : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("PauseMenuPanel ������ � �� ����� ��������� ��� �������� ����� ����.");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PauseMenuPanel �������.");
        CheckComponents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckComponents()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image == null)
            {
                Debug.LogError("��������� Image ���������, �� �������� ���� ���������.");
            }
        }
    }
}

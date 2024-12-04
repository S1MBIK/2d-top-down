using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ƒобавим это пространство имен

public class PauseMenuPanel : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("PauseMenuPanel создан и не будет уничтожен при загрузке новых сцен.");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PauseMenuPanel запущен.");
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
                Debug.LogError(" омпонент Image уничтожен, но пытаетс€ быть доступным.");
            }
        }
    }
}

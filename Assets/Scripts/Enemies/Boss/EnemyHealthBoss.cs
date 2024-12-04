using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBoss : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3; // ��������� ��������
    [SerializeField] private float knockBackThrust = 15f; // ���� ������������

    private int currentHealth; // ������� ��������
    private Knockback knockback; // ��������� ������������
    private Flash flash; // ��������� ����������� �������

    private void Awake()
    {
        // �������� ������ �� ����������
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        // ������������� �������� ��������
        currentHealth = startingHealth;
   
    }

    public void TakeDamage(int damage)
    {
        // ��������� ������� ��������
        if (damage <= 0)
        {
            Debug.LogWarning("TakeDamage called with non-positive damage value!");
            return;
        }

        currentHealth -= damage;
        Debug.Log($"Enemy took damage: {damage}, current health: {currentHealth}");

        // ������������ �����
        if (knockback != null && PlayerController.Instance != null)
        {
            knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        }
        else
        {
            Debug.LogWarning("Knockback or PlayerController is missing!");
        }

        // ��������� ���������� ������ �������
        if (flash != null)
        {
            StartCoroutine(flash.FlashRoutine());
        }
        else
        {
            Debug.LogWarning("Flash component is missing!");
        }

        // ��������� ������
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        // ���� ��������� ����� ��������������
        if (flash != null)
        {
            yield return new WaitForSeconds(flash.GetRestoreMatTime());
        }
        else
        {
            Debug.LogWarning("Flash component is missing! Skipping wait.");
        }

        // ���������, ���� �� ����
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy has died!");

            // ������� ��������, ���� ��������� PickUpSpawner ������������
            if (TryGetComponent<PickUpSpawner>(out var spawner))
            {
                spawner.DropItems();
            }

            // ���������� ������
            Destroy(gameObject);
        }
    }
}

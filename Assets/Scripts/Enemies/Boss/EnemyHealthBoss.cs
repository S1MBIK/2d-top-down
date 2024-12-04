using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBoss : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3; // Начальное здоровье
    [SerializeField] private float knockBackThrust = 15f; // Сила отбрасывания

    private int currentHealth; // Текущее здоровье
    private Knockback knockback; // Компонент отбрасывания
    private Flash flash; // Компонент визуального мигания

    private void Awake()
    {
        // Получаем ссылки на компоненты
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        // Инициализация текущего здоровья
        currentHealth = startingHealth;
   
    }

    public void TakeDamage(int damage)
    {
        // Проверяем входной параметр
        if (damage <= 0)
        {
            Debug.LogWarning("TakeDamage called with non-positive damage value!");
            return;
        }

        currentHealth -= damage;
        Debug.Log($"Enemy took damage: {damage}, current health: {currentHealth}");

        // Отбрасывание врага
        if (knockback != null && PlayerController.Instance != null)
        {
            knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        }
        else
        {
            Debug.LogWarning("Knockback or PlayerController is missing!");
        }

        // Запускаем визуальный эффект мигания
        if (flash != null)
        {
            StartCoroutine(flash.FlashRoutine());
        }
        else
        {
            Debug.LogWarning("Flash component is missing!");
        }

        // Проверяем смерть
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        // Ждем указанное время восстановления
        if (flash != null)
        {
            yield return new WaitForSeconds(flash.GetRestoreMatTime());
        }
        else
        {
            Debug.LogWarning("Flash component is missing! Skipping wait.");
        }

        // Проверяем, умер ли враг
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy has died!");

            // Спавним предметы, если компонент PickUpSpawner присутствует
            if (TryGetComponent<PickUpSpawner>(out var spawner))
            {
                spawner.DropItems();
            }

            // Уничтожаем объект
            Destroy(gameObject);
        }
    }
}

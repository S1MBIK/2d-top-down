using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX; // Эффект разрушения

    private bool hasDropped = false; // Флаг для предотвращения множественного выпадения

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>())
        {
            if (!hasDropped) // Проверяем, был ли уже вызван метод выпадения предметов
            {
                hasDropped = true; // Устанавливаем флаг, чтобы предотвратить множественные вызовы

                // Проверяем наличие разных типов спавнеров
                if (TryGetComponent(out PickUpSpawnerChest chestSpawner))
                {
                    chestSpawner.DropItemsChest(); // Если есть PickUpSpawnerChest, вызываем его метод DropItems
                }
                else if (TryGetComponent(out PickUpSpawner standardSpawner))
                {
                    standardSpawner.DropItems(); // Если есть PickUpSpawner, вызываем его метод DropItems
                }

                // Создаём эффект разрушения
                Instantiate(destroyVFX, transform.position, Quaternion.identity);

                // Уничтожаем объект
                Destroy(gameObject);
            }
        }
    }
}

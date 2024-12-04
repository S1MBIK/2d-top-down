using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawnerChest : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin;
    [SerializeField] private GameObject healthGlobe;
    [SerializeField] private GameObject staminaGlobe;

    // Шансы выпадения предметов (в процентах)
    [SerializeField] private int healthGlobeChance = 50;  
    [SerializeField] private int staminaGlobeChance = 50; 
    [SerializeField] private int goldChance = 50;        

    // Количество предметов при выпадении
    [SerializeField] private Vector2 goldDropRange = new Vector2(5, 8); // Диапазон выпадения золота
    [SerializeField] private Vector2 iterationsRange = new Vector2(5, 10); // Число итераций выпадения предметов

    // Публичная переменная для изменения количества итераций
    public int customIterations;

    public void DropItemsChest()
    {
        // Используем customIterations, если она установлена, иначе используем default
        int iterations = customIterations > 0 ? customIterations : Random.Range((int)iterationsRange.x, (int)iterationsRange.y);

        // Количество итераций
        for (int i = 0; i < iterations; i++)
        {
            // Генерация случайных значений для каждого типа предмета
            int randomNum = Random.Range(1, 101); // Генерация числа от 1 до 100 для каждого предмета

            // Если выпадет предмет здоровья
            if (randomNum <= healthGlobeChance)
            {
                Instantiate(healthGlobe, transform.position, Quaternion.identity);
            }

            // Если выпадет предмет выносливости
            if (randomNum <= staminaGlobeChance + healthGlobeChance && randomNum > healthGlobeChance)
            {
                Instantiate(staminaGlobe, transform.position, Quaternion.identity);
            }

            // Если выпадет золото
            if (randomNum <= goldChance + staminaGlobeChance + healthGlobeChance && randomNum > staminaGlobeChance + healthGlobeChance)
            {
                int randomAmountOfGold = Random.Range((int)goldDropRange.x, (int)goldDropRange.y); // Случайное количество золота
                for (int j = 0; j < randomAmountOfGold; j++)
                {
                    Instantiate(goldCoin, transform.position, Quaternion.identity);
                }
            }
        }
    }
}

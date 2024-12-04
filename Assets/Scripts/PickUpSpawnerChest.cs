using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawnerChest : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin;
    [SerializeField] private GameObject healthGlobe;
    [SerializeField] private GameObject staminaGlobe;

    // ����� ��������� ��������� (� ���������)
    [SerializeField] private int healthGlobeChance = 50;  
    [SerializeField] private int staminaGlobeChance = 50; 
    [SerializeField] private int goldChance = 50;        

    // ���������� ��������� ��� ���������
    [SerializeField] private Vector2 goldDropRange = new Vector2(5, 8); // �������� ��������� ������
    [SerializeField] private Vector2 iterationsRange = new Vector2(5, 10); // ����� �������� ��������� ���������

    // ��������� ���������� ��� ��������� ���������� ��������
    public int customIterations;

    public void DropItemsChest()
    {
        // ���������� customIterations, ���� ��� �����������, ����� ���������� default
        int iterations = customIterations > 0 ? customIterations : Random.Range((int)iterationsRange.x, (int)iterationsRange.y);

        // ���������� ��������
        for (int i = 0; i < iterations; i++)
        {
            // ��������� ��������� �������� ��� ������� ���� ��������
            int randomNum = Random.Range(1, 101); // ��������� ����� �� 1 �� 100 ��� ������� ��������

            // ���� ������� ������� ��������
            if (randomNum <= healthGlobeChance)
            {
                Instantiate(healthGlobe, transform.position, Quaternion.identity);
            }

            // ���� ������� ������� ������������
            if (randomNum <= staminaGlobeChance + healthGlobeChance && randomNum > healthGlobeChance)
            {
                Instantiate(staminaGlobe, transform.position, Quaternion.identity);
            }

            // ���� ������� ������
            if (randomNum <= goldChance + staminaGlobeChance + healthGlobeChance && randomNum > staminaGlobeChance + healthGlobeChance)
            {
                int randomAmountOfGold = Random.Range((int)goldDropRange.x, (int)goldDropRange.y); // ��������� ���������� ������
                for (int j = 0; j < randomAmountOfGold; j++)
                {
                    Instantiate(goldCoin, transform.position, Quaternion.identity);
                }
            }
        }
    }
}

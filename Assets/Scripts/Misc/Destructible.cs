using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX; // ������ ����������

    private bool hasDropped = false; // ���� ��� �������������� �������������� ���������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>())
        {
            if (!hasDropped) // ���������, ��� �� ��� ������ ����� ��������� ���������
            {
                hasDropped = true; // ������������� ����, ����� ������������� ������������� ������

                // ��������� ������� ������ ����� ���������
                if (TryGetComponent(out PickUpSpawnerChest chestSpawner))
                {
                    chestSpawner.DropItemsChest(); // ���� ���� PickUpSpawnerChest, �������� ��� ����� DropItems
                }
                else if (TryGetComponent(out PickUpSpawner standardSpawner))
                {
                    standardSpawner.DropItems(); // ���� ���� PickUpSpawner, �������� ��� ����� DropItems
                }

                // ������ ������ ����������
                Instantiate(destroyVFX, transform.position, Quaternion.identity);

                // ���������� ������
                Destroy(gameObject);
            }
        }
    }
}

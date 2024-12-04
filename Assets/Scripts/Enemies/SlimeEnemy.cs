using UnityEngine;

public class SlimeEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int damage = 1;

    public void Attack()
    {
        if (PlayerController.Instance != null)
        {
            PlayerHealth playerHealth = PlayerController.Instance.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage, transform);
                Debug.Log("������� ������� � ������� " + damage + " �����!");
            }
            else
            {
                Debug.LogError("PlayerHealth ��������� �� ������ �� PlayerController.");
            }
        }
        else
        {
            Debug.LogError("PlayerController.Instance ����� null.");
        }
    }
}

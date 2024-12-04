using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public float detectionRange = 10f; // Дистанция для обнаружения игрока
    public float attackRange = 2f; // Дистанция атаки
    public float moveSpeed = 5f; // Скорость перемещения
    public Animator animator; // Ссылка на Animator

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRange)
        {
            Attack();
        }
        else if (distanceToPlayer < detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            Roam();
        }
    }

    private void Roam()
    {
        Debug.Log("Roaming");
        animator.SetBool("isRoaming", true);
        animator.SetBool("isAttacking", false);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        animator.SetBool("isRoaming", false);
        animator.SetBool("isAttacking", false);
        // Перемещение к игроку
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetBool("isRoaming", false);
        animator.SetBool("isAttacking", true);
        // Логика атаки здесь (например, уменьшение здоровья игрока)
    }

}
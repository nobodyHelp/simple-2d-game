using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            EventManager.SendEnemyKilled();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

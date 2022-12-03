using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private int count;

    private void Awake()
    {       
        count = Random.Range(1, 6);
    }

    void Start()
    {                      
        for (int i = 0; i < count; i++)
        {
            EnemySpawn(enemyPrefab);
        }       
    }

    private void OnEnable()
    {
        EventManager.OnEnemyKilled += EnemyDie;
    }

    private void OnDisable()
    {
        EventManager.OnEnemyKilled -= EnemyDie;
    }

    private void EnemyDie()
    {
        count--;
        if (count <= 0)
        {
            EventManager.SendGameOver();
        }
    }

    private void EnemySpawn(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector2(
            Random.Range(gameObject.transform.position.x - 5f, gameObject.transform.position.x + 5f), 0), 
            Quaternion.identity);
    }
}

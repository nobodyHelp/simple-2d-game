using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EventManager.SendEnemyKilled();
        }
        if (other.gameObject.tag == "Player")
        {
            EventManager.SendHeroDie();
            Destroy(other.gameObject);
        }
        
    }
}

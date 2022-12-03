using UnityEngine;

public class Shell : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject effectPrefab;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * speed;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyShell();
        }
       
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            DestroyShell();
        }
    }

    void DestroyShell()
    {
        var cloneEffect = Instantiate(effectPrefab, transform.position, Quaternion.identity);        
        Destroy(gameObject);
        Destroy(cloneEffect, .5f);
    }
}

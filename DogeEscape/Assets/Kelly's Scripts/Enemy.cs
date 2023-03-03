using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    public Animator animator;

    public int maxHealth = 1;
    int currentHealth;


     void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("Player Death");
        gameObject.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )

        {
            collision.GetComponent<Health>().TakeDamage(damage);
            FindObjectOfType<AudioManager>().Play("Player Hurt");
        }
    }
}

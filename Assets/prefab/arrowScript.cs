using UnityEngine;

public class arrowScript : MonoBehaviour
{
    [SerializeField] float arrowSpeed;
    [SerializeField] int arrowDamage;

    Rigidbody2D Rigidbody2D;

    public float getArrowSpeed()
    {
        return arrowSpeed;
    }
    public float getArrowDamage()
    {
        return arrowDamage;
    }

    public void setArrowSpeed(float arrowSpeed)
    {
        this.arrowSpeed = arrowSpeed;
    }

    public void setArrowDamage(int arrowDamage)
    {
        this.arrowDamage = arrowDamage;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.linearVelocityY = arrowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("anamy"))
        {
            monsterStat monsterStat = other.GetComponent<monsterStat>();
            monsterStat.takeDamage(arrowDamage);
            Destroy(gameObject);
        }
    }


}

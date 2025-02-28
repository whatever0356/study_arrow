using UnityEngine;

public class monsterStat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int hp;
    public float speed;

    Rigidbody2D myRigidbody2D;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.linearVelocityY = -1f * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }

        if(transform.position.y <= -4)
        {
            Destroy (gameObject);
        }

        

    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public float getSpeed()
    {
        return this.speed;
    }

    public void setHp(int hp)
    {
        this.hp = hp;
    }
    public int getHp()
    {
        return this.hp;
    }

    public void takeDamage(int damage)
    {
        this.hp -= damage;
    }
}

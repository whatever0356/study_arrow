using UnityEngine;

public class gateScript : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;
    public int abilityType;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.linearVelocityY = -1;

        mySpriteRenderer = GetComponent<SpriteRenderer>();
        abilityType = Random.Range(1, 5); //1-데미지 2-공속 3-최대체력 4-화살속도
        if (abilityType == 1)
        {
            mySpriteRenderer.color = Color.white;
        }
        else if (abilityType == 2)
        {
            mySpriteRenderer.color = Color.red;
        }
        else if (abilityType == 3) 
        {
            mySpriteRenderer.color = Color.blue;
        }
        else if(abilityType == 4)
        {
            mySpriteRenderer.color = Color.green;
        }



        

    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -4)
        {
            Destroy(gameObject);
        }
    }

    public void setVelocity(float velocity)
    {
        myRigidbody.linearVelocityY = velocity;
    }

}


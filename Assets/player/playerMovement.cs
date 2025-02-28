using UnityEngine;

public class playerMovement : MonoBehaviour
{
    

    float maxPositionR = 2.8f;  //플레이어 우측 최대좌표
    float maxPositionL = -2.8f; //플레이어 좌측 최대좌표
    
    public float moveSpeed;


  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x <= maxPositionL)                        //플레이어 이동, 좌우 이동제한
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0));
            }
        }
        else if(transform.position.x >= maxPositionR)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0));
            }
        }
        else
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0));
        }
    }
}
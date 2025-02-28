using UnityEngine;

public class playerMovement : MonoBehaviour
{
    

    float maxPositionR = 2.8f;  //�÷��̾� ���� �ִ���ǥ
    float maxPositionL = -2.8f; //�÷��̾� ���� �ִ���ǥ
    
    public float moveSpeed;


  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x <= maxPositionL)                        //�÷��̾� �̵�, �¿� �̵�����
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
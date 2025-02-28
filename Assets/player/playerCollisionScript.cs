using System;
using UnityEngine;

public class playerCollisionScript : MonoBehaviour
{
    playerStat playerStat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStat = GetComponent<playerStat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("gate"))   //����Ʈ �����
        {

           
            gateScript gateScript = other.GetComponent<gateScript>(); ////1-������ 2-���� 3-�ִ�ü�� 4-ȭ��ӵ�
            if (gateScript.abilityType == 1)
            {
                playerStat.setAtkDamage(playerStat.getAtkDamage() + 1);
            }
            else if(gateScript.abilityType == 2)
            {
                playerStat.setAtkSpeed(playerStat.getAtkSpeed() + 1);
            }
            else if (gateScript.abilityType == 3)
            {
                playerStat.setMaxHp(playerStat.getMaxHp() + 10);
            }
            else
            {
                playerStat.setArrowSpeed(playerStat.getArrowSpeed() + 1);
            }

            Destroy(other.gameObject);

        }
        if (other.CompareTag("anamy"))  //�� �浹��
        {
            monsterStat monsterStat = other.GetComponent<monsterStat>();
            playerStat.setHp(playerStat.getHp() - monsterStat.getHp());
            monsterStat.takeDamage(monsterStat.getHp() + 100);
        }

    }

}

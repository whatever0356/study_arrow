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
        
        if (other.CompareTag("gate"))   //게이트 통과시
        {

           
            gateScript gateScript = other.GetComponent<gateScript>(); ////1-데미지 2-공속 3-최대체력 4-화살속도
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
        if (other.CompareTag("anamy"))  //적 충돌시
        {
            monsterStat monsterStat = other.GetComponent<monsterStat>();
            playerStat.setHp(playerStat.getHp() - monsterStat.getHp());
            monsterStat.takeDamage(monsterStat.getHp() + 100);
        }

    }

}

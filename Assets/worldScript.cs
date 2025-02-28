using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class worldScript : MonoBehaviour
{

    public GameObject gatePrefab;
    public GameObject monsterPrefab;
    public Vector3 gatePosL = new Vector3(-1.59f, 6f, 0);
    public Vector3 gatePosR = new Vector3(1.59f, 6f, 0);
    public int level = 1;


    List<GameObject> gateList = new List<GameObject>(); //게이트는 주기적으로 생겼다 없어지므로 리스트를 통해 관리.
    List<GameObject> monsterList = new List<GameObject>();

    public float gateCooltime; // 쿨타임 상수. 게이트 쿨타임은 인스펙터창에서 시험해보며 조정 추후 다시 프라이빗으로 변경필요.
    public float currentGateCooltime; //현재 남은 쿨타임
    public float monsterCooltime;
    public float currentMonsterCooltime;

    public float gameCounter = 0;
   
    void Start()
    {
        currentGateCooltime = gateCooltime;
    }

    // Update is called once per frame
    void Update()
    {
        gameCounter += Time.deltaTime;
        if(currentGateCooltime > 0)
        {
            currentGateCooltime -= Time.deltaTime;
        }
        else
        {
            currentGateCooltime = gateCooltime;

            if(Random.Range(1, 3) == 1) //1이면 왼쪽에 2면 오른쪽에 소환
            {
                gateList.Add(Instantiate(gatePrefab, gatePosL, transform.rotation));//새 인스턴스 게이트 리스트에 추가
            }
            else
            {
                gateList.Add(Instantiate(gatePrefab, gatePosR, transform.rotation));//새 인스턴스 게이트 리스트에 추가
            }
            gateList.RemoveAll(item => item == null);   //람다식. removeAll은 조건을 판별해 불리언값 반환하는함수를 매개변수로 받음. 이를 람다식으로 정의해 넣어줌
                                                        //gate리스트에 중간중간 null값 들어가있는거 없애는용도.

        }

        if(currentMonsterCooltime > 0)
        {
            currentMonsterCooltime -= Time.deltaTime;
        }
        else
        {
            currentMonsterCooltime = monsterCooltime;
            if (Random.Range(1, 3) == 1) //1이면 왼쪽에 2면 오른쪽에 소환
            {
                monsterList.Add(Instantiate(monsterPrefab, gatePosL, transform.rotation));
            }
            else
            {
               monsterList.Add(Instantiate(monsterPrefab, gatePosR, transform.rotation));//새 인스턴스 게이트 리스트에 추가
            }
            monsterList[monsterList.Count - 1].GetComponent<monsterStat>().setSpeed(1);
            monsterList[monsterList.Count - 1].GetComponent<monsterStat>().setHp(2);
            monsterList.RemoveAll(item => item == null);


        }
    }

    void changeLevel(int level)
    {
        this.level = level;
        foreach (GameObject tmpGate in gateList)    //게이트리스트를 순회하며 레벨에 맞게 속도 조절
        {
            gateScript gateScript = tmpGate.GetComponent<gateScript>();
            gateScript.setVelocity(level * -1f);
        }
        
    }
}


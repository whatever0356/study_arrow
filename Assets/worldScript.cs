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


    List<GameObject> gateList = new List<GameObject>(); //����Ʈ�� �ֱ������� ����� �������Ƿ� ����Ʈ�� ���� ����.
    List<GameObject> monsterList = new List<GameObject>();

    public float gateCooltime; // ��Ÿ�� ���. ����Ʈ ��Ÿ���� �ν�����â���� �����غ��� ���� ���� �ٽ� �����̺����� �����ʿ�.
    public float currentGateCooltime; //���� ���� ��Ÿ��
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

            if(Random.Range(1, 3) == 1) //1�̸� ���ʿ� 2�� �����ʿ� ��ȯ
            {
                gateList.Add(Instantiate(gatePrefab, gatePosL, transform.rotation));//�� �ν��Ͻ� ����Ʈ ����Ʈ�� �߰�
            }
            else
            {
                gateList.Add(Instantiate(gatePrefab, gatePosR, transform.rotation));//�� �ν��Ͻ� ����Ʈ ����Ʈ�� �߰�
            }
            gateList.RemoveAll(item => item == null);   //���ٽ�. removeAll�� ������ �Ǻ��� �Ҹ��� ��ȯ�ϴ��Լ��� �Ű������� ����. �̸� ���ٽ����� ������ �־���
                                                        //gate����Ʈ�� �߰��߰� null�� ���ִ°� ���ִ¿뵵.

        }

        if(currentMonsterCooltime > 0)
        {
            currentMonsterCooltime -= Time.deltaTime;
        }
        else
        {
            currentMonsterCooltime = monsterCooltime;
            if (Random.Range(1, 3) == 1) //1�̸� ���ʿ� 2�� �����ʿ� ��ȯ
            {
                monsterList.Add(Instantiate(monsterPrefab, gatePosL, transform.rotation));
            }
            else
            {
               monsterList.Add(Instantiate(monsterPrefab, gatePosR, transform.rotation));//�� �ν��Ͻ� ����Ʈ ����Ʈ�� �߰�
            }
            monsterList[monsterList.Count - 1].GetComponent<monsterStat>().setSpeed(1);
            monsterList[monsterList.Count - 1].GetComponent<monsterStat>().setHp(2);
            monsterList.RemoveAll(item => item == null);


        }
    }

    void changeLevel(int level)
    {
        this.level = level;
        foreach (GameObject tmpGate in gateList)    //����Ʈ����Ʈ�� ��ȸ�ϸ� ������ �°� �ӵ� ����
        {
            gateScript gateScript = tmpGate.GetComponent<gateScript>();
            gateScript.setVelocity(level * -1f);
        }
        
    }
}


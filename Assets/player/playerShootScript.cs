using UnityEngine;

public class playerShootScript : MonoBehaviour
{
    playerStat playerStat;
    public GameObject arrowPrefab;
    arrowScript ArrowScript;

    float coolTime;
    float currentCoolTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStat = GetComponent<playerStat>();
        coolTime = 1 * (100f - playerStat.getAtkSpeed()) / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCoolTime <= 0)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
            ArrowScript = arrow.GetComponent<arrowScript>();
            ArrowScript.setArrowSpeed(playerStat.getArrowSpeed());
            ArrowScript.setArrowDamage(playerStat.getAtkDamage());
            currentCoolTime = coolTime;
        }
        else
        {
            currentCoolTime -= Time.deltaTime;
        }


        
    }
}

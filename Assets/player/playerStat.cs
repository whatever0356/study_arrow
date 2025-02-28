using UnityEngine;

public class playerStat : MonoBehaviour
{

    int hp = 100;

    [SerializeField] int maxHp = 100;
    [SerializeField] int atkSpeed = 1;
    [SerializeField] int atkDamage = 1;
    [SerializeField] int arrowSpeed = 1;

    //getter
    public int getMaxHp()
    {
        return maxHp;
    }
    public int getAtkSpeed()
    {
        return atkSpeed;
    }
    public int getAtkDamage()
    {
        return atkDamage;
    }
    public int getArrowSpeed()
    {
        return arrowSpeed;
    }

    public int getHp()
    {
        return hp;
    }

    //setter
    public void setMaxHp(int maxHp)
    {
        this.maxHp = maxHp;
    }
    public void setAtkSpeed(int atkSpeed)
    {
        this.atkSpeed = atkSpeed;
    }
    public void setAtkDamage(int atkDamage)
    {
        this.atkDamage = atkDamage;
    }
    public void setArrowSpeed(int arrowSpeed)
    {
        this.arrowSpeed = arrowSpeed;
    }
    public void setHp(int hp)
    {
        this.hp = hp;
    }


    public void takeDamage(int damage)
    {
        hp -= damage;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

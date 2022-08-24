using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHp;
    public float moveSpeed;
    public float attackSpeed;
    public float attackDamage;
    public string faceDirection;

    private float currentHp;

    void Start()
    {
        faceDirection = "right";
        currentHp = maxHp; 
    }
    void Update()
    {
        if (currentHp <= 0)
            //dead
            Destroy(this.gameObject); //temp

        //Debug.Log(faceDirection);

    }

    public void TakeDamage(float dmg)
    {
        currentHp = currentHp - dmg;
    }
    public void BeSlowed(float slowPercent)
    {
        if (slowPercent > 1)
        {
            moveSpeed = 0;
        }
        else
            moveSpeed = moveSpeed * (1 - slowPercent);
    }

    public void setFace(string direction)
    {
        faceDirection = direction;
    }
}
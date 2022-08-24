using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public float splashDamage;
    Stats collisionStats;
 
    void Start()
    {
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boss")
        {
            Debug.Log("Hit!");
            collisionStats = collision.GetComponent<Stats>();
            collisionStats.TakeDamage(splashDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

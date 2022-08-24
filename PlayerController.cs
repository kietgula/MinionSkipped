using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode splash;

    public Stats stats;

    public GameObject splashPrefab;

    public Transform topSplash;
    public Transform bottomSplash;
    public Transform leftSplash;
    public Transform rightSplash;

    private float nextDamageEvent;

    void Start()
    {
        nextDamageEvent = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        Move(Input.GetKey(up), Input.GetKey(down), Input.GetKey(left), Input.GetKey(right));
        if (Time.time > nextDamageEvent)
        { 
            Splash(Input.GetKey(splash));
            if (Input.GetKey(splash))
                nextDamageEvent = Time.time + 1 / stats.attackSpeed;
        }
    }

    void Move(bool up, bool down, bool left, bool right)
    {
        Vector3 v = new Vector3(0, 0, 0);
        if (up == true)
            v.y = v.y + 1;
        if (down == true)
            v.y = v.y - 1;
        if (left == true)
            v.x = v.x - 1;
        if (right == true)
            v.x = v.x + 1;

        if (v.x == 1)
            stats.setFace("right");
        else if (v.x == -1)
            stats.setFace("left");
        else if (v.y == 1)
            stats.setFace("top");
        else if (v.y == -1)
            stats.setFace("bot");

        transform.Translate(v * stats.moveSpeed * Time.deltaTime);
    }

    void Splash(bool key)
    {
        if (key == true)
        {
            if (stats.faceDirection == "top")
                Instantiate(splashPrefab, topSplash.position, topSplash.rotation);
            else if (stats.faceDirection == "left")
                Instantiate(splashPrefab, leftSplash.position, leftSplash.rotation);
            else if (stats.faceDirection == "right")
                Instantiate(splashPrefab, rightSplash.position, rightSplash.rotation);
            else if (stats.faceDirection == "bot")
                Instantiate(splashPrefab, bottomSplash.position, bottomSplash.rotation);
        }

    }    

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Color RisingColor, FallingColor;
    public GameObject visual;
    public bool isActivated;
    private bool isCooldown = false;
    private bool canMove = false;

    private bool ReachedDestination = false;

    public float Speed = 2;
    public float startValue = 0;
    public float endValue = 10;

    void Update()
    {
        if (isActivated)
        {
            visual.GetComponent<SpriteRenderer>().color = RisingColor;
        }
        else
        {
            visual.GetComponent<SpriteRenderer>().color = FallingColor;
        }
        float step = Speed * Time.deltaTime;
        if (canMove)
        {
            if (isActivated)
            {
                if (transform.position.y == endValue)
                {
                    ReachedDestination = true;
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, endValue), step);
            }
            else
            {
                if (transform.position.y == startValue)
                {
                    ReachedDestination = true;
                }
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, startValue), step);
            }
        }
    }
    IEnumerator Lerp()
    {
        isCooldown = true;
        canMove = true;
        yield return new WaitUntil(() => ReachedDestination);
        canMove = false;
        isCooldown = false;
        ReachedDestination = false;
    }
    
    public void MovePos()
    {
        if (!isCooldown)
        {
            StartCoroutine(Lerp());
            if (isActivated)
            {
                isActivated = false;
            }
            else
            {
                isActivated = true;
            }
        }
    }
}

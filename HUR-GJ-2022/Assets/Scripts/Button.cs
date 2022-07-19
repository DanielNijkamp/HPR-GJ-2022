using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
    }
    public void MoveCubes()
    {
        this.anim.Play("ButtonPress");
        Blocks[] blocks = GameObject.FindObjectsOfType<Blocks>();
        foreach (Blocks block in blocks)
        {
            block.MovePos();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MoveCubes();
        }
    }
}

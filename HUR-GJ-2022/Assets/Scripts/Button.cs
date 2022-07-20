using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isCooldown = false;
    private Animator anim;
    public ButtonType buttontype;
    public float temp_cooldown;
    public enum ButtonType
    {
        Normal,
        Temporary,
        Door
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
    }
    public void MoveCubes()
    {
        
        if (!isCooldown)
        {
            this.anim.Play("ButtonPress");
            Blocks[] blocks = GameObject.FindObjectsOfType<Blocks>();
            foreach (Blocks block in blocks)
            {
                block.MovePos();
            }
            StartCoroutine(Cooldown());
        }
        
    }
    public void TempMoveCubes()
    {
        if (!isCooldown)
        {
            StartCoroutine(TempMoveCR());
        }
    }
    IEnumerator TempMoveCR()
    {
        this.anim.Play("ButtonPress");
        Blocks[] blocks = GameObject.FindObjectsOfType<Blocks>();
        foreach (Blocks block in blocks)
        {
            block.MovePos();
        }
        StartCoroutine(Cooldown());
        yield return new WaitForSeconds(temp_cooldown);
        foreach (Blocks block in blocks)
        {
            block.MovePos();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (buttontype)
            {
                case ButtonType.Normal:
                    MoveCubes();
                    break;
                case ButtonType.Temporary:
                    TempMoveCubes();
                    break;
            }
        }
    }
    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1.5f);
        isCooldown = false;
    }
}

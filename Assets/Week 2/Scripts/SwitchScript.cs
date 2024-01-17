using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(255, 255, 0, .2f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(255, 0, 0, .2f);
    }
}

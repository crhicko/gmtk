using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSlot : MonoBehaviour
{

    public Team team;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.childCount > 0)
            if(gameObject.transform.GetChild(0).GetComponent<Unit>().isSelected == true)
                spriteRenderer.color = Color.green;
            else
                spriteRenderer.color = Color.red;

    }
}

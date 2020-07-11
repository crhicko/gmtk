using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit : MonoBehaviour
{
    public int maxhp;
    public int hp;
    public string _name;
    public Team team;
    public int speed;

    public int controlCount;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int TakeDamage(int damage) {
        hp -= damage;
        if(hp < 0)
            Destroy(gameObject);
        return hp;
    }

    private void OnDestroy() {
        Debug.Log("I DIE");
    }
}

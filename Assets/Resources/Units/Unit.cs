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

    private Collider2D cldr;

    public bool isTargettable = false;
    public bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        cldr = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState == GameState.PlayerTurnMenu && isTargettable) {
            if(Input.GetMouseButtonDown(0)){
                isSelected = true;
            }
        }

        if(isSelected) {
           
        }

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

    public void SelectableEventHandler(AbilityTargetingType abilityTargetingType) {
        if(abilityTargetingType == AbilityTargetingType.Individual) {
            isTargettable = !isTargettable;
            isSelected = false;
        }
        else if(abilityTargetingType == AbilityTargetingType.Group) {
            isSelected = true;
        }
    }
}

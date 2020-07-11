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

    public bool inTargettingMode = false;

    // Start is called before the first frame update
    void Start()
    {
        cldr = gameObject.GetComponent<Collider2D>();
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isSelected);
        if(GameManager.Instance.gameState == GameState.PlayerTurnTargeting && isTargettable) {
            if(Input.GetMouseButtonDown(0)){
                RaycastHit2D hitInfo = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                if(hitInfo.collider != null && hitInfo.collider.gameObject == gameObject)
                    isSelected = true;
            }
        }

        if(isSelected) {
            Debug.Log("This unit " + gameObject.name + " has been selected");
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
        Debug.Log("Handling event");
        inTargettingMode = !inTargettingMode;

        if(inTargettingMode == true) {
            if(abilityTargetingType == AbilityTargetingType.Individual) {
                isTargettable = true;
                isSelected = false;
            }
            else if(abilityTargetingType == AbilityTargetingType.Group) {
                isSelected = true;
            }
        }
        else {
            isTargettable = false;
            isSelected = false;
        }
    }

}

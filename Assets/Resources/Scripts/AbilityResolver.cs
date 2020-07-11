using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityResolver : MonoBehaviour
{
    private List<GameObject> possibleTargets;
    private List<GameObject> targets;

    public GameObject Checkbox;

    [System.Serializable]
    public class TargettableEvent : UnityEvent<AbilityTargetingType> {}

    public TargettableEvent targettableEvent;

    public Ability ability;

    private GameObject selectedUnit;

    bool isApproved = false;
    bool isAborted = false;

    private void Start() {

    }

    private void Update() {
        StartCoroutine(WaitForApprovalOrAbort());
        if(isApproved) {
            Resolve(ability);
            enabled = false;
        }
    }

    void OnEnable()
    {
        Debug.Log("AbilityResolver activated for: " + ability.GetType().ToString());

        targets = new List<GameObject>();

        possibleTargets = GetPossibleTargets(ability);

        Checkbox.SetActive(true);
        Checkbox.GetComponent<Button>().interactable = false;

        foreach (GameObject t in possibleTargets){
            targettableEvent.AddListener(t.GetComponent<Unit>().SelectableEventHandler);
        }
        targettableEvent.Invoke(ability.abilityTargetingType);


    }

    public void Resolve(Ability ability) {
        Debug.Log("Resolving ability for " + ability.GetType().ToString());
        //on CheckBox
        foreach (GameObject t in possibleTargets)
        {
            Debug.Log(t.GetInstanceID());
            if(t.GetComponent<Unit>().isSelected)
                targets.Add(t);
        }

        foreach(GameObject target in targets){
            Debug.Log(target);
            ability.invoke(target);
        }

        targettableEvent.Invoke(ability.abilityTargetingType);
        targettableEvent.RemoveAllListeners();
        isApproved = false;

    }

    private List<GameObject> GetPossibleTargets(Ability ability) {

        if(ability.abilityTargetingTeam == Team.Enemy) {
            return GameManager.Instance.enemyUnits;
        }
        else
            return GameManager.Instance.playerUnits;
    }

    private IEnumerator WaitForApprovalOrAbort() {

        while(!isApproved && !isAborted )
        {
            yield return null;
        }

        Checkbox.SetActive(false);
    }

    public void ClickHandler(){
        isApproved = true;
    }

    public void OnUnitSelectHandler(GameObject obj) {
        Debug.Log("attach");
        Checkbox.GetComponent<Button>().interactable = true;
        if(ability.abilityTargetingType == AbilityTargetingType.Individual) {
            if(selectedUnit == null)
                selectedUnit = obj;
            else {
                foreach (GameObject target in possibleTargets)
                {
                    if(target != obj)
                        target.GetComponent<Unit>().Deselect();
                }
                selectedUnit = obj;
            }
        }
    }
}

//Get targets
/**
 *
 *
 *
 *
 *
 *
 *
 *
 *
*/

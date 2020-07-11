﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class AbilityResolver : MonoBehaviour
{
    private List<GameObject> possibleTargets;
    private List<GameObject> targets;

    public GameObject Checkbox;

    [System.Serializable]
    public class TargettableEvent : UnityEvent<AbilityTargetingType> {}

    public TargettableEvent targettableEvent;

    public Ability ability;

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

        foreach (GameObject t in possibleTargets){
            targettableEvent.AddListener(t.GetComponent<Unit>().SelectableEventHandler);
        }
        targettableEvent.Invoke(ability.abilityTargetingType);

        Checkbox.SetActive(true);
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

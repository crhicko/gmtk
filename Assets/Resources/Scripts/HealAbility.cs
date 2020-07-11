using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="HealAbility")]
public class HealAbility : Ability {
    public int amount;
    public override void invoke(GameObject target) {
        // target
        Debug.Log(target.GetInstanceID());
        target.GetComponent<Unit>().HealHP(amount);
    }


}
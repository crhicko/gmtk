using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="DmgAbility")]
public class DmgAbility : Ability {
    public int DMGAmount;
    public override void invoke(GameObject target) {
        // target
        Debug.Log(target.GetInstanceID());
        target.GetComponent<Unit>().TakeDamage(DMGAmount);
    }


}
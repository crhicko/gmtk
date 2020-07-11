using UnityEngine;

[CreateAssetMenu(menuName="DmgAbility")]
public class DmgAbility : Ability {
    public int DMGAmount;
    public override void invoke() {
        Debug.Log("Invoking");
    }
}
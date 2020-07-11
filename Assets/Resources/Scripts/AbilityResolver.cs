using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityResolver : MonoBehaviour
{
    public void Resolve(Ability ability) {
        Debug.Log(ability.GetType().ToString());

    }
}

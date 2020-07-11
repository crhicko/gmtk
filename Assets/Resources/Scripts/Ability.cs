using UnityEngine;

public enum AbilityTargetingType {
    Individual,
    Group
}


public abstract class Ability : ScriptableObject {
    public AbilityTargetingType abilityTargetingType;
    public Team abilityTargetingTeam;
    public abstract void invoke(GameObject target);
}
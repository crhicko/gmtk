using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum GameState{
    End,
    PlayerTurnMenu,
    PlayerTurnTargeting,
    Resolving,
    EnemyTurn
}

public class GameManager : MonoBehaviour
{
    public List<FieldSlot> playerSlots;
    public List<FieldSlot> enemySlots;

    [SerializeField]
    public List<GameObject> playerUnits;
    [SerializeField]
    public List<GameObject> enemyUnits;

    public List<GameObject> turnOrder;

    public GameObject testUnit;

    private static GameManager _instance;
    public static GameManager Instance { get {
        return _instance;
    }}

    public GameState gameState;

    //Starts disabled, begins working on enabled
    private AbilityResolver abilityResolver;


    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        abilityResolver = GetComponent<AbilityResolver>();

        List<GameObject> tempUnitList = new List<GameObject>();

        //create the characters on the field in the desired slots
        foreach(GameObject unit in playerUnits) {
            List<FieldSlot> emptySlots = GetEmptySlots(playerSlots);
            if(emptySlots.Count == 0)
                continue;
            GameObject obj = Instantiate(testUnit, transform.position, Quaternion.identity);
            obj.transform.parent = emptySlots[0].transform;
            obj.transform.localPosition = Vector3.zero;
            tempUnitList.Add(obj);
        }
        playerUnits = tempUnitList;
        tempUnitList.Clear();

        foreach(GameObject unit in enemyUnits) {
            List<FieldSlot> emptySlots = GetEmptySlots(enemySlots);
            if(emptySlots.Count == 0)
                continue;
            GameObject obj = Instantiate(testUnit, transform.position, Quaternion.identity);
            obj.transform.parent = emptySlots[0].transform;
            obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<Unit>().team = Team.Enemy;
            tempUnitList.Add(obj);
        }
        enemyUnits = tempUnitList;

        turnOrder = CreateTurnOrder();
        if(turnOrder[0].GetComponent<Unit>().team == Team.Player)
            gameState = GameState.PlayerTurnMenu;
        else
            gameState = GameState.EnemyTurn;
    }

    // Update is called once per frame
    void Update()
    {

        switch (gameState)
        {
            case GameState.PlayerTurnMenu:
                break;
            case GameState.PlayerTurnTargeting:
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.End:
                break;
            default:
                Debug.Log("Shouldnt be here");
                break;
        }


        //check for end of game
        if(playerUnits.Count == 0) {
            //Player Loses
            Debug.Log("player loses");
            gameState = GameState.End;
        }
        if(enemyUnits.Count == 0) {
            Debug.Log("enemy loses");
            gameState = GameState.End;
        }
    }

    public void OnSelectedAbility(Ability ability) {
        gameState = GameState.PlayerTurnTargeting;
        abilityResolver.ability = ability;
        abilityResolver.enabled = true;
    }

    public List<FieldSlot> GetEmptySlots(List<FieldSlot> fieldSlots) {

        List<FieldSlot> tempFieldSlots = new List<FieldSlot>();

        foreach (FieldSlot fs in fieldSlots)
        {
            if(fs.gameObject.transform.childCount == 0) {
                tempFieldSlots.Add(fs);
            }
        }

        return tempFieldSlots;
    }

    private List<GameObject> CreateTurnOrder() {
        List<GameObject> units = new List<GameObject>();
        units.AddRange(playerUnits);
        units.AddRange(enemyUnits);
        units.OrderBy(u=>u.GetComponent<Unit>().speed).ToList();

        return units;
    }
}

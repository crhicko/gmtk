using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public enum GameState{
    End,
    PlayerTurnMenu,
    PlayerTurnTargeting,
    Resolving,
    EnemyTurn,
    EndOfTurn
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

    private static GameManager _instance;
    public static GameManager Instance { get {
        return _instance;
    }}

    public GameState gameState;
    public GameObject activeTurnUnit;

    public GameObject menuWarrior;
    public GameObject menuWizard;
    public GameObject menuHealer;

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

        //Disable all menus
        menuWarrior.SetActive(false);
        menuWizard.SetActive(false);
        menuHealer.SetActive(false);

        //create the characters on the field in the desired slots
        foreach(GameObject unit in playerUnits) {
            List<FieldSlot> emptySlots = GetEmptySlots(playerSlots);
            if(emptySlots.Count == 0)
                continue;
            GameObject obj = Instantiate(unit, transform.position, Quaternion.identity);
            obj.transform.parent = emptySlots[0].transform;
            obj.transform.localPosition = new Vector3(0, 0.1f, -1);
            tempUnitList.Add(obj);
        }
        playerUnits.Clear();
        playerUnits = tempUnitList.GetRange(0,tempUnitList.Count);
        tempUnitList.Clear();

        foreach(GameObject unit in enemyUnits) {
            List<FieldSlot> emptySlots = GetEmptySlots(enemySlots);
            if(emptySlots.Count == 0)
                continue;
            GameObject obj = Instantiate(unit, transform.position, Quaternion.identity);
            obj.transform.parent = emptySlots[0].transform;
            obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<Unit>().team = Team.Enemy;
            tempUnitList.Add(obj);
        }
        enemyUnits = tempUnitList.GetRange(0,tempUnitList.Count);

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
                turnOrder[0].GetComponent<Unit>().menu.SetActive(true);
                Debug.Log("IT IS THE PLAYERS TURN");
                break;
            case GameState.PlayerTurnTargeting:
                break;
            case GameState.EnemyTurn:
                Debug.Log("IT IS THE ENEMIES TURN");
                gameState = GameState.EndOfTurn;
                break;
            case GameState.EndOfTurn:
                Debug.Log("Ending Turn");
                if(turnOrder[0].GetComponent<Unit>().team == Team.Player)
                    turnOrder[0].GetComponent<Unit>().menu.SetActive(false);
                CycleTurnOrder();
                if(turnOrder[0].GetComponent<Unit>().team == Team.Player)
                    gameState = GameState.PlayerTurnMenu;
                else
                    gameState = GameState.EnemyTurn;
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
        units.Sort(SortBySpeed);

        return units;
    }

    private static int SortBySpeed(GameObject p1, GameObject p2) {
        return p2.GetComponent<Unit>().speed.CompareTo(p1.GetComponent<Unit>().speed);
    }

    private List<GameObject> UpdateTurnOrder(List<GameObject> _turnOrder) {
        _turnOrder.Sort(SortBySpeed);
        return _turnOrder;
    }

    private void CycleTurnOrder() {
        GameObject temp;
        temp = turnOrder[0];
        turnOrder.RemoveAt(0);
        turnOrder.Add(temp);
        activeTurnUnit.GetComponent<SpriteRenderer>().sprite = turnOrder[0].GetComponent<SpriteRenderer>().sprite;
    }

    public void EndTurn() {
        gameState = GameState.EndOfTurn;
    }
}

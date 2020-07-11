using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public List<FieldSlot> playerSlots;
    public List<FieldSlot> enemySlots;

    [SerializeField]
    private List<GameObject> playerUnits;
    [SerializeField]
    private List<GameObject> enemyUnits;

    public List<GameObject> turnOrder;

    // Start is called before the first frame update
    void Start()
    {
        //create the characters on the field in the desired slots
        foreach(GameObject unit in playerUnits) {
            List<FieldSlot> emptySlots = GetEmptySlots(playerSlots);
            if(emptySlots.Count == 0)
                continue;
            GameObject obj = Instantiate(unit) as GameObject;
            obj.transform.parent = emptySlots[0].transform;
            obj.transform.localPosition = Vector3.zero;
        }

        foreach(GameObject unit in enemyUnits) {
            List<FieldSlot> emptySlots = GetEmptySlots(enemySlots);
            if(emptySlots.Count == 0)
                continue;
            GameObject obj = Instantiate(unit) as GameObject;
            obj.transform.parent = emptySlots[0].transform;
            obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<Unit>().team = Team.Enemy;
        }

        turnOrder = CreateTurnOrder();
    }

    // Update is called once per frame
    void Update()
    {

        //check for end of game
        if(playerUnits.Count == 0) {
            //Player Loses
            Debug.Log("player loses");
        }
        if(enemyUnits.Count == 0) {
            Debug.Log("enemy loses");
        }
    }

    public void CreateUnitInstance(Unit unit) {

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;



public class Menu : MonoBehaviour
{

    public GameObject mainMenu, skillMenu, skillSwordMenu, skillDefensiveMenu;

    public GameObject mainFirstButton, skillFirstButton, skillSwordFirstButton, skillDefensiveFirstButton;


    public List<GameObject> allMenus = new List<GameObject>();

    private GameObject activeMenu;

    public GameObject controlCount;

    public int control = 10;
    // Start is called before the first frame update


    void OnEnable()
    {
        activeMenu = mainMenu;
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }
    void Start()
    {
        allMenus.Add(mainMenu);
        allMenus.Add(skillMenu);
        allMenus.Add(skillSwordMenu);
        allMenus.Add(skillDefensiveMenu);

        activeMenu = mainMenu;
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(activeMenu == skillMenu)
            {
                openMainMenu();
                removeControl();
            }
            else if(activeMenu == skillSwordMenu)
            {
                openSkillMenu();
                removeControl();
            }
            else if(activeMenu == skillDefensiveMenu)
            {
                openSkillMenu();
                removeControl();
            }
            else{}

        }
    }

    public void openMainMenu()
    {
        setFirstButton();
        closeMenus();
        mainMenu.SetActive(true);
        activeMenu = mainMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);

    }
    public void openSkillMenu()
    {

        setFirstButton();
        closeMenus();
        skillMenu.SetActive(true);
        activeMenu = skillMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillFirstButton);

    }
    public void openSkillSwordMenu()
    {
        setFirstButton();
        closeMenus();
        skillSwordMenu.SetActive(true);
        activeMenu = skillSwordMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillSwordFirstButton);

    }
    public void openSkillDefensiveMenu()
    {
        setFirstButton();
        closeMenus();
        skillDefensiveMenu.SetActive(true);
        activeMenu = skillDefensiveMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillDefensiveFirstButton);

    }

    private void closeMenus()
    {
        foreach(GameObject menu in allMenus)
        {
            menu.SetActive(false);
        }
    }

    private void setFirstButton()
    {

        if(activeMenu == mainMenu)
        {
            mainFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillMenu)
        {
            skillFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillSwordMenu)
        {
            skillSwordFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillDefensiveMenu)
        {
            skillDefensiveFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else{}
    }
    public void removeControl()
    {
        Debug.Log("LOSING CONTROL");
        control--;
        controlCount.SendMessage("changeCount", control);
        if(control <= 0)
        {
            Debug.Log("OUT OF CONTROL");
        }
    }
    public void pass()
    {
        Debug.Log("TurnPassed");
    }
}

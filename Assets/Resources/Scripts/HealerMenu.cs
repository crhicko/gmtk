using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;



public class HealerMenu : MonoBehaviour
{

    public GameObject mainMenu, skillMenu, skillManipulateMenu, skillHealMenu;

    public GameObject mainFirstButton, skillFirstButton, skillManipulateFirstButton, skillHealFirstButton;


    public List<GameObject> allMenus = new List<GameObject>();

    private GameObject activeMenu;

    public GameObject controlCount;

    public int control = 10;
    // Start is called before the first frame update
    void Start()
    {
        allMenus.Add(mainMenu);
        allMenus.Add(skillMenu);
        allMenus.Add(skillManipulateMenu);
        allMenus.Add(skillHealMenu);

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
            else if(activeMenu == skillManipulateMenu)
            {
                openSkillMenu();
                removeControl();
            }
            else if(activeMenu == skillHealMenu)
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
    public void openManipulateMenu()
    {   
        
        setFirstButton();
        closeMenus();
        skillManipulateMenu.SetActive(true);
        activeMenu = skillManipulateMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillManipulateFirstButton);

    }
    public void openHealMenu()
    {   
        
        setFirstButton();
        closeMenus();
        skillHealMenu.SetActive(true);
        activeMenu = skillHealMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillHealFirstButton);

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
        else if(activeMenu == skillManipulateMenu)
        {
            skillManipulateFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillHealMenu)
        {
            skillHealFirstButton = EventSystem.current.currentSelectedGameObject;
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

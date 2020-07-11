using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class WizardMenu : MonoBehaviour
{

    public GameObject mainMenu, skillMenu, skillFireMenu, skillAirMenu, skillEarthMenu, skillFire2Menu, skillAir2Menu, skillEarth2Menu, skillFire3Menu, skillAir3Menu, skillEarth3Menu;

    public GameObject mainFirstButton, skillFirstButton, skillFireFirstButton, skillAirFirstButton, skillEarthFirstButton, skillFire2FirstButton, skillAir2FirstButton, skillEarth2FirstButton, skillFire3FirstButton, skillAir3FirstButton, skillEarth3FirstButton;


    public List<GameObject> allMenus = new List<GameObject>();


    private GameObject activeMenu;

    public GameObject controlCount;

    public int control = 10;
    // Start is called before the first frame update
    void Start()
    {
        allMenus.Add(mainMenu);
        allMenus.Add(skillMenu);
        allMenus.Add(skillFireMenu);
        allMenus.Add(skillFire2Menu);
        allMenus.Add(skillFire3Menu);
        allMenus.Add(skillAirMenu);
        allMenus.Add(skillAir2Menu);
        allMenus.Add(skillAir3Menu);
        allMenus.Add(skillEarthMenu);
        allMenus.Add(skillEarth2Menu);
        allMenus.Add(skillEarth3Menu);

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
            else if(activeMenu == skillFireMenu)
            {
                openSkillMenu();
                removeControl();
 
            }
            else if(activeMenu == skillFire2Menu)
            {
                openSkillFireMenu();
                removeControl();
            }
            else if(activeMenu == skillFire3Menu)
            {
                openSkillFire2Menu();
                removeControl();
            }
            else if(activeMenu == skillAirMenu)
            {
                openSkillMenu();
                removeControl();
 
            }
            else if(activeMenu == skillAir2Menu)
            {
                openSkillAirMenu();
                removeControl();
            }
            else if(activeMenu == skillAir3Menu)
            {
                openSkillAir2Menu();
                removeControl();
            }
            else if(activeMenu == skillEarthMenu)
            {
                openSkillMenu();
                removeControl();
 
            }
            else if(activeMenu == skillEarth2Menu)
            {
                openSkillEarthMenu();
                removeControl();
            }
            else if(activeMenu == skillEarth3Menu)
            {
                openSkillEarth2Menu();
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
    public void openSkillFireMenu()
    {   
        setFirstButton();
        closeMenus();
        skillFireMenu.SetActive(true);
        activeMenu = skillFireMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillFireFirstButton);

    }
    public void openSkillFire2Menu()
    {   
        setFirstButton();
        closeMenus();
        skillFire2Menu.SetActive(true);
        activeMenu = skillFire2Menu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillFire2FirstButton);

    }
    public void openSkillFire3Menu()
    {   
        setFirstButton();
        closeMenus();
        skillFire3Menu.SetActive(true);
        activeMenu = skillFire3Menu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillFire3FirstButton);

    }
    
    public void openSkillAirMenu()
    {   
        setFirstButton();
        closeMenus();
        skillAirMenu.SetActive(true);
        activeMenu = skillAirMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillAirFirstButton);

    }
    public void openSkillAir2Menu()
    {   
        setFirstButton();
        closeMenus();
        skillAir2Menu.SetActive(true);
        activeMenu = skillAir2Menu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillAir2FirstButton);

    }
    public void openSkillAir3Menu()
    {   
        setFirstButton();
        closeMenus();
        skillAir3Menu.SetActive(true);
        activeMenu = skillAir3Menu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillAir3FirstButton);

    }

    public void openSkillEarthMenu()
    {   
        setFirstButton();
        closeMenus();
        skillEarthMenu.SetActive(true);
        activeMenu = skillEarthMenu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillEarthFirstButton);

    }
    public void openSkillEarth2Menu()
    {   
        setFirstButton();
        closeMenus();
        skillEarth2Menu.SetActive(true);
        activeMenu = skillEarth2Menu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillEarth2FirstButton);

    }
    public void openSkillEarth3Menu()
    {   
        setFirstButton();
        closeMenus();
        skillEarth3Menu.SetActive(true);
        activeMenu = skillEarth3Menu;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(skillEarth3FirstButton);

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

        else if(activeMenu == skillFireMenu)
        {
            skillFireFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillFire2Menu)
        {
            skillFire2FirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillFire3Menu)
        {
            skillFire3FirstButton = EventSystem.current.currentSelectedGameObject;
        }

        else if(activeMenu == skillAirMenu)
        {
            skillAirFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillAir2Menu)
        {
            skillAir2FirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillAir3Menu)
        {
            skillAir3FirstButton = EventSystem.current.currentSelectedGameObject;
        }

        else if(activeMenu == skillEarthMenu)
        {
            skillEarthFirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillEarth2Menu)
        {
            skillEarth2FirstButton = EventSystem.current.currentSelectedGameObject;
        }
        else if(activeMenu == skillEarth3Menu)
        {
            skillEarth3FirstButton = EventSystem.current.currentSelectedGameObject;
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

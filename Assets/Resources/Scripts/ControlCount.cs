using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlCount : MonoBehaviour
{
    // Start is called before the first frame update


    TMP_Text countText;
    void Start()
    {
        countText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeCount(int changeValue)
    {
        countText.text = changeValue.ToString();
    }
}

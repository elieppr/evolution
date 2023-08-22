using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public Creature creature;
    private GameObject[] agentList;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleColor);
    }

    private void ToggleColor()
    {
        agentList = GameObject.FindGameObjectsWithTag("Agent");

        for (int i = 0; i < agentList.Length; i++)
        {
            Creature creature = agentList[i].GetComponent<Creature>();
            creature.isColored = !creature.isColored;
        }
    }
}

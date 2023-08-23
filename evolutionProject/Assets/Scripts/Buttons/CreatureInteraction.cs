using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CreatureInteraction : MonoBehaviour
{
    public GameObject statsPanel; // Reference to the UI panel for stats
    public TMP_Text statsText; // Text component in the UI panel to display stats

    public Creature creature;
    private bool isActive = false;
    private bool isActive2 = false;

    private bool isHighlighted = false;
    private Outline outline;
    private void Awake()
    {
        // Initialize references
        //statsPanel.SetActive(false);
        creature = gameObject.GetComponent<Creature>();

        outline = GetComponent<Outline>();
        outline.enabled = false;

    }

    private void OnMouseDown()
    {
        // Show the stats panel and update stats text
        
        statsPanel.SetActive(true);
        isActive2 = true;
        // HIGHLIGHT CREATURE?????
        UpdateStatsText();
        Highlight();
        Debug.Log("                              ACTIVEEE " + isActive);
    }
    private void Update()
    {
        UpdateStatsText();
        if (isActive)
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    statsPanel.SetActive(false);
                    isActive = false;
                    isActive2 = false;
                    Highlight();
                    Debug.Log("                              ACTIVEEE " + isActive);
                }
            }
        }
        if (isActive2) isActive = true;
    }

    private void UpdateStatsText()
    {
        // Retrieve and display creature stats in the UI text component
        string stats = "Creature Stats:\n" +
                       $"Energy: {creature.energy}\n" +
                       $"Life Span: {creature.lifeSpan.ToString("0.00")}\n" +
                       $"Reproduction Energy: {creature.reproductionEnergy}\n" +
                       $"Size: {creature.size}\n" +
                       $"FB, LR: {creature.FB.ToString("0.000")}, {creature.LR.ToString("0.000")}\n" +
                       $"Number of Children: {creature.totalOffspring}\n";
                       //$"Number of Children: {creature.numberOfChildren}/n" +
                       //$"Number of Children: {creature.}\n" +                     /// ADD MORE STUFF AND MAKE SCROLLER SO THEN JUST ADD EVERYTHING 
        //$"Number of Children: {creature.numberOfChildren}\n";

        statsText.text = stats;
    }

    public void Highlight()
    {
        isHighlighted = !isHighlighted;
        outline.enabled = isHighlighted;
    }
}

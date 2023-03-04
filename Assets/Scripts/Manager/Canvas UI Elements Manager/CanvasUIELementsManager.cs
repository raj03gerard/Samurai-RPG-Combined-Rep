using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasUIELementsManager : MonoBehaviour
{   
    [SerializeField]
    GameObject UIButtonsContainer;
    [SerializeField]
    GameObject HealthbarsAndEnemyPrompts;
    [SerializeField]
    GameObject DialogElementsContainer;
    private void OnEnable()
    {
        GameManager.HideAllUIElementsWhileNPCInteraction += DisableUIButtonsContainer;
        GameManager.HideAllUIElementsWhileNPCInteraction += DisableHealthBarsAndEnemyPrompts;

        GameManager.ShowHiddenUIElementsAfterNPCInteraction += EnableUIButtonsContainer;
        GameManager.ShowHiddenUIElementsAfterNPCInteraction += EnableHealthBarsAndEnemyPrompts;
    }

    private void OnDisable()
    {
        GameManager.HideAllUIElementsWhileNPCInteraction -= DisableUIButtonsContainer;
        GameManager.HideAllUIElementsWhileNPCInteraction -= DisableHealthBarsAndEnemyPrompts;

        GameManager.ShowHiddenUIElementsAfterNPCInteraction -= EnableUIButtonsContainer;
        GameManager.ShowHiddenUIElementsAfterNPCInteraction -= EnableHealthBarsAndEnemyPrompts;
    }
    void DisableUIButtonsContainer()
    {
        UIButtonsContainer.SetActive(false);
    }
    void EnableUIButtonsContainer()
    {
        UIButtonsContainer.SetActive(true);
    }

    void EnableHealthBarsAndEnemyPrompts()
    {
        HealthbarsAndEnemyPrompts.SetActive(true);
    }
    void DisableHealthBarsAndEnemyPrompts()
    {
        HealthbarsAndEnemyPrompts.SetActive(false);
    }

    void EnableDialogElementsContainer()
    {
        DialogElementsContainer.SetActive(true);
    }
    void DisableDialogElementsContainer()
    {
        DialogElementsContainer.SetActive(false);
    }
}

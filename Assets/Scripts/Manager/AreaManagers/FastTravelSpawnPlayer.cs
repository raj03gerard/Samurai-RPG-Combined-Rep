using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravelSpawnPlayer : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
   [SerializeField]
   Animator CinemachineAnimController;

    [SerializeField]
    GameObject EscapePrompt;
    bool HasDisplayBeenActivated = false;
   public void SpawnAtLocation(GameObject SpawnLocation)
    {
        Debug.Log(SpawnLocation.gameObject.name);
        Player.transform.position = SpawnLocation.transform.position;
        CinemachineAnimController.Play(SpawnLocation.gameObject.name);
        EscapePrompt.SetActive(false);
    }
    public void DisplayLocationName(GameObject DisplayUI)
    {



            StartCoroutine(ActivatePrompt(DisplayUI));

    }
    IEnumerator ActivatePrompt(GameObject DisplayUI)
    {
        yield return new WaitForSeconds(1f);
        DisplayUI.SetActive(true);
        StartCoroutine(DeactivatePrompt(DisplayUI));
    }
    IEnumerator DeactivatePrompt(GameObject DisplayUI)
    {
        yield return new WaitForSeconds(3f);
        DisplayUI.SetActive(false);
    }
}

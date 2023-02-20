using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mikoshi_Nyudo_Area : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.enemy_engaged_with = GameManager.EnemyNames.Mikoshi_Nyudo;
            gameManager.ShowBossPrompt(GameManager.EnemyNames.Mikoshi_Nyudo);
            Debug.Log("Player Entered M_Nyudo territory");
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            gameManager.enemy_engaged_with = GameManager.EnemyNames.Default;
            gameManager.isFightingBoss = false;
        }
    }
}

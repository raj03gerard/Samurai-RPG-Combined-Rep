using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jorogumo_Area : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.enemy_engaged_with = GameManager.EnemyNames.Jorogumo;
            gameManager.PlayBossCinematic(GameManager.EnemyNames.Jorogumo);
            Debug.Log("Player Entered Jorogumo territory");
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.enemy_engaged_with = GameManager.EnemyNames.Default;
            gameManager.isFightingBoss = false;
        }
    }
}

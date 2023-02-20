using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;

    private bool respawn;

    private CinemachineVirtualCamera CVC;


    [SerializeField]
    GameObject Mikoshi_Nyudo_Health_Bar;
    [SerializeField]
    GameObject Mikoshi_Nyudo_Boss_Prompt;

    public GameObject Boss_Prompt;
    GameObject Boss_Health_Bar;
    public enum EnemyNames {Default, Jorogumo, Mikoshi_Nyudo, Shunga_Tako, Minion, O_Kiku};

    public bool isFightingBoss= false;
    public EnemyNames enemy_engaged_with= EnemyNames.Default;

    [SerializeField]
    GameObject RedFlashOnScreen;
    [SerializeField]
    GameObject Player;
    Animator CinemachineAnim;
    void OnEnable()
    {
        Combat.FlashScreenRed += FlashRedOnBeingHit;
    }
    void OnDisable()
    {
        Combat.FlashScreenRed -= FlashRedOnBeingHit;
    }
    private void Start()
    {
        CinemachineAnim = GameObject.Find("CM StateDrivenCamera1").GetComponent<Animator>();
        Mikoshi_Nyudo_Health_Bar.SetActive(false);
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
        RedFlashOnScreen.SetActive(false);
    }
    
    private void Update()
    {
        
        if(enemy_engaged_with== EnemyNames.Mikoshi_Nyudo)
        {
            Debug.Log("Engaged w M_Nyudo");
            
            isFightingBoss = true;
        }
        CheckReswapn();
    }
    public void ShowBossPrompt(EnemyNames enemeyName)
    {
        if(enemeyName == EnemyNames.Mikoshi_Nyudo)
        {
            Mikoshi_Nyudo_Boss_Prompt.SetActive(true);
            Boss_Prompt = Mikoshi_Nyudo_Boss_Prompt;
            Boss_Health_Bar = Mikoshi_Nyudo_Health_Bar;
            Time.timeScale = 0;
            Boss_Prompt.transform.Find("CloseBtn").GetComponent<Animator>().Play("BossPromptCloseBtn");
        }
    }
    public void ResumeGameAfterBossPrompt()
    {
        Debug.Log("Remove Boss prompt");
        Time.timeScale = 1;
        Boss_Prompt.SetActive(false);
        Boss_Health_Bar.SetActive(true);
    }
    public void Reswapn()
    {
        respawnTimeStart = Time.time;
        respawn = true; 
    }

    private void CheckReswapn()
    {
        if (Time.time >= respawnTime + respawnTimeStart && respawn)
        {
            var playerTemp = Instantiate(player, respawnPoint);
            CVC.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }

    void FlashRedOnBeingHit()
    {
        RedFlashOnScreen.SetActive(true);
        SpriteRenderer playerSprite = Player.GetComponent<SpriteRenderer>();
        Color org_Color = playerSprite.color;
        playerSprite.color = Color.red;
        StartCoroutine(FlashPlayerRed(org_Color, playerSprite));
        StartCoroutine(HideRedFlashOnScreen());
    }
    IEnumerator FlashPlayerRed(Color org_Color, SpriteRenderer playerSprite)
    {
        yield return new WaitForSeconds(0.5f);
        playerSprite.color = org_Color;
    }
    IEnumerator HideRedFlashOnScreen()
    {
        yield return new WaitForSeconds(0.5f);
        RedFlashOnScreen.SetActive(false);
    }


    
}

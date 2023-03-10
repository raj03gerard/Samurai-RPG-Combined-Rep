using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;

    private bool respawn;

    private CinemachineVirtualCamera CVC;


    [SerializeField]
    GameObject Mikoshi_Nyudo_Health_Bar;
    [SerializeField]
    GameObject Mikoshi_Nyudo_Boss_Prompt;

    [SerializeField]
    GameObject Jorogumo_Health_Bar;
    [SerializeField]
    GameObject Jorogumo_Boss_Prompt;

    [SerializeField]
    GameObject Shunga_Tako_Health_Bar;
    [SerializeField]
    GameObject Shunga_Tako_Boss_Prompt;

    public GameObject Boss_Prompt;
    GameObject Boss_Health_Bar;
    GameObject Boss_Arena_Blocker;
    public enum EnemyNames {Default, Jorogumo, Mikoshi_Nyudo, Shunga_Tako, Minion, O_Kiku};

    public bool isFightingBoss= false;
    public EnemyNames enemy_engaged_with= EnemyNames.Default;

    [SerializeField]
    GameObject RedFlashOnScreen;
    [SerializeField]
    GameObject Player;
    public Animator CinemachineAnim;

    [SerializeField]
    GameObject Mikoshi_Nyudo_Cinematic_Holder;
    [SerializeField]
    GameObject Mikoshi_Nyudo_Main_Body;
    [SerializeField]
    GameObject Mikoshi_Nyudo_Spwan_Point;
    [SerializeField]
    GameObject Mikoshi_Nyudo_VCam;
    [SerializeField]
    GameObject Mikoshi_Nyudo_Arena_Blocker;


    [SerializeField]
    GameObject Jorogumo_Cinematic_Holder;
    [SerializeField]
    GameObject Jorogumo_Main_Body;
    [SerializeField]
    GameObject Jorogumo_Cinematic_VCam;
    [SerializeField]
    GameObject Jorogumo_Arena_Blocker;

    [SerializeField]
    GameObject ShungaTako_Cinematic_Holder;
    [SerializeField]
    GameObject Shunga_Tako_Main_Body;
    [SerializeField]
    GameObject Shunga_Tako_Cinematic_VCam;
    [SerializeField]
    GameObject EscapePrompt;
    bool isEscapePromptActive = false;

    [SerializeField]
     public GameObject EnemyDamgedAmountTextContainer;
    [SerializeField]
    GameObject EnemyDamgedAmountText;
    [SerializeField]

    GameObject StartDialoguePrompt;
    [SerializeField]
    GameObject DialogContainer;
    [SerializeField]
    GameObject DialogText;
    string CurrentDialogue;
    GameObject currentlyInteractingNPC;
    bool isDialogueReady = false;

    [SerializeField]
    GameObject NPC_Cam;
    string Player_V_Cam;

    [SerializeField]
    GameObject PlayerXPText;
    [SerializeField]
    GameObject SkillTreeContainer;
    public delegate void DuringNPCInteraction();
    public static event DuringNPCInteraction HideAllUIElementsWhileNPCInteraction;

    public delegate void AfterNPCInteraction();
    public static event AfterNPCInteraction ShowHiddenUIElementsAfterNPCInteraction;
    void OnEnable()
    {
        Combat.FlashScreenRed += FlashRedOnBeingHit;
        Combat.FlashDamageAmount += FlashEnemyDamageAmount;
        NPC1_InteractState.DialogPrompt += DialogStartPrompt;
        NPC1_ForgetPlayerState.RemoveDialogPrompt += RemoveDialogStartPrompt;
        CinematicEventHandler.ShowBossPromptEvent += DisplayBossPrompt;
    }
    void OnDisable()
    {
        Combat.FlashScreenRed -= FlashRedOnBeingHit;
        Combat.FlashDamageAmount -= FlashEnemyDamageAmount;
        NPC1_InteractState.DialogPrompt -= DialogStartPrompt;
        NPC1_ForgetPlayerState.RemoveDialogPrompt -= RemoveDialogStartPrompt;
        CinematicEventHandler.ShowBossPromptEvent -= DisplayBossPrompt;
    }
    private void Start()
    {
        CinemachineAnim = GameObject.Find("CM StateDrivenCamera1").GetComponent<Animator>();
        Mikoshi_Nyudo_Health_Bar.SetActive(false);
        //CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
        RedFlashOnScreen.SetActive(false);
        EscapePrompt.SetActive(false);
    }
    
    private void Update()
    {
        
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isEscapePromptActive)
            {
                EscapePrompt.SetActive(true);
                isEscapePromptActive = true;
            }
            else
            {
                EscapePrompt.SetActive(false);
                isEscapePromptActive = false;
            }

        }
        if(Input.GetKeyDown(KeyCode.F) && isDialogueReady)
        {
            DisplayDialog();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowSkillTree();
        }

        PlayerXPText.GetComponent<TMP_Text>().text = Player.GetComponent<Player>().additionalStatsData.totalXPCollected.ToString() + " XP";
        CheckReswapn();
    }
    public void PlayBossCinematic(EnemyNames enemyName)
    {
        if(enemyName== EnemyNames.Mikoshi_Nyudo)
        {
            Mikoshi_Nyudo_Cinematic_Holder.SetActive(true);

            CinemachineAnim.Play("Mikoshi Nyudo Cineamtic Cam");
            Boss_Arena_Blocker = Mikoshi_Nyudo_Arena_Blocker;
        }
        else if(enemyName== EnemyNames.Jorogumo)
        {
            Jorogumo_Cinematic_Holder.SetActive(true);
            CinemachineAnim.Play("Jorogumo Cineamtic Cam");
            Boss_Arena_Blocker = Jorogumo_Arena_Blocker;
        }
        else if( enemyName== EnemyNames.Shunga_Tako)
        {
            ShungaTako_Cinematic_Holder.SetActive(true);
            CinemachineAnim.Play("ShungaTako Cineamtic Cam");
            Boss_Arena_Blocker = null;
        }
        if(Boss_Arena_Blocker!=null)
        Boss_Arena_Blocker.SetActive(true);
    }
    void DisplayBossPrompt(EnemyNames enemyName)
    {
        ShowBossPrompt(enemyName);
    }
    public void ShowBossPrompt(EnemyNames enemeyName)
    {
        if(enemeyName == EnemyNames.Mikoshi_Nyudo)
        {
            Mikoshi_Nyudo_Boss_Prompt.SetActive(true);
            Boss_Prompt = Mikoshi_Nyudo_Boss_Prompt;
            Boss_Health_Bar = Mikoshi_Nyudo_Health_Bar;
            Mikoshi_Nyudo_Cinematic_Holder.SetActive(false);
            Mikoshi_Nyudo_Main_Body.SetActive(true);
            Mikoshi_Nyudo_VCam.GetComponent<CinemachineVirtualCamera>().Follow = Mikoshi_Nyudo_Main_Body.transform;
            Time.timeScale = 0;
        }
        else if(enemeyName== EnemyNames.Jorogumo)
        {
            Jorogumo_Boss_Prompt.SetActive(true);
            Boss_Prompt = Jorogumo_Boss_Prompt;
            Boss_Health_Bar = Jorogumo_Health_Bar;
            Jorogumo_Cinematic_Holder.SetActive(false);
            Jorogumo_Main_Body.SetActive(true);
            Jorogumo_Cinematic_VCam.GetComponent<CinemachineVirtualCamera>().Follow = Jorogumo_Main_Body.transform;
            Time.timeScale = 0;
            
        }
        else if(enemeyName== EnemyNames.Shunga_Tako)
        {
            Shunga_Tako_Boss_Prompt.SetActive(true);
            Boss_Prompt = Shunga_Tako_Boss_Prompt;
            Boss_Health_Bar = Shunga_Tako_Health_Bar;
            ShungaTako_Cinematic_Holder.SetActive(false);
            Shunga_Tako_Main_Body.SetActive(true);
            Shunga_Tako_Cinematic_VCam.GetComponent<CinemachineVirtualCamera>().Follow = Shunga_Tako_Main_Body.transform;
            Time.timeScale = 0;
            
        }
    }
    public void ResumeGameAfterBossPrompt(string enemyName)
    {
        Debug.Log("Remove Boss prompt");
        Time.timeScale = 1;
        if (enemyName == "Mikoshi_Nyudo")
            CinemachineAnim.Play("Tunnel");
        else if (enemyName == "Jorogumo")
            CinemachineAnim.Play("SpiderNest");
        else if (enemyName == "ShungaTako")
            CinemachineAnim.Play("ShungaTako");
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
        //if (Time.time >= respawnTime + respawnTimeStart && respawn)
        //{
        //    var playerTemp = Instantiate(player, respawnPoint);
        //    CVC.m_Follow = playerTemp.transform;
        //    respawn = false;
        //}
    }
    public void FlashEnemyDamageAmount(float amount)
    {
        Debug.Log( "damaged by" + amount );
        GameObject textObj = Instantiate(EnemyDamgedAmountText, EnemyDamgedAmountTextContainer.transform);
        textObj.GetComponent<TMP_Text>().text = amount + " Hits!!";
        Destroy(textObj, 2f);
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

    public void DialogStartPrompt(string Dialogue, GameObject interactingNPC, string VCam_Area)
    {
        isDialogueReady = true;
        CurrentDialogue = Dialogue;
        currentlyInteractingNPC = interactingNPC;
        StartDialoguePrompt.SetActive(true);
        Player_V_Cam = VCam_Area;
    }
    public void RemoveDialogStartPrompt(GameObject InteractingNPC)
    {
        StartDialoguePrompt.SetActive(false);
        InteractingNPC.GetComponent<NPC1>().SetHasInteractionEndedTrue();
        currentlyInteractingNPC = null;
    }
    public void DisplayDialog()
    {
        isDialogueReady = false;
        DialogContainer.SetActive(true);
        DialogText.GetComponent<TMP_Text>().text = CurrentDialogue;
        StartDialoguePrompt.SetActive(false);

        Debug.Log(Player_V_Cam);
        CinemachineAnim.Play("NPC Cam");
        NPC_Cam.GetComponent<CinemachineVirtualCamera>().Follow= currentlyInteractingNPC.transform;
        if (HideAllUIElementsWhileNPCInteraction != null)
            HideAllUIElementsWhileNPCInteraction();
    }
    public void CloseDialog()
    {
        isDialogueReady = false;
        CurrentDialogue = "";
        DialogContainer.SetActive(false);
        currentlyInteractingNPC.GetComponent<NPC1>().SetHasInteractionEndedTrue();
        currentlyInteractingNPC = null;
        if (ShowHiddenUIElementsAfterNPCInteraction != null)
            ShowHiddenUIElementsAfterNPCInteraction();
        CinemachineAnim.Play(Player_V_Cam);
    }
    public void ShowSkillTree()
    {
        SkillTreeContainer.SetActive(true);
    }
    public void HideSkillTree()
    {
        SkillTreeContainer.SetActive(false);
    }
}

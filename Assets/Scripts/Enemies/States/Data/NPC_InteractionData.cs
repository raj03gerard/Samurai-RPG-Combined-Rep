using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newNPCInteractionData", menuName = "Data/NPC/NPCInteraction Data")]
public class NPC_InteractionData : ScriptableObject
{
    public string Dialog = "Hi there traveler!";
    public string VCam_Area = "";
}
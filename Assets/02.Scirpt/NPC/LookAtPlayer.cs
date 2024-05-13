using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private NpcInfoes npc;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject keyInfo;
    public CharacterController characterController;
    public PlayerController playerController;
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddNewVisitor(npc.NpcName);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnDialogue()
    {
        playerController.npc = npc;
        dialogueManager.StartDialogue(npc);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            keyInfo.SetActive(true);
            characterController.OnInteractionEvent += OnDialogue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            characterController.OnInteractionEvent -= OnDialogue;
            keyInfo.SetActive(false);
        }
    }
}

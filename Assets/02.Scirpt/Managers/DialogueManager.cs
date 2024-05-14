using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueCanvas;
    [SerializeField]
    private TextMeshProUGUI speakerNameBox;
    [SerializeField]
    private TextMeshProUGUI speakerContentBox;
    [SerializeField]
    private Image speakerImg;
    [SerializeField]
    private Image arrow;
    [SerializeField]
    private GameObject interactionUI;

    public bool IsTyping = false;

    IEnumerator StartTyping(string dialogue)
    {
        IsTyping = true;
        dialogueCanvas.SetActive(true);
        arrow.gameObject.SetActive(false);
        int index = 0;
        while (index <= dialogue.Length)
        {
            speakerContentBox.text = dialogue.Substring(0, index);
            index++;
            yield return new WaitForSeconds(0.05f);
        }
        arrow.gameObject.SetActive(true);
        IsTyping = false;
    }

    public void StartDialogue(NpcInfoes npc)
    {

        interactionUI.SetActive(true);
        speakerNameBox.text = npc.NpcName;
        speakerImg.sprite = npc.NpcSprite;

        int randText = Random.Range(0, npc.NpcDialogues.Count);
        StartCoroutine(StartTyping(npc.NpcDialogues[randText]));

    }

    public void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
    }
}

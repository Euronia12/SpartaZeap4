using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using AnimatorController = UnityEditor.Animations.AnimatorController;

public class PlayerJobTransition : MonoBehaviour
{
    [SerializeField]
    private PlayerJobSO[] plyerJobInfoes;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField]
    private Image selectedCharaterImg;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void ChangedCharacter(int JobNum)
    {
        switch ((Define.ePlayerJob)JobNum) 
        { 
            case Define.ePlayerJob.Mage:
                ChangedSprite(plyerJobInfoes[0]);
                break;
            case Define.ePlayerJob.Knight:
                ChangedSprite(plyerJobInfoes[1]);
                break;
            case Define.ePlayerJob.Assassin:
                ChangedSprite(plyerJobInfoes[2]);
                break;
            default:
                Debug.Log("직업선택 번호 오류");
                break;
        }
    }

    private void ChangedSprite(PlayerJobSO playerSO)
    {
        spriteRenderer.sprite = playerSO.sprite;
        animator.runtimeAnimatorController = playerSO.animator;
        selectedCharaterImg.sprite = playerSO.sprite;
        GameManager.Instance.isPlaying = true;
    }
}

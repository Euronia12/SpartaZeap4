using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerJob", menuName = "Player/Job/Default", order = 0)]
public class PlayerJobSO : ScriptableObject
{
    [SerializeField]
    private int JobNum;
    [SerializeField]
    private Define.ePlayerJob Job;
    public int Speed = 5;
    public AnimatorOverrideController animator;
    public Sprite sprite;

}

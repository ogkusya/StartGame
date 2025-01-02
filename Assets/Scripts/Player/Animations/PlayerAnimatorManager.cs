using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager
{
    private Animator _animator;
    private Dictionary<PlayerAnimationParameter, int> hashStorage = new Dictionary<PlayerAnimationParameter, int>();

    public Animator Animator => _animator;

    public PlayerAnimatorManager(Animator animator)
    {
        _animator = animator;
        foreach (PlayerAnimationParameter caType in Enum.GetValues(typeof(PlayerAnimationParameter)))
        {
            hashStorage.Add(caType, Animator.StringToHash(caType.ToString()));
        }
    }

    public void SetBool(PlayerAnimationParameter animationType, bool value)
    {
        _animator.SetBool(hashStorage[animationType], value);
    }

    public void SetFloat(PlayerAnimationParameter animationType, float value)
    {
        _animator.SetFloat(hashStorage[animationType], value);
    }

    public void SetPlay(PlayerAnimationParameter characterAnimationType)
    {
        _animator.Play((hashStorage[characterAnimationType]));
    }

    public void SetTrigger(PlayerAnimationParameter characterAnimationType)
    {
        _animator.SetTrigger((hashStorage[characterAnimationType]));
    }

    public void ResetTrigger(PlayerAnimationParameter characterAnimationType)
    {
        _animator.ResetTrigger((hashStorage[characterAnimationType]));
    }

    public bool IsAnimationPlay(string animationStateName)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(animationStateName);
    }

    public float NormalizedAnimationPlayTime()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}

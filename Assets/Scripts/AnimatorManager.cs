using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;
    
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }
    public void PlayAnimation(AnimationType type, float currentSpeedFactor = 1f)
    {
        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.triggerName);
                animator.speed = animation.speedAnimation * currentSpeedFactor;
                break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            PlayAnimation(AnimationType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayAnimation(AnimationType.DEAD);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayAnimation(AnimationType.IDLE);
        }
    }
}

[System.Serializable]

public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string triggerName;
    public float speedAnimation = 1f;
}

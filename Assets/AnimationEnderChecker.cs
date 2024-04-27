using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventEnder : MonoBehaviour
{
    public static bool isAnimationEnded = false;

    public void AnimationEndEvent()
    {
        isAnimationEnded = true;
    }
    public void AnimationStartEvent()
    {
        isAnimationEnded = false;
    }
}

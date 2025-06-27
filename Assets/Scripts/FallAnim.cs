    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAnimation : MonoBehaviour
{
    public Animator fallAnimator;

    public void OnFallStart()
    {
        Debug.Log("Fall Ω√¿€");
    }

    public void OnFallEnd()
    {
        Debug.Log("Fall ≥°");
        fallAnimator.Play("Idle");
    }
}

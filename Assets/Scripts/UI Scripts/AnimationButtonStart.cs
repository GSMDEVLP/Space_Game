using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButtonStart : MonoBehaviour
{
    private void Awake()
    {
        Animation anim = GetComponent<Animation>();
        anim.Play();
    }
}

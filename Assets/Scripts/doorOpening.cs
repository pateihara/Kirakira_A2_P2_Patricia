using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpening : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private AudioSource earthquakeSoundsEffects;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Sound()
    {
        earthquakeSoundsEffects.Play();

    }
}

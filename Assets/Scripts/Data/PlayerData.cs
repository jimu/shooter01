using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Shooter/Player")]

public class PlayerData : ScriptableObject
{
    [Tooltip("Starting Lives")]
    public int lives = 2;

    [Tooltip("Starting Health")]
    public int health = 6;

    [Tooltip("Starting Speed")]
    public int speed = 10;

    [Tooltip("Sound effect when hurt")]
    public AudioClip hurtSFX;

    [Tooltip("Particle effect when hurt")]
    public ParticleSystem hurtVFX;

    [Tooltip("Sound effect when killed")]
    public AudioClip destroyedSFX;

    [Tooltip("Particle effect when killed")]
    public ParticleSystem destroyedVFX;

    [Tooltip("Ambient noise")]
    public AudioClip ambientSFX;

}

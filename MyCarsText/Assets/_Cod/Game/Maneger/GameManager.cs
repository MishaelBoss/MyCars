using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // оптимизация
    [SerializeField] private int solverItterations = 7;
    private Rigidbody rb;

    [Header("Music")]
    public AudioSource clip1;

    private void Awake() 
    {
        rb.solverIterations = solverItterations;
    }

    private void Start()
    {
        clip1.Stop();
    }

}

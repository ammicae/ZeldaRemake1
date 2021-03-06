﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
        gameMaster = GameObject.FindObjectOfType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }

    /////////////////////////////////
    //         Lives Script        //
    /////////////////////////////////

    // Sets number of lives in Unity
    public int enemyLives = 1;

    // Set rupee as loot
    public GameObject lootDrop;

    // Spawn death particle system
    public GameObject enemyParticle;

    void lifeCounter()
    {
        if (enemyLives <= 0)
        {
            Destroy(this.gameObject);
            GameObject a = Instantiate(lootDrop, transform.position, lootDrop.transform.rotation) as GameObject;
            GameObject b = Instantiate(enemyParticle, transform.position, Quaternion.identity) as GameObject;
            SceneManager.LoadScene(2);
        }
    }

    /////////////////////////////////
    // 2D Collider Triggers Script //
    /////////////////////////////////

    // Reference AudioManager script
    private AudioManager audioManager;
    private GameMaster gameMaster;

    public string enemyHitSoundName;
    public string playerHitSoundName;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enemy hit");
        if (other.gameObject.CompareTag("playerAttack"))
        {
            Debug.Log("enemy damage taken");
            enemyLives--;
            lifeCounter();
            audioManager.PlaySound(enemyHitSoundName);
        }

        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("player damage taken");
            gameMaster.lives--;
            audioManager.PlaySound(playerHitSoundName);
        }
    }

    private Animator animator;

    private Vector2 change;

    private void changeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        animator.SetFloat("xaxis", direction.x);
        animator.SetFloat("yaxis", direction.y);
    }
}

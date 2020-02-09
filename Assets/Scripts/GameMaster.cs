﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{   
    /////////////////////////////////
    //   Start & Update Script     //
    /////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        // Set rupee count to 0
        rupeeCount = 0;
        RupeeCounter();
        
        // Set life hearts to visible
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);

        // Apply audio manager
        audioManager = AudioManager.instance;

        audioManager.PlaySound(bgmSoundName);

        // Set gameOver = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerMovement Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        LifeCounter();
        //PlayerAttack();
    }

    /////////////////////////////////
    //    PlayerMovement Script    //
    /////////////////////////////////
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Directions for animation
        /*if ((Input.GetKey("d")) || Input.GetKey("right")) 
        {
            animator.Play("Player_side");

            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetKey("a") || Input.GetKey("left")) 
        {
            animator.Play("Player_side");

            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey("w") || Input.GetKey("up")) 
        {
            animator.Play("Player_back");
        }

        if (Input.GetKey("s") || Input.GetKey("down")) 
        {
            animator.Play("Player_front");
        }

        PlayerAttack();*/
    }

    /////////////////////////////////
    //    PlayerAttack Script      //
    /////////////////////////////////

    bool isAttacking = false;

    /*Animator animator;
    SpriteRenderer spriteRenderer;

    void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            animator.Play("Melee_attack");
        }

        if (Input.GetButtonDown("Fire2") && !isAttacking)
        {
            isAttacking = true;
            animator.Play("Ranged_attack");
        }
    }*/

    /////////////////////////////////
    //         Lives Script        //
    /////////////////////////////////

    // Sets number of lives and lives sprites in Unity
    public int lives = 3;
    public GameObject life1, life2, life3;

    void LifeCounter()
    {
        // Turn on and off life hearts
        switch (lives)
        {
            case 3:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 2:
                life1.SetActive(false);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 1:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(true);
                break;
            case 0:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
        }

        if (lives <= 0)
        {
            EndGame();
        }
    }

    /////////////////////////////////
    //        Rupee Counter        //
    /////////////////////////////////

    // Accepts the Text UI object in Unity
    public Text countText;

    // Holds the number of Rupees
    private int rupeeCount;

    void RupeeCounter()
    {
        countText.text = "X" + rupeeCount.ToString();
    }

    /////////////////////////////////
    //        Camera Script        //
    /////////////////////////////////

    // fieldroom1ToCave
    void CameraMove1()
    {
        transform.position = new Vector2(-23.0f, 6.0f);
        Camera.main.transform.position = new Vector3(-23.0f, 11.15f, -10f);
    }

    // caveToFieldroom1
    void CameraMove2()
    {
        transform.position = new Vector2(2.0f, 0.0f);
        Camera.main.transform.position = new Vector3(0.0f, 0.0f, -10f);
    }

    // fieldroom1ToFieldroom2
    void CameraMove3()
    {
        transform.position = new Vector2(-13.0f, -3.83f);
        Camera.main.transform.position = new Vector3(-22.0f, 0.0f, -10f);
    }

    // fieldroom2ToFieldroom1
    void CameraMove4()
    {
        transform.position = new Vector2(-10.13f, -3.57f);
        Camera.main.transform.position = new Vector3(0.0f, 0.0f, -10f);
    }

    // fieldroom1ToFieldroom3
    void CameraMove5()
    {
        transform.position = new Vector2(2.0f, -8.0f);
        Camera.main.transform.position = new Vector3(0.0f, -10.08f, -10f);
    }

    // fieldroom3ToFieldroom1
    void CameraMove6()
    {
        transform.position = new Vector2(2.0f, -5.5f);
        Camera.main.transform.position = new Vector3(0.0f, 0.0f, -10f);
    }

    // fieldroom1ToDungeonroom1
    void CameraMove7()
    {
        transform.position = new Vector2(0.28f, 6.31f);
        Camera.main.transform.position = new Vector3(-0.21f, 10.97f, -10f);
    }

    // dungeonroom1ToFieldroom1
    void CameraMove8()
    {
        transform.position = new Vector2(-5.53f, -1.42f);
        Camera.main.transform.position = new Vector3(0.0f, 0.0f, -10f);
    }

    // dungeonroom1ToDungeonroom2
    void CameraMove9()
    {
        transform.position = new Vector2(12.48f, 8.8f);
        Camera.main.transform.position = new Vector3(21.73f, 11.15f, -10f);
    }

    // dungeonroom2ToDungeonroom1
    void CameraMove10()
    {
        transform.position = new Vector2(9.0f, 8.8f);
        Camera.main.transform.position = new Vector3(-0.21f, 10.97f, -10f);
    }

    // dungeonroom2ToBossroom
    void CameraMove11()
    {
        transform.position = new Vector2(22.2f, 16.13f);
        Camera.main.transform.position = new Vector3(21.73f, 20.82f, -10f);
    }

    // bossroomToDungeonroom2
    void CameraMove12()
    {
        transform.position = new Vector2(22.2f, 12.5f);
        Camera.main.transform.position = new Vector3(21.73f, 11.15f, -10f);
    }

    // fieldroom1ToTree
    void CameraMove13()
    {
        transform.position = new Vector2(21.85f, -4.46f);
        Camera.main.transform.position = new Vector3(21.93f, 0.0f, -10f);
    }

    // treeToFieldroom1
    void CameraMove14()
    {
        transform.position = new Vector2(7.61f, 1.05f);
        Camera.main.transform.position = new Vector3(0.0f, 0.0f, -10f);
    }

    /////////////////////////////////
    //    Sound Effects Script     //
    /////////////////////////////////

    // Reference AudioManager script
    private AudioManager audioManager;

    // Sound names
    public string bgmSoundName;
    public string playerHitSoundName;
    public string rangedSoundName;
    public string meleeSoundName;
    public string pickupSoundName;
    public string doorSoundName;
    public string lockedSoundName;

    /////////////////////////////////
    // 2D Collider Triggers Script //
    /////////////////////////////////

    // Inventory Bools
    public bool keyHeld = false;
    public bool swordHeld = false;

    // Inventory Numbers
    public Text haveKey;
    public GameObject haveSword;

    // Note: Require 'Is Trigger'
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("player damage taken");
            lives--;
            audioManager.PlaySound(playerHitSoundName);
        }

        if (other.gameObject.CompareTag("heart"))
        {
            Debug.Log("heart added");
            lives++;
            other.gameObject.SetActive(false);
            audioManager.PlaySound(pickupSoundName);
        }

        if (other.gameObject.CompareTag("rupee"))
        {
            Debug.Log("rupee added");
            rupeeCount++;
            other.gameObject.SetActive(false);
            RupeeCounter();
            audioManager.PlaySound(pickupSoundName);
        }
        
        if (other.gameObject.CompareTag("key"))
        {
            if (rupeeCount >= 10)
            {
                Debug.Log("key added");
                keyHeld = true;
                other.gameObject.SetActive(false);
                haveKey.text = "X1";
                Debug.Log("money spent");
                rupeeCount = rupeeCount - 10;
                RupeeCounter();
                audioManager.PlaySound(pickupSoundName);
            }
            else
            {
                Debug.Log("not enough rupees");
            }
        }

        if (other.gameObject.CompareTag("sword"))
        {
            Debug.Log("sword added");
            swordHeld = true;
            other.gameObject.SetActive(false);
            haveSword.gameObject.SetActive(true);
            audioManager.PlaySound(pickupSoundName);
        }

        // Doors
        
        if (other.gameObject.CompareTag("fieldroom1ToCave"))
        {
            Debug.Log("gone thru door");
            CameraMove1();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("caveToFieldroom1"))
        {
            Debug.Log("gone thru door");
            CameraMove2();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("fieldroom1ToFieldroom2"))
        {
            Debug.Log("gone thru door");
            CameraMove3();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("fieldroom2ToFieldroom1"))
        {
            Debug.Log("gone thru door");
            CameraMove4();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("fieldroom1ToFieldroom3"))
        {
            Debug.Log("gone thru door");
            CameraMove5();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("fieldroom3ToFieldroom1"))
        {
            Debug.Log("gone thru door");
            CameraMove6();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("fieldroom1ToDungeonroom1"))
        {
            if (keyHeld == true)
            {
                Debug.Log("gone thru door");
                CameraMove7();
                audioManager.PlaySound(doorSoundName);
            }
            else
            {
                Debug.Log("key not held");
                CameraMove8();
                audioManager.PlaySound(lockedSoundName);
            }
        }

        if (other.gameObject.CompareTag("dungeonroom1ToFieldroom1"))
        {
            Debug.Log("gone thru door");
            CameraMove8();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("dungeonroom1ToDungeonroom2"))
        {
            Debug.Log("gone thru door");
            CameraMove9();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("dungeonroom2ToDungeonroom1"))
        {
            Debug.Log("gone thru door");
            CameraMove10();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("dungeonroom2ToBossroom"))
        {
            Debug.Log("gone thru door");
            CameraMove11();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("bossroomToDungeonroom2"))
        {
            Debug.Log("gone thru door");
            CameraMove12();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("fieldroom1ToTree"))
        {
            Debug.Log("gone thru door");
            CameraMove13();
            audioManager.PlaySound(doorSoundName);
        }

        if (other.gameObject.CompareTag("treeToFieldroom1"))
        {
            Debug.Log("gone thru door");
            CameraMove14();
            audioManager.PlaySound(doorSoundName);
        }
    }

    /////////////////////////////////
    //      Game Over Script       //
    /////////////////////////////////

    bool gameOver = false;

    private PauseManager pauseManager;

    public string loseSoundName;

    public void EndGame()
    {
        if (lives <= 0 && gameOver == false)
        {
            gameOver = true;
            Debug.Log("EndGame Run");
            SceneManager.LoadScene(3);
        }
    }
}

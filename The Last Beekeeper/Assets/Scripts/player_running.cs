using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_running : MonoBehaviour
{
    public float walkingSpeed, runningSpeed, baseRunningSpeed, baseWalkingSpeed;
    public float walkSpeedBoosts, runSpeedBoosts;
    float walkSpeedBoostPerBoost, runSpeedBoostPerBoost;
    PauseManager pause_m;
    Rigidbody2D rb2;
    public bool movementOverride, canInteract;
    // Start is called before the first frame update
    void Start()
    {
        pause_m = GameObject.Find("Pause Manager").GetComponent<PauseManager>();

        walkingSpeed = baseWalkingSpeed;
        runningSpeed = baseRunningSpeed;

        walkSpeedBoostPerBoost = baseWalkingSpeed * 0.25f;
        runSpeedBoostPerBoost = baseRunningSpeed * 0.25f;

        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause_m.IsPaused)
        {
            if (!movementOverride)
            {
                float moveSpeed = walkingSpeed;
                Vector3 move = Vector3.zero;

                //Here we check to see if the player is pressing Left Shift. Movement will be different between walking and sprinting.
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed = runningSpeed;

                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = transform.position.z;
                    Vector3 mosPos = mousePos;
                    mosPos.x = mousePos.x - transform.position.x;
                    mosPos.y = mousePos.y - transform.position.y;
                    float angle = Mathf.Atan2(mosPos.y, mosPos.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                    if (Vector3.Distance(transform.position, mousePos) <= 0.25f)
                    {
                        moveSpeed = 0;
                    }

                    if (Input.GetAxis("Vertical") < 0)
                    {
                        moveSpeed = -walkingSpeed;
                    }

                    move += transform.up * Mathf.Abs(Input.GetAxis("Vertical")) * moveSpeed;
                }
                else
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.x = mousePos.x - transform.position.x;
                    mousePos.y = mousePos.y - transform.position.y;
                    float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                    move = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
                }

                if (move.magnitude > moveSpeed)
                {
                    move.Normalize();
                    move *= moveSpeed;
                }
                rb2.velocity = move;
            }
            else
            {
                rb2.velocity = Vector2.zero;
                Debug.Log("Overriding position");
                if (Input.GetButtonDown("Jump"))
                {
                    transform.SetParent(null);
                    movementOverride = false;
                }
            }
        }
    }

    public void RunWalkBoost()
    {
        walkSpeedBoosts++;
        walkingSpeed = baseWalkingSpeed;
        float boostQuantity = walkSpeedBoostPerBoost * walkSpeedBoosts;
        walkingSpeed += boostQuantity;
    }
}

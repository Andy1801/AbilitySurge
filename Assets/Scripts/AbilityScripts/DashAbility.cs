using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: The dash ability seems to stop you mid air if you are not holding a certain direction
//TODO: Think about adding directional movement
//TODO: Move Rendering logic to the ability rotator rather 
public class DashAbility : IAbilities
{
    private bool dashing;

    private Timer timer;
    private float dashTime = 0.15f;

    private GameObject dashClone;
    private Rigidbody2D rigidbody2D;
    private PlayerMovement playerMovement;
    private Renderer playerRenderer;
    private Grounded grounded;

    public bool actionCondition(GameObject player)
    {


        if (timer == null)
            timer = new Timer(dashTime);

        if (Input.GetKeyDown(KeyCode.Space) && !dashing)
        {
            dashing = true;
            timer.StartTimer();
            return dashing;
        }
        return false;
    }

    public void action(GameObject player)
    {
        grounded = player.GetComponentInChildren<Grounded>();
        rigidbody2D = player.GetComponent<Rigidbody2D>();
        playerMovement = player.GetComponent<PlayerMovement>();

        MonoBehaviour.Instantiate(playerMovement.dashEffect, rigidbody2D.position, Quaternion.identity);

        rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        playerMovement.playerSpeed = playerMovement.playerSpeed + 40;
    }

    public void actionCleanUp(GameObject player, bool strictCleanup)
    {
        if (dashing)
        {
            if (timer.getTimerStatus() || strictCleanup)
            {
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                playerMovement.playerSpeed = playerMovement.playerSpeed - 40;
                dashing = false;
            }
        }
        if (strictCleanup)
        {
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
            foreach (GameObject cl in clones)
            {
                MonoBehaviour.Destroy(cl);
            }
        }
    }
}

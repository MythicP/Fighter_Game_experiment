using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterControl : MonoBehaviour
{
    // Start is called before the first frame update

    /*
     * Attack List
     * Light, Meduim, Heavy, Universal
     * Throw (light + Universal or other button) - counter with same buttons with in x frame window
     * Ability 1
     * Ability 2
     * Ability 3
     * Ability 4
     * Ultimate
     * How Do you want to do this
     * 
     *  To play from frame x without having to worry about layers 
        Animator.Play("name", 0, x);
    */

    private bool attacking = false;
    private bool crouch = false;
    private bool walkingBackwards = false;
    private bool walkingForwards = false;
    private bool jumping = false;
    private bool falling = false;
    private int hitStun = -1;
    private int blockStun = -1;

    private int startFrame = 0;
    private int waitFrame = 0;
    public Animator ani;
    public Animator ani_Boxes;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (startFrame + waitFrame <= Time.frameCount)
        {
            attacking = false;
            string temp = "";
            if (Input.GetKey(KeyCode.Mouse0))
            {
                temp += "_Light_";
                //set frames to wait for attion to complete
                //in which no other attack can be made
                // 5 , 3, 13 
                startFrame = Time.frameCount;
                waitFrame = 29;
                ani.Play("Overhead");
                ani_Boxes.Play("Overhead");
                attacking = true;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                temp += "_Heavy_";
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                temp += "Ability 1";
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                temp += "Ability 2";
            }
            if (Input.GetKey(KeyCode.W))
            {
                temp += "_Up_";
            }
            if (Input.GetKey(KeyCode.S))
            {
                temp += "_Down_";
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                walkingForwards = false;
                walkingBackwards = false;
                if (!crouch)
                    ani.Play("StandIdle");
                else
                    ani.Play("CrouchIdle");
            }
            else if (Input.GetKey(KeyCode.A))
            {
                temp += "_Left_";
                if (!walkingBackwards && !jumping)
                {
                    ani.Play("WalkBackward");
                    walkingBackwards = true;
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                temp += "_Right_";
                if (!walkingForwards && !jumping)
                {
                    ani.Play("WalkForward");
                    walkingForwards = true;
                }
            }
            if (!temp.Equals(""))
            {
                Debug.Log("Frame" + Time.frameCount + temp);
            }
            else if (temp.Equals(""))
            {
                if (crouch)
                {
                    crouch = false;
                    ani.Play("ToStand");
                }
                if ((walkingForwards || walkingBackwards) && !jumping)
                {
                    walkingForwards = false;
                    walkingBackwards = false;
                    ani.Play("StandIdle");
                }
            }
        }
    }

    public void SetJumping(bool i)
    {
        jumping = i;
    }

    public bool GetJumping()
    {
        return jumping;
    }

    public bool GetAttacking()
    {
        return attacking;
    }

    public void JumpAni()
    {
        ani.Play("Kick");
    }

    public void CrouchingAni()
    {
        if (!crouch)
        {
            ani.Play("ToCrouch");
            crouch = true;
        }
        else
        {
            ani.Play("CrouchIdle");
            crouch = true;
        } 
    }
    public void UnCrouchingAni()
    {
        if(crouch)
        {
            crouch = false;
            ani.Play("ToStand");
        }
    }

    public bool GetCrouch()
    {
        return crouch;
    }

    public void playStandIdle()
    {
        ani.Play("StandIdle");
    }



}

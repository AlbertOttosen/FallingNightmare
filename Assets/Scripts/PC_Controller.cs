using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Controller : MonoBehaviour
{
    public Animator CharacterAnimator;
    public Transform phone;
    public PhoneScript phoneScript;
    public float Speed;
    public float maxDistPhone;

    //inputs
    float Horizontal;
    float Vertical;
    bool TryInteract;

    bool m_FacingRight = true;
    public bool canInteract = false;
    public bool gameEnded = false;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        TryInteract = Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {   
        if (gameEnded) {
            transform.position = transform.position - Vector3.up * 1;
        } else {
            canInteract = Vector2.Distance(transform.position, phone.position) < maxDistPhone && phoneScript.phoneAnimator.GetBool("Ringing");
            // Move the player
            transform.position = transform.position + new Vector3(Horizontal * Speed, Vertical * Speed, 0.0f);
            Flip();
            Interact();    
        }
    }

	void Flip()
	{
        if ((Horizontal > 0 && !m_FacingRight) || 
            (Horizontal < 0 && m_FacingRight)) {
                // Switch the way the player is labelled as facing.
                m_FacingRight = !m_FacingRight;

                // Multiply the player's x local scale by -1.
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
        }
	}

    void Interact() {
        if (TryInteract && canInteract) {
            //CharacterAnimator.SetBool("Phoning", true);
            phoneScript.PickUp();
        }
    }

    public void GetItem(string ItemName) {
        try {
            inventory[ItemName] = inventory[ItemName] + 1;
        }
        catch {
            inventory.Add(ItemName, 1);
        }
    }
}
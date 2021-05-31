using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float Speed = 0.1f;
    public string ItemName;
    public float pickUpRange;
    public Transform playerTransform;
    public PC_Controller player;

    void FixedUpdate()
    {
        transform.position += Vector3.up * Speed;
        if (Vector2.Distance(transform.position, playerTransform.position) < pickUpRange) {
            player.GetItem(ItemName);
            Destroy(gameObject);
        } else if (transform.position.y > 20) {
            Destroy(gameObject);
        }
    }

    public void SetValues(float PickUpRange, Transform PlayerTransform, PC_Controller Player) {
        pickUpRange = PickUpRange;
        playerTransform = PlayerTransform;
        player = Player;
    }
}

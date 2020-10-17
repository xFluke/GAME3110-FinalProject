using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public enum ItemInHand {
        EMPTY,
        RAW_STEAK,
        COOKED_STEAK
    };

    public float speed = 6.0f;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;

    //private bool holdingFood = false;

    //public bool HoldingFood { get { return holdingFood; } set { holdingFood = value; } }
    public ItemInHand itemInHand = ItemInHand.EMPTY;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        Move();

    }

    private void Move() {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}

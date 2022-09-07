using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 200f;
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float slowSpeed = 10f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private GameObject Camera;

    private void Update()
    {
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void LateUpdate() {
        Camera.transform.position = this.transform.position + new Vector3(0,0,-10);
    }

   private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
        }
        else if(other.tag == "Slower")
        {
            moveSpeed = slowSpeed;
        }
   }
}

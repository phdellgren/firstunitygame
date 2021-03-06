using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpPower;
    public float Speed;
    public LayerMask Mask;
    private Rigidbody2D RB;
    private float _startJumpPower;
    private float _startSpeed;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        _startJumpPower = JumpPower;
        _startSpeed = Speed;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2(0, RB.velocity.y);

        float DistanceToGround = GetComponent<Collider2D>().bounds.extents.y;

       _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, DistanceToGround + 0.5f, Mask);

       

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -Speed*Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = Speed*Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
        }

        RB.velocity = movement;

    }


    public void JumpPowerUp(float seconds, float Power)
    {
        StartCoroutine(RunJumpPowerup(seconds, Power));
    }

    IEnumerator RunJumpPowerup(float seconds, float Power)
    {
        JumpPower = Power;
        yield return new WaitForSeconds(seconds);
        JumpPower = _startJumpPower;
    }

    public void SpeedPowerup(float seconds, float speedPower)
    {
        StartCoroutine(RunSpeedBoost(seconds, speedPower));
    }

    IEnumerator RunSpeedBoost (float seconds, float speedPower)
    {
        Speed = speedPower;
        yield return new WaitForSeconds(seconds);
        Speed = _startSpeed;
    }


}

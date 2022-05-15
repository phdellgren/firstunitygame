using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    public float SpeedDuration = 3;
    public float SpeedPowerAmout = 800;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            collision.GetComponent<PlayerMovement>().SpeedPowerup(SpeedDuration, SpeedPowerAmout);
            Destroy(gameObject);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public new Rigidbody rigidbody;
    private int availableCoins = 50;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.useGravity = false;
        }

        if (!collision.transform.CompareTag("Terrain") && collision.transform.CompareTag("Player")) 
        {
            collision.transform.GetComponentInParent<UIText>().Score++;
            gameObject.SetActive(false);
            availableCoins--;

            if (availableCoins <= 0)
            {
                CoinPool.CoinSpawn();
            }
        }

    }
}

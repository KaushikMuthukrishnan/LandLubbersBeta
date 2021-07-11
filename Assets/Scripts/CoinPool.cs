using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public GameObject coin;
    public Transform coinPoolParent;
    private static GameObject[] pool;
    private void Awake()
    {
        pool = new GameObject[50];
        GameObject temp;
        for (int i = 0; i < 50; i++)
        {
            temp = Instantiate(coin, Vector3.zero, Quaternion.identity, coinPoolParent);
            temp.SetActive(false);
            pool[i] = temp;
        }
        CoinSpawn();
    }

    public static void CoinSpawn()
    {
        foreach(GameObject coin in pool)
        {
            coin.transform.position = new Vector3((Random.value - 0.5f) * 800, 50, (Random.value - 0.5f) * 800);
            coin.GetComponent<Rigidbody>().AddForce(Physics.gravity);
            coin.SetActive(true);
            //TODO add a checker to see if coin is above an scenery, relocate it if it is
        }
    }
}

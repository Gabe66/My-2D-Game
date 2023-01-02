using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] int value = 1;

    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            if(gameObject.tag == "Coin")
            {
                _gameManager.UpdateCoinCount(value);
            }
            else if(gameObject.tag == "Diamond")
            {
                _gameManager.UpdateDiamondCount(value);
            }

            Debug.Log("Player collected a " + gameObject.name);
            Destroy(this.gameObject);
        }
    }
}

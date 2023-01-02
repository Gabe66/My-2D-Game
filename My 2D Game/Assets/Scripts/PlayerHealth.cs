using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _healthAmount = 3;
    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -50)
        {
            _gameManager.ReloadScene();
        }
    }

    public void UpdatePlayerHealth()
    {
        _healthAmount--;
        Debug.Log("Player health is: " + _healthAmount.ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _coinCount = 0;
    [SerializeField] int _diamondCount = 0;
    [SerializeField] Text _coinCountText;
    [SerializeField] Text _diamondCountText;

    // Start is called before the first frame update
    void Start()
    {
        _coinCountText.text = _coinCount.ToString();
        _diamondCountText.text = _diamondCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinCount(int amount)
    {
        _coinCount += amount;
        _coinCountText.text = _coinCount.ToString();
    }

    public void UpdateDiamondCount(int amount)
    {
        _diamondCount -= amount;
        _diamondCountText.text = _diamondCount.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

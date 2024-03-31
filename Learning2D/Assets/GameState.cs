using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Sprite start;
    public Sprite over;
    public Sprite clear;

    private Image showState;

    // Start is called before the first frame update
    private void Start()
    {
        showState = GetComponent<Image>();
    }

    void GameClear()
    {
        showState.sprite = clear;
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}

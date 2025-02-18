using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement3D myPlayer;
    public int score;

    void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovement3D>();
    }

    // Update is called once per frame
    void Update()
    {
        score = myPlayer.score;
    }


}

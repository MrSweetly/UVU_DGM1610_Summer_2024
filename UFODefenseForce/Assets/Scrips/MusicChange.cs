using System;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioSource levelSong;
    public AudioSource deathSong;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void Update()
    {
        if (gameManager.isGameOver) {
            DeathMusic(); }
        if (!gameManager.isGameOver) {
            LevelMusic(); }
    }

    void LevelMusic()
    {
        levelSong.Play();
        deathSong.Stop();
    }

    void DeathMusic()
    {
        deathSong.Play();
        levelSong.Stop();
    }
}

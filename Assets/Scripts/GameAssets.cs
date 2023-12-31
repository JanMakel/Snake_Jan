using System;
using UnityEngine;
using TMPro;

public class GameAssets : MonoBehaviour
{
    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
    
    public static GameAssets Instance { get; private set; }

    public Sprite snakeHeadSprite;
    public Sprite snakeBodySprite;
    public Sprite appleSprite;
    public Sprite cakeSprite;
    public Sprite pizzaSprite;

    public Sprite[] foodSprite = new Sprite[] { };

    public FoodSO[] foodSOArray;

    

    public SoundAudioClip[] soundAudioClipsArray;

    private void Awake()
    {
        // Singleton
        if (Instance != null)
        {
            Debug.LogError("There is more than one Instance");
        }

        Instance = this;
    }
}

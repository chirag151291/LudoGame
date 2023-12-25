using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
public class AddressablesManager : MonoBehaviour
{
    [SerializeField]
    private AssetReferenceSprite playerImage;

    [SerializeField]
    private AssetReferenceSprite dice1Image, dice2Image, dice3Image, dice4Image, dice5Image, dice6Image;

    [SerializeField]
    private GameObject player,dice;
    private Sprite playerSprite;
    private Sprite dice1Sprite, dice2Sprite, dice3Sprite, dice4Sprite, dice5Sprite, dice6Sprite;

    void Start()
    {
        Addressables.InitializeAsync().Completed += AddressablesManager_Completed;
    }

    private void AddressablesManager_Completed(AsyncOperationHandle<IResourceLocator> obj)
    {
        playerImage.LoadAssetAsync<Sprite>().Completed+= PlayerImageLoaded;
        dice1Image.LoadAssetAsync<Sprite>().Completed += Dice1ImageLoaded;
        dice2Image.LoadAssetAsync<Sprite>().Completed += Dice2ImageLoaded;
        dice3Image.LoadAssetAsync<Sprite>().Completed += Dice3ImageLoaded;
        dice4Image.LoadAssetAsync<Sprite>().Completed += Dice4ImageLoaded;
        dice5Image.LoadAssetAsync<Sprite>().Completed += Dice5ImageLoaded;
        dice6Image.LoadAssetAsync<Sprite>().Completed += Dice6ImageLoaded;

        
    }

    // Get the 6 number dice image and add to diceList
    private void Dice6ImageLoaded(AsyncOperationHandle<Sprite> obj)
    {
        dice6Sprite = dice6Image.Asset as Sprite;
        dice.GetComponent<Dice>().diceSides[5] = dice6Sprite;
    }

    // Get the 5 number dice image and add to diceList
    private void Dice5ImageLoaded(AsyncOperationHandle<Sprite> obj)
    {
        dice5Sprite = dice5Image.Asset as Sprite;
        dice.GetComponent<Dice>().diceSides[4] = dice5Sprite;
    }

    // Get the 4 number dice image and add to diceList
    private void Dice4ImageLoaded(AsyncOperationHandle<Sprite> obj)
    {
        dice4Sprite = dice4Image.Asset as Sprite;
        dice.GetComponent<Dice>().diceSides[3] = dice4Sprite;
    }

    // Get the 3 number dice image and add to diceList
    private void Dice3ImageLoaded(AsyncOperationHandle<Sprite> obj)
    {
        dice3Sprite = dice3Image.Asset as Sprite;
        dice.GetComponent<Dice>().diceSides[2] = dice3Sprite;
    }

    // Get the 2 number dice image and add to diceList
    private void Dice2ImageLoaded(AsyncOperationHandle<Sprite> obj)
    {
        dice2Sprite = dice2Image.Asset as Sprite;
        dice.GetComponent<Dice>().diceSides[1] = dice2Sprite;
    }

    // Get the 1 number dice image and add to diceList
    private void Dice1ImageLoaded(AsyncOperationHandle<Sprite> obj)
    {
        dice1Sprite = dice1Image.Asset as Sprite;
        dice.GetComponent<Dice>().diceSides[0] = dice1Sprite;
    }

    // Get player image and set into the player sprite image 
    private void PlayerImageLoaded(AsyncOperationHandle<Sprite> obj)
    {
        playerSprite = playerImage.Asset as Sprite;
        player.GetComponent<SpriteRenderer>().sprite = playerSprite;
    }

    
}

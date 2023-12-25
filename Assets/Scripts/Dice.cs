using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public class Dice : MonoBehaviour {

    [HideInInspector]
    public Sprite[] diceSides;
   
    private SpriteRenderer rend;
    public GameObject player;
    private bool coroutineAllowed = true;
    public int finalNo;

    IEnumerator  Start () {
        diceSides = new Sprite[6];
        rend = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(1);
        rend.sprite = diceSides[5];
	}

    // Roll a Dice to here 
    public void RollDice()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
        StartCoroutine(GetRequest("https://www.randomnumberapi.com/api/v1.0/random?min=1&max=7&count=1"));
    }

    //Roll a Dice and change dice images random
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        randomDiceSide = finalNo;
        rend.sprite = diceSides[randomDiceSide-1];
        GameControl.diceSideThrown = randomDiceSide;
        coroutineAllowed = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Get one Dice number API call
    IEnumerator GetRequest(string _diceRollApi)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(_diceRollApi))
        {
            
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    string sp = webRequest.downloadHandler.text;
                    string[] pages = sp.Split(']');  // Splite a number
                    string ss = pages[0];
                    string[] pages1 = ss.Split('[');
                    string ss1 = pages1[1];
                    finalNo = int.Parse(ss1);  // Get final number
                    break;
            }
        }
    }
}

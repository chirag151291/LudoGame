using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject player;

    public static int diceSideThrown = 0;
    public static int playerStartWaypoint = 0;
    public Text winsText;

    public static bool gameOver = false;

    void Start () {

        player = GameObject.Find("Player");        
        player.GetComponent<FollowThePath>().moveAllowed = false;
        winsText.gameObject.SetActive(false);
    }

    // stop to move when final number of dice
    void Update()
    {
        if (player.GetComponent<FollowThePath>().waypointIndex > 
            playerStartWaypoint + diceSideThrown)
        {
            player.GetComponent<FollowThePath>().moveAllowed = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
            playerStartWaypoint = player.GetComponent<FollowThePath>().waypointIndex - 1;
        }
       
        if (player.GetComponent<FollowThePath>().waypointIndex == 
            player.GetComponent<FollowThePath>().waypoints.Length)
        {
            winsText.gameObject.SetActive(true);
            gameOver = true;
        }

        
    }

    // allow to player move start
    public static void MovePlayer()
    {
        player.GetComponent<FollowThePath>().moveAllowed = true;        
    }
}

using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;
    
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private Vector2 initialPos;

    [HideInInspector]
    public int waypointIndex = 0;

    
    public bool isReset = false;

    public bool moveAllowed = false;

	private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
        initialPos = transform.position;

    }
	
	private void Update () {
        if (moveAllowed)
            Move();
        if (isReset)
            ResetPos();

    }

    // Move the player 
    private void OnMouseDown()
    {
        GameControl.MovePlayer();
    }

    public void ResetButtionClick()
    {
        isReset = true;
    }

    // player move to start here 
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    // player position reset  
    private void ResetPos()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            initialPos,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[0].transform.position)
            {                
                waypointIndex = 0;
                GameControl.diceSideThrown = 0;
                GameControl.playerStartWaypoint = 0;
                isReset = false;
            }
        }
    }
}

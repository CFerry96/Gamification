using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class movementScript : MonoBehaviour {

    int activeWaypoint;
    public GameObject[] waypoints;
    
    Vector3 currentWaypointPos;
    Vector3 playerPos;
    public float playerSpeed;
    float theta;
    public float headBobMultiplier;
    float playerBobY;
    public float headBobCycleSpeed;
    WalkingPauseMenu pauseMenu;
    WalkingPauseMenu settingsMenu;


    // Use this for initialization
    void Start () {       
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").OrderBy(go => go.name).ToArray();
        pauseMenu = this.gameObject.GetComponent<WalkingPauseMenu>();
        settingsMenu = this.gameObject.GetComponent<WalkingPauseMenu>();
	}

    // Update is called once per frame
    void Update () {
        if (pauseMenu.Pause == false && settingsMenu == false)
        { 
            theta += Time.deltaTime * headBobCycleSpeed;
            playerBobY = Mathf.Sin(theta) / 100;
            transform.position += new Vector3(0, playerBobY * headBobMultiplier, 0);
        }
        playerPos = transform.position;
        currentWaypointPos = waypoints[activeWaypoint].transform.position;
        if (activeWaypoint < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(playerPos, currentWaypointPos, Time.deltaTime * playerSpeed);

            if (Vector3.Distance(currentWaypointPos, playerPos) < 0.3f)
            {
                activeWaypoint++;
            }

        }
        else if (activeWaypoint >= waypoints.Length)
        {
            activeWaypoint = waypoints.Length;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, waypoints[activeWaypoint].transform.rotation, Time.deltaTime);
    }

    
}

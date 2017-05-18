using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Instantiator : MonoBehaviour {

   // public int gridSize;
    int centerOffset;
    public GameObject markers;
    public GameObject clickedNode;
    bool walkable;
    public LayerMask unwalkable;
    // Use this for initialization
    void Start() {

        makeNodesAndSetNeighbors();
    }

    // Update is called once per frame
    void Update() {
        
    }


    /*Instantiates a bunch of cubes and sets its neighbors.  Pathfinding can be done on
    * a Hierarchical Grid structure or an Undirected Graph.  This function just uses an
    *  array as a cheap way of keeping the GameObject references in order, and discards
    *   the array structure afterward.At the end, what we have is a bunch of GameObjects
    *   with a PathfindingNode script attached, which has a list of its neighbors.  
    * This means that any GameObject/Script that wants to pathfind can climb through the
    * rest of the nodes via this reference without needing access to some kind of meta-structure
    * that stores all the nodes.
    */
    void makeNodesAndSetNeighbors()
    {
        GameObject[,] tempGrid = new GameObject[28,31];

        float cubeScale = 28f / 28;
        for (int i = 0; i < 28; ++i)
        {
            for (int j = 0; j < 31; ++j)
            {
                GameObject marker = (GameObject)Instantiate(markers,
                    new Vector3(-50f + (0.5f * cubeScale) + (cubeScale * i),
                        0f,
                        50f - (0.5f * cubeScale) - cubeScale * j),
                    Quaternion.identity);
                //marker.transform.localScale = new Vector3(100.0f / 28, 1f, 100.0f / 31);
                marker.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
               /* marker.GetComponent<Renderer>().material.color =
                   new Color(Random.Range(0.8f, 1.0f),
                   Random.Range(0.8f, 1.0f),
                   Random.Range(0.8f, 1.0f), 1);*/
                marker.transform.SetParent(transform);


                tempGrid[i, j] = marker;
            }
        }
    }
}

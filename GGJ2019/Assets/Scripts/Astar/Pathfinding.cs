using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {

	public Transform seeker, target;
    public GetDistanceType getDistanceType = GetDistanceType.Manhattan;
	public Grid grid;
    public List<Node> path;
    
    void Awake() {
        seeker = transform;
	}

    private void Start()
    {
        GameObject astar = GameObject.FindGameObjectWithTag("Astar Grid");
        grid = astar.GetComponent<Grid>();
    }

    void Update()
    {
        target = PlayerController.playerTransform;

        if (target == null)
        {
            return;
        }

		FindPath (seeker.position, target.position);
	}

	void FindPath(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node> openSet = new List<Node>();
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0) {
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i ++) {
                if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
                {
                    if (openSet[i].hCost < node.hCost)
                        node = openSet[i];
                }
			}

			openSet.Remove(node);
            closedSet.Add(node);

			if (node == targetNode) {   //selesai pencarian path
				RetracePath(startNode,targetNode);
				return;
			}

			foreach (Node neighbour in grid.GetNeighbours(node)) {
				if (!neighbour.walkable || closedSet.Contains(neighbour)) {
					continue;
				}

                switch (getDistanceType)
                {
                    case GetDistanceType.Manhattan:
                        float newCostToNeighbor = node.gCost + GetDistance(node, neighbour);

                        if (newCostToNeighbor < neighbour.gCost || !openSet.Contains(neighbour))
                        {
                            neighbour.gCost = newCostToNeighbor;
                            neighbour.hCost = GetDistance(neighbour, targetNode);
                            neighbour.parent = node;

                            if (!openSet.Contains(neighbour))
                            {
                                openSet.Add(neighbour);
                            }
                        }
                        break;

                    case GetDistanceType.Euclidean:
                        newCostToNeighbor = node.gCost + GetDistance(node, neighbour, true);

                        if (newCostToNeighbor <= neighbour.gCost || !openSet.Contains(neighbour))
                        {
                            neighbour.gCost = newCostToNeighbor;
                            neighbour.hCost = GetDistance(neighbour, targetNode, true);
                            neighbour.parent = node;

                            if (!openSet.Contains(neighbour))
                            {
                                openSet.Add(neighbour);
                            }
                        }
                        break;
                }                
			}
		}
	}

	void RetracePath(Node startNode, Node endNode) {
		path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();

		
	}

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
        return dstX + dstY;
    }

    float GetDistance(Node nodeA, Node nodeB, bool euclidean)
    {
        return Mathf.Sqrt(Mathf.Pow(nodeA.gridX - nodeB.gridX, 2) + Mathf.Pow(nodeA.gridY - nodeB.gridY, 2));
    }
}

public enum GetDistanceType
{
    Euclidean,
    Manhattan
}
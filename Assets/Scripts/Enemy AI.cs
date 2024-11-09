using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemyAI : MonoBehaviour
{
    public Vector2 north = new Vector2(0, 1);  // Vector2 for north
    public Vector2 south = new Vector2(0, -1); // Vector2 for south
    public Vector2 east = new Vector2(1, 0);   // Vector2 for east
    public Vector2 west = new Vector2(-1, 0);  // Vector2 for west
    public Vector2[] direction = new Vector2[4];  // Array of directions
    public LayerMask wall, player;
    public float moveSpeed = 3f;  // Movement speed of the enemy

    private Transform playerTransform;
    private Vector2 targetPosition;
    private List<Vector2> currentPath = new List<Vector2>();  // List to store the current path to follow

    private void Start()
    {
        playerTransform = Player.instance.gameObject.transform;  // Get the player's transform
        direction[0] = north;
        direction[1] = south;
        direction[2] = east;
        direction[3] = west;

        // Subscribe to PlayerTurnEnd event
        GameEvents.current.onPlayerTurnEnd += MoveEnemy;  // Assuming this is the event trigger
    }

    private void MoveEnemy()
    {
        // Calculate the path to the player if it's not already calculated
        if (currentPath.Count == 0)
        {
            currentPath = FindPath((Vector2)transform.position, (Vector2)playerTransform.position);
        }

        // If the path is not empty, move the enemy one step along the path
        if (currentPath.Count > 0)
        {
            MoveOneStep();
        }
    }

    // A* Pathfinding to find the path to the player
    private List<Vector2> FindPath(Vector2 start, Vector2 target)
    {
        List<Vector2> path = new List<Vector2>();
        HashSet<Vector2> closedSet = new HashSet<Vector2>();
        PriorityQueue<Node> openSet = new PriorityQueue<Node>();

        Node startNode = new Node(start, null, 0, Vector2.Distance(start, target));
        openSet.Enqueue(startNode, startNode.fCost);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet.Dequeue();

            // If the target is reached
            if (Vector2.Distance(currentNode.position, target) < 0.1f)
            {
                // Reconstruct the path
                while (currentNode != null)
                {
                    path.Add(currentNode.position);
                    currentNode = currentNode.parent;
                }
                path.Reverse(); // Reverse the path to go from start to target
                break;
            }

            closedSet.Add(currentNode.position);

            foreach (Vector2 direction in this.direction)
            {
                Vector2 neighbor = currentNode.position + direction;

                // Skip neighbors that are not walkable or already processed
                if (closedSet.Contains(neighbor) || !IsWalkable(neighbor)) continue;

                float gCost = currentNode.gCost + 1f; // Fixed cost of moving 1 unit
                float hCost = Vector2.Distance(neighbor, target);
                Node neighborNode = new Node(neighbor, currentNode, gCost, hCost);

                if (!openSet.Contains(neighborNode) || gCost < neighborNode.gCost)
                {
                    openSet.Enqueue(neighborNode, neighborNode.fCost);
                }
            }
        }

        return path;
    }

    // Check if the node (position) is walkable (i.e., no wall)
    private bool IsWalkable(Vector2 position)
    {
        return !Physics2D.OverlapCircle(position, 0.1f, wall);  // Check if position collides with walls
    }

    // Move the enemy one step along the calculated path
    private void MoveOneStep()
    {
        if (currentPath.Count > 0)
        {
            // Get the next position from the path
            Vector2 nextPosition = currentPath[0];

            // Get the direction to move in (normalize to avoid overshooting)
            Vector2 direction = nextPosition - (Vector2)transform.position;
            if (direction.magnitude > 0)
            {
                // Normalize the direction to get a unit vector
                direction.Normalize();

                // Move exactly 1 unit towards the next position
                Vector2 newPosition = Vector2.MoveTowards((Vector2)transform.position, nextPosition, 1f);

                // Update the transform's position (convert Vector2 back to Vector3)
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            }

            // If the enemy reaches the next position, remove it from the path
            if ((Vector2)transform.position == nextPosition)
            {
                currentPath.RemoveAt(0);  // Remove the first position in the path
            }
        }
    }

    // Node class for A* algorithm
    private class Node : IComparable<Node>
    {
        public Vector2 position;
        public Node parent;
        public float gCost;
        public float hCost;
        public float fCost => gCost + hCost;

        public Node(Vector2 position, Node parent, float gCost, float hCost)
        {
            this.position = position;
            this.parent = parent;
            this.gCost = gCost;
            this.hCost = hCost;
        }

        // Implementing IComparable to compare nodes by fCost
        public int CompareTo(Node other)
        {
            // Compare based on fCost (ascending order)
            if (fCost < other.fCost) return -1;
            if (fCost > other.fCost) return 1;

            // If fCosts are the same, we compare based on gCost
            if (gCost < other.gCost) return -1;
            if (gCost > other.gCost) return 1;

            return 0; // If both fCost and gCost are the same, return 0
        }
    }

    // PriorityQueue class for A* to prioritize nodes with the lowest fCost
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> elements = new List<T>();
        private List<float> priorities = new List<float>();

        public int Count => elements.Count;

        public void Enqueue(T item, float priority)
        {
            elements.Add(item);
            priorities.Add(priority);
        }

        public T Dequeue()
        {
            int bestIndex = 0;
            for (int i = 1; i < priorities.Count; i++)
            {
                if (priorities[i] < priorities[bestIndex])
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex];
            elements.RemoveAt(bestIndex);
            priorities.RemoveAt(bestIndex);
            return bestItem;
        }

        public bool Contains(T item)
        {
            return elements.Contains(item);
        }
    }
}

/*using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector2 north = new Vector2(0, 1);  // Vector2 for north
    public Vector2 south = new Vector2(0, -1); // Vector2 for south
    public Vector2 east = new Vector2(1, 0);   // Vector2 for east
    public Vector2 west = new Vector2(-1, 0);  // Vector2 for west
    public Vector2[] direction = new Vector2[4];  // Array of directions
    public Vector2[] neighbors = new Vector2[4];  // Array of neighbors
    public float[] playerDistance = new float[] { 0f, 0f, 0f, 0f };  // Array for storing distances
    public Transform movePoint;
    public LayerMask wall, player;

    private void Start()
    {
        GameEvents.current.onPlayerTurnEnd += MoveEnemy;
        direction[0] = north;
        direction[1] = south;
        direction[2] = east;
        direction[3] = west;
    }

    private void GetNeighbors()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            // Update the position by adding the direction (ignoring the z-component)
            neighbors[i] = new Vector2(transform.position.x, transform.position.y) + direction[i];
            //Debug.Log($"Neighbor {i}: {neighbors[i]}");
        }
    }

    private void GetDistanceFromPlayer()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            // Calculate the 2D distance (ignoring z-axis)
            playerDistance[i] = Vector2.Distance(neighbors[i], new Vector2(Player.instance.gameObject.transform.position.x, Player.instance.gameObject.transform.position.y));
            //Debug.Log($"Distance to neighbor {i}: {playerDistance[i]}");
        }
    }

    private void EnemyPathfinding()
    {
        int closestNode = -1;
        float closestDistance = 1000f;

        for (int i = 0; i < playerDistance.Length; i++)
        {
            movePoint.position = neighbors[i];
            if (!Physics2D.OverlapCircle((Vector2)movePoint.position, 0.1f, wall) && !Physics2D.OverlapCircle((Vector2)movePoint.position, 0.1f, player))
            {
                if (closestDistance > playerDistance[i])
                {
                    closestDistance = playerDistance[i];
                    closestNode = i;
                    //Debug.Log(closestNode);
                    //Debug.Log(direction[i]);
                }
            }
        }

        transform.position += new Vector3(direction[closestNode].x, direction[closestNode].y, 0);
    }

    private void MoveEnemy()
    {
        GetNeighbors();
        GetDistanceFromPlayer();
        EnemyPathfinding();
    }
}*/

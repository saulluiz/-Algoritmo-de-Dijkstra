using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoMenorCaminho
{
    public class Dijkstra
    {
        private int[,] edges;
        public Dijkstra(int numVertices)
        {
            edges = new int[numVertices, numVertices];

        }
        public void CreateEdge(int originNode, int destinationNode, int edgeWeight)
        {
            edges[originNode, destinationNode] = edgeWeight;
            edges[destinationNode, originNode] = edgeWeight;//para grafos nao direcionados

        }
        private static int GetClosestNode(int[] weightList, HashSet<int> unvisitedNodes)
        {
            int minDistance = int.MaxValue;
            int closestNode = 0;
            foreach (int node in unvisitedNodes)
            {
                if (weightList[node] < minDistance)
                {
                    minDistance = weightList[node];
                    closestNode = node;
                }

            }
            return closestNode;
        }
        private List<int> GetAdj(int node)
        {
            List<int> adj = new List<int>();
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                if (edges[node, i] > 0)
                {
                    adj.Add(i);
                }
            }
                return adj;
        }
        private int GetWeight(int originNode, int destinationNode)
        {
            return edges[originNode, destinationNode];
        }
        public List<int> MinimumPath(int originNode, int destinationNode)
        {
            int[] edgeWeights = new int[edges.Length]; 
            int[] pred = new int[edges.Length];
            HashSet<int> unvisitedNodes = new HashSet<int>();

            edgeWeights[originNode] = 0;

            for(int i = 0; i < edges.Length; i++)
            {
                if (i != originNode)
                    edgeWeights[i] = int.MaxValue;
                pred[i] = -1;
                unvisitedNodes.Add(i);
            }
            while(unvisitedNodes.Count > 0)
            {
                int closestNode = GetClosestNode(edgeWeights, unvisitedNodes);
                unvisitedNodes.Remove(closestNode);

                foreach(var v in GetAdj(closestNode))
                {
                    int totalWeight = edgeWeights[closestNode] + GetWeight(closestNode, destinationNode);
                    if (totalWeight < edgeWeights[v]) { 
                        edgeWeights[v] = totalWeight;
                        pred[v] = closestNode;
                    }
                }
                if(closestNode == destinationNode)
                {
                    return ClosestRoute(pred, closestNode);
                }
            }
            return null;
        }
        public List<int> ClosestRoute(int[] pred, int closestNode)
        {
            List<int> path = new List<int>();
           
            while (pred[closestNode] != -1) { 
                path.Add(closestNode);
                closestNode = pred[closestNode];
            }
            path.Reverse();
            return path;
        }
    }
}

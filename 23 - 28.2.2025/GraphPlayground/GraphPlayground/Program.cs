using System;
using System.Collections.Generic;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace GraphPlayground
{
    internal class Program
    {

        public static void DFS1(Graph graph, Node startNode, Node targetNode = null)
        {
            //pozmeneny BFS
            Console.WriteLine("Starting node: " + startNode.index);
            Node currentNode = null;
            List<Node> stack = new List<Node>() { startNode };

            while (stack.Count > 0)
            {
                currentNode = stack[0];
                currentNode.visited = true;
                Console.WriteLine("Current node: " + currentNode.index);
                stack.RemoveAt(0);
                foreach (Node neighbor in currentNode.neighbors)
                {
                    if (!neighbor.visited)
                    {
                        //queue.Add(neighbor);
                        stack.Insert(0, neighbor); //jenom tohle se prida - basically vkladam do fronty ty neighbors, takze projedu do hloubky
                        Console.WriteLine("   Adding node " + neighbor.index + " to queue.");
                    }
                    else Console.WriteLine("   Node " + neighbor.index + " is already visited.");
                }
            }
            Console.WriteLine("Finished at node " + currentNode.index);
        }

        public static void DFS2(Node currentNode)
        {
            //pomoci rekurze
            Console.WriteLine("Current node: " + currentNode.index);
            currentNode.visited = true;
            foreach (Node neighbor in currentNode.neighbors)
            {
                if (!neighbor.visited)
                {
                    DFS2(neighbor);
                }
                else
                {
                    Console.WriteLine("   Neighbor " + neighbor.index + " already visited");
                }
            }
            Console.WriteLine("Returning from " + currentNode.index);
        }

        public static void BFS(Graph graph, Node startNode, Node targetNode = null)
        {
            Console.WriteLine("Starting node: " + startNode.index);
            Node currentNode = null;
            List <Node> queue = new List <Node>() { startNode };

            while (queue.Count > 0)
            {
                currentNode = queue[0];
                currentNode.visited = true;
                Console.WriteLine("Current node: " + currentNode.index);
                queue.RemoveAt(0);
                foreach(Node neighbor in currentNode.neighbors)
                {
                    if (!neighbor.visited)
                    {
                        queue.Add(neighbor);
                        Console.WriteLine("   Adding node " + neighbor.index + " to queue.");
                    }
                    else Console.WriteLine("   Node " + neighbor.index + " is already visited.");
                }
            }
            Console.WriteLine("Finished at node " + currentNode.index);
        }

        static void Main(string[] args)
        {
            //Create and print the graph
            Graph graph = new Graph();
            graph.PrintGraph();
            graph.PrintGraphForVisualization();

            //Call both algorithms with a random starting node
            Random rng = new Random();

            Console.WriteLine("\nDFS z BFS:");
            DFS1(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.WriteLine("\nDFS s rekurzi:");
            DFS2(graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.WriteLine("\nBFS:");
            BFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.ReadKey();
        }
    }
}

using System.Collections.Generic;
using System;


namespace ShareefSoftware
{
    /// Utility class to traverse a grid.
    public class GridTraversal<T>
    {
        private bool[,] visited;
        private readonly IGridGraph<T> grid;
        private readonly int[] parent;
        private readonly int[] rank;
        /*
         * 
         */

        /// Constructor
        public GridTraversal(IGridGraph<T> grid)
        {
            this.grid = grid;
            parent = new int[grid.NumberOfRows * grid.NumberOfColumns];
            rank = new int[grid.NumberOfRows * grid.NumberOfColumns];
        }

        /*
         * Define visited to keep track of visited nodes.
         * Call TraverseWithPrims to start the traversel of the minimum spanning tree with a predefined starting column and row
         * 
         */
        public IEnumerable<((int Row, int Column) From, (int Row, int Column) To)> GenerateMaze(int startRow, int startColumn)
        {
            visited = new bool[grid.NumberOfRows, grid.NumberOfColumns];
            return TraverseWithPrims(startRow, startColumn);
        }

        public IEnumerable<((int Row, int Column) From, (int Row, int Column) To)> TraverseWithPrims(int startRow, int startColumn)
        {
            // Create a list of edges to store edges to be later evaulated for weight
            var edges = new List<Edge>();

            // Add all neighbors of the starting cell
            AddNeighbors(startRow, startColumn, edges);

            //Loop through the entire list to traverse through all of the nodes
            while (edges.Count > 0)
            {
                // Find the index of the edge from the list with the minimum weight
                var minIndex = FindMinimumWeightEdgeIndex(edges);
                //Set edge to the edge with the smallest weight
                var edge = edges[minIndex];

                // Remove the edge from the list
                edges.RemoveAt(minIndex);

                // Get the destination cell of the edge
                var destinationCell = edge.To;

                // If the destination cell has not been visited
                if (!visited[destinationCell.Row, destinationCell.Column])
                {
                    // Mark the destination cell as visited
                    visited[destinationCell.Row, destinationCell.Column] = true;

                    // Yield the edge to include it in the traversal path
                    yield return ((edge.From.Row, edge.From.Column), (destinationCell.Row, destinationCell.Column));

                    // Add neighbors of the destination cell
                    AddNeighbors(destinationCell.Row, destinationCell.Column, edges);
                }
            }
        }

        // Helper method to enqueue neighbors of a cell
        private void AddNeighbors(int row, int column, List<Edge> edges)
        {
            foreach (var neighbor in grid.Neighbors(row, column))
            {
                if (!visited[neighbor.Row, neighbor.Column])
                {
                    var weight = GenerateRandomWeight(); // Generate a random weight for the edge
                    edges.Add(new Edge((row, column), neighbor, weight));
                }
            }
        }

        // Helper method to generate a random weight
        private double GenerateRandomWeight()
        {
            Random random = new Random();
            return random.NextDouble() * 10; // Generates a random weight between 0 and 10
        }

        // Helper method to find the index of the edge with the minimum weight
        private int FindMinimumWeightEdgeIndex(List<Edge> edges)
        {
            var minIndex = 0;
            var minWeight = double.MaxValue;

            for (var i = 0; i < edges.Count; i++)
            {
                if (edges[i].Weight < minWeight)
                {
                    minIndex = i;
                    minWeight = edges[i].Weight;
                }
            }

            return minIndex;
        }

        /*
         * If the parent of cell x is not itself (i.e., it is not a root parent), recursively call the Find method on the parent of x until a root parent is found.
         * When the root parent of x is found, set the parent of x to be the root parent. This step helps with path compression, where subsequent calls to Find on x will directly return the root parent without traversing the entire path again.
         */
        private int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }

            return parent[x];
        }

        // Helper class to represent an edge with its weight
        private class Edge : IComparable<Edge>
        {
            public (int Row, int Column) From { get; }
            public (int Row, int Column) To { get; }
            public double Weight { get; }

            public Edge((int Row, int Column) from, (int Row, int Column) to, double weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }

            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }
        }
    }
}
        using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;


namespace ConsoleApp31
    {
        class clsGraph
        {
        public class Node //Вершина
        {
            public int Value { get; set; }
            public List<Edge> Edges { get; set; } //исходящие связи
        }

        public class Edge //Ребро
        {
            public int Weight { get; set; } //вес связи
            public Node Node { get; set; } // узел, на который связь ссылается
        }

        private int Vertices;
            private List<Int32>[] adj;
            /*      Пример : vertices=4
             *      0->[1,2]
             *      1->[2]
             *      2->[0,3]
             *      3->[]
             */

            public clsGraph(int v)
            {
                Vertices = v;
                adj = new List<Int32>[v];
                for (int i = 0; i < v; i++)
                {
                    adj[i] = new List<Int32>();
                }

            }

            public void AddEdge(int v, int w)
            {
                adj[v].Add(w);
            }

            // BFS 
            void BFS(int s)
            {
                bool[] visited = new bool[Vertices];

                Queue<int> queue = new Queue<int>();
                visited[s] = true;
                queue.Enqueue(s);

                while (queue.Count != 0)
                {
                    s = queue.Dequeue();
                    Console.WriteLine("следующая->" + s);

                    foreach (Int32 next in adj[s])
                    {
                        if (!visited[next])
                        {
                            visited[next] = true;
                            queue.Enqueue(next);
                        }
                    }

                }
            }

            //DFS 
            public void DFS(int s)
            {
                bool[] visited = new bool[Vertices];

                Stack<int> stack = new Stack<int>();
                visited[s] = true;
                stack.Push(s);

                while (stack.Count != 0)
                {
                    s = stack.Pop();
                    Console.WriteLine("следующая->" + s);
                    foreach (int i in adj[s])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            stack.Push(i);
                        }
                    }
                }
            }

            public void PrintAdjacecnyMatrix()
            {
                for (int i = 0; i < Vertices; i++)
                {
                    Console.Write(i + ":[");
                    string s = "";
                    foreach (var k in adj[i])
                    {
                        s = s + (k + ",");
                    }
                    s = s.Substring(0, s.Length - 1);
                    s = s + "]";
                    Console.Write(s);
                    Console.WriteLine();
                }
            }
            public static void Main()
            {
                clsGraph graph = new clsGraph(4);
                graph.AddEdge(0, 1);
                graph.AddEdge(0, 2);
                graph.AddEdge(1, 2);
                graph.AddEdge(2, 0);
                graph.AddEdge(2, 3);
                graph.AddEdge(3, 3);
                graph.PrintAdjacecnyMatrix();

                Console.WriteLine("Обход BFS, начиная с вершины 2:");
                graph.BFS(2);
                Console.WriteLine("Обход DFS, начиная с вершины 2:");
                graph.DFS(2);
            }
        }
    }



      

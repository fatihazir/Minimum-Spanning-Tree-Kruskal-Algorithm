using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reading file section.
            string nameOfTxt = "./input.txt"; //1
            string[] lines = System.IO.File.ReadAllLines(nameOfTxt);//O(N)



            // Info about vertex and edge amount.
            string[] info = lines[0].Split(' ');
           


            // Seperating every line as edges.
            List<Edge> edges = new List<Edge>();//1

            for (int i = 1; i < lines.Length; i++) //Current complexity is O(N)
            {
                string[] charsPerLine = lines[i].Split(' ');//1
                Edge tempEdge = new Edge()//1
                {
                    From = charsPerLine[0],
                    To = charsPerLine[1],
                    Weight = Convert.ToInt32(charsPerLine[2])
                };

                edges.Add(tempEdge);//1
            }



            //Ordering by weights.
            List<Edge> newEdgesByWeightASC = edges.OrderBy(i => i.Weight).ToList(); //Current complexity is O(N)



            //Detecting cycles and initialize the spaninng tree.
            List<Edge> spanningTree = new List<Edge>();//1

            bool isCycled = false;//1
            bool fromIsUnique = true;//1
            bool toIsUnique = true;//1

            foreach (Edge tempEdge in newEdgesByWeightASC) //Current complexity is O(N)
            {

                if (spanningTree.Count == 0)//First element of spanning tree.
                {
                    spanningTree.Add(tempEdge);//1
                    continue;//1
                }
                    

                foreach (Edge tempSpanningEdge in spanningTree)//Detecting cycles. Current complexity is O(N^2) (this is a foreach loop which is in another foreach)
                {
                    if (tempSpanningEdge.From == tempEdge.From)//1
                        fromIsUnique = false;

                    if (tempSpanningEdge.To == tempEdge.To)//1
                        toIsUnique = false;

                    if (fromIsUnique == false && toIsUnique == false)//1
                    {
                        isCycled = true;
                        fromIsUnique = true;
                        toIsUnique = true;
                        
                        continue;
                    }
                }

                if (!isCycled)
                    spanningTree.Add(tempEdge);//1

                isCycled = false;//1
                fromIsUnique = true;//1
                toIsUnique = true;//1
            }



            //Output as a information for spanning tree.
            Console.WriteLine("Information of our spanning tree:");

            Console.WriteLine($"Amount of vertex: {info[0]} -- amount of edge: {info[1]}");


            int maxWeightOfSpanningTree = 0;//1
            foreach (var edge in spanningTree) //Current complexity is O(N)
            {
                Console.WriteLine($"From vertex: {edge.From} to: {edge.To} weight: {edge.Weight}");
                maxWeightOfSpanningTree += edge.Weight;
            }
            Console.WriteLine($"Total weight of spanning tree is: {maxWeightOfSpanningTree}");
            Console.WriteLine("-----------------------------------------------------------------------------------");


            Console.Write("Complexity is O(N'2) because of there is 2 foreach loop inside between them.");
            Console.ReadKey();

        }
    }
}

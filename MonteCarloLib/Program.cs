using MonteCarloLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MonteCarloLib
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Monte Carlo  Algorithm Tests");

            while (true)
            {  

                var watch = Stopwatch.StartNew(); 
                 Console.WriteLine();   

                var s1 = new Node("nod1");
                s1.AddAction(new NodeAction(1, true)); 
                var s2 = new Node("nod2");
                s2.AddAction(new NodeAction(1, true));
                s2.AddAction(new NodeAction(10, false)); 
                var s3 = new Node("nod3");
                s3.AddAction(new NodeAction(10, true));
                s3.AddAction(new NodeAction(20, false)); 
                var s4 = new Node("nod4");
                s4.AddAction(new NodeAction(10, true));
                s4.AddAction(new NodeAction(2, false)); 
                var s5 = new Node("nod5");
                s5.AddAction(new NodeAction(1, true));
                s5.AddAction(new NodeAction(2, false)); 
                var s6 = new Node("nod6");
                s6.AddAction(new NodeAction(10, true)); 

                var s7 = new Node("nod7");
                s7.AddAction(new NodeAction(30, true));   // Win 

                var s8 = new Node("Node8");
                s8.AddAction(new NodeAction(1, true)); 
                var s9 = new Node("Node9");
                s9.AddAction(new NodeAction(1, true));   
                
                s8.AddChild(s9);
                s7.AddChild(s8);
                s2.AddChild(s4);
                s2.AddChild(s5);
                s3.AddChild(s6);
                s3.AddChild(s7);
                s1.AddChild(s2);
                s1.AddChild(s3);   
                
                var s10 = new Node("Node10");
                s10.AddAction(new NodeAction(1, true));
                s9.AddChild(s10);  

                var simulation = new Simulation((int visit, long time) => time < 2000);
                simulation.Simulate(s1, new Player()); 


                PrintTree(s1, "", false); 
                Console.WriteLine($"Time : {watch.ElapsedMilliseconds}"); 
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="indent"></param>
        /// <param name="last"></param>
        /// <param name="weight"></param>
        static void PrintTree(Node tree, string indent, bool last, float weight = 0)
        {

            Console.WriteLine($" {indent}-{tree.ToString()}    ");
            indent += last ? "   " : "|  ";
            for (int i = 0; i < tree._ChildNodes.Count; i++)
                PrintTree(tree._ChildNodes[i], indent, i == tree._ChildNodes.Count - 1);
        }


    }
}

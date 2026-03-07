Hierarchical Data Structures in C#
Topic: Implementing and Traversing a General Tree
Complexity: Intermediate
1. Objective
To understand the practical application of Tree Data Structures by modeling a real-world scenario (an Organizational Chart). You will practice object-oriented design, list management, and recursive algorithms.
2. Scenario
You have been hired by a startup to build a lightweight HR tool. The tool must be able to represent the company’s reporting structure, where one manager can have multiple direct reports.
3. Technical Requirements
Your solution must include the following components:
• The Node Class: Create a generic class TreeNode<T>.
o It must store a Data property of type T.
o It must maintain a collection of children (e.g., List<TreeNode<T>>).
o Include a method AddChild(TreeNode<T> child) to build the hierarchy.
• The Tree Traversal: Implement a Recursive function to display the tree.
o The output must use indentation (spaces or dashes) to visually represent the "depth" of each employee.
• The Data: Populate the tree with at least three levels (e.g., CEO → Director → Manager → Employee).
 
 
public class EmployeeNode
{
   public string Name { get; set; }
   public string Position { get; set; }
   public List<EmployeeNode> Reports { get; set; } = new List<EmployeeNode>();
 
   public EmployeeNode(string name, string position)
   {
       Name = name;
       Position = position;
   }
   public void AddReport(EmployeeNode employee)
{
   Reports.Add(employee);
}
}

public class OrganizationTree
{
   public EmployeeNode Root { get; private set; }
 
   public OrganizationTree(EmployeeNode rootEmployee)
   {
       Root = rootEmployee;
   }
 
   // This method should start the recursion from the Root
   public void DisplayFullHierarchy()
   {
       PrintRecursive(Root, 0);
   }
 
   private void PrintRecursive(EmployeeNode current, int depth)
   {
       // STUDENT TO IMPLEMENT: Recursive logic and indentation
   }
}
 

class Program
{
   static void Main(string[] args)
   {
       // 1. Initialize Nodes
var ceo = new EmployeeNode("Aman", "CEO");
var cto = new EmployeeNode("Suresh", "CTO");
var manager = new EmployeeNode("Sonia", "Dev Manager");
var dev1 = new EmployeeNode("Sara", "Senior Dev");
var dev2 = new EmployeeNode("Divakar", "Junior Dev");
var cfo = new EmployeeNode("Rajesh", "CFO");
var acccOfficer = new EmployeeNode("Rajat", "Account Officer");
 
// 2. Build the Tree Structure
var company = new OrganizationTree(ceo);
 
ceo.AddReport(cto);
 
cto.AddReport(manager);
manager.AddReport(dev1);
manager.AddReport(dev2);
 
ceo.AddReport(cfo);
cfo.AddReport(acccOfficer);
 
company.DisplayFullHierarchy();
   }
}
 


using System;
using System.Collections.Generic;
 
public class EmployeeNode
{
   public string Name { get; set; }
   public string Position { get; set; }
   public List<EmployeeNode> Reports { get; set; }
 
   public EmployeeNode(string name, string position)
   {
       Name = name;
       Position = position;
       Reports = new List<EmployeeNode>();
   }
 
   public void AddReport(EmployeeNode employee)
   {
       Reports.Add(employee);
   }
}
 
public class OrganizationTree
{
   public EmployeeNode Root { get; set; }
 
   public OrganizationTree(EmployeeNode rootEmployee)
   {
       Root = rootEmployee;
   }
 
   // Public method that starts the recursion
   public void Display()
   {
       if (Root == null) return;
       Console.WriteLine("ORGANIZATION STRUCTURE");
       Console.WriteLine("======================");
       PrintRecursive(Root, 0);
   }
 
   // Private helper method for recursion
   private void PrintRecursive(EmployeeNode current, int depth)
   {
       // Create indentation based on depth
       string indent = new string(' ', depth * 4);
       string connector = depth == 0 ? "" : "└── ";
 
       Console.WriteLine($"{indent}{connector}{current.Name} ({current.Position})");
 
       // Recursively call for each child
       foreach (var report in current.Reports)
       {
           PrintRecursive(report, depth + 1);
       }
   }
}
class Program
{
   static void Main(string[] args)
   {
       // 1. Initialize Nodes
       var ceo = new EmployeeNode("Jordan Smith", "CEO");
       var cto = new EmployeeNode("Alex Chen", "CTO");
       var manager = new EmployeeNode("Sarah Vane", "Dev Manager");
       var dev1 = new EmployeeNode("Leo G.", "Senior Dev");
       var dev2 = new EmployeeNode("Maya R.", "Junior Dev");
 
       // 2. Build the Tree Structure
       var company = new OrganizationTree(ceo);
       
       ceo.AddReport(cto);
       cto.AddReport(manager);
       manager.AddReport(dev1);
       manager.AddReport(dev2);
 
       // 3. Execute Display
       company.Display();
 
       // Prevent console from closing immediately
       Console.WriteLine("\nPress any key to exit...");
       Console.ReadKey();
   }
}
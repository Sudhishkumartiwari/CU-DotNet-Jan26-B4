The Challenge: "The Cargo Manifest Optimizer"
1. The Data Structure
You are managing a List<List<Category>> representing a Cargo Bay.
• The Outer List represents Rows in the cargo bay.
• The Inner List represents Containers within that row.
• Each Container (an object) holds its own List<Item> (The "Items" inside).
Class Structure:
• Item: string Name, double Weight, string Category (e.g., "Electronics", "Perishables").
• Container: string ContainerID, List<Item> Items.
 
2. The Requirements
Task A: The "Deep Search" (Filtering)
Write a method FindHeavyContainers(double weightThreshold) that returns a flat List<string> of ContainerIDs where the total weight of items inside exceeds the threshold. You must traverse all rows and all containers.
Task B: The "Category Audit" (Grouping)
Write a method GetItemCountsByCategory(). This must return a Dictionary<string, int> where the key is the Category name and the value is the total count of items in that category across the entire nested structure.
Task C: The "Structural Reorganizer" (Transformation)
This is the toughest part. Write a method FlattenAndSortShipment().
1. Flatten the List<List<Container>> into a single List<Item>.
2. Remove any duplicate items (based on Name).
3. Sort the final list first by Category (alphabetical) and then by Weight (descending).
 
3. Constraints & Complexity
• Null Safety: Your code must handle cases where a Row (inner list) is empty or a Container has no items without throwing a NullReferenceException.
• Performance: Try to solve Task C using LINQ SelectMany to see how much cleaner it makes the code compared to triple-nested foreach loops.
 
Example Data for Testing
C#
var cargoBay = new List<List<Container>>
{
   // ROW 0: High-Value Tech Row
   new List<Container>
   {
       new Container("C001", new List<Item>
       {
           new Item("Laptop", 2.5, "Tech"),
           new Item("Monitor", 5.0, "Tech"),
           new Item("Smartphone", 0.5, "Tech")
       }),
       new Container("C104", new List<Item>
       {
           new Item("Server Rack", 45.0, "Tech"), // Heavy Item
           new Item("Cables", 1.2, "Tech")
       })
   },
 
   // ROW 1: Mixed Consumer Goods
   new List<Container>
   {
       new Container("C002", new List<Item>
       {
           new Item("Apple", 0.2, "Food"),
           new Item("Banana", 0.2, "Food"),
           new Item("Milk", 1.0, "Food")
       }),
       new Container("C003", new List<Item>
       {
           new Item("Table", 15.0, "Furniture"),
           new Item("Chair", 7.5, "Furniture")
       })
   },
 
   // ROW 2: Fragile & Perishables (Includes an Empty Container)
   new List<Container>
   {
       new Container("C205", new List<Item>
       {
           new Item("Vase", 3.0, "Decor"),
           new Item("Mirror", 12.0, "Decor")
       }),
       new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
   },
 
   // ROW 3: EDGE CASE - Empty Row
   new List<Container>() // A row that exists but has no containers
};
Project Title: Cricket Player Performance Tracker
Background
The "HackerLand Cricket League" needs a tool to process player statistics stored in a CSV file. The tool must calculate specific performance metrics, handle data irregularities, and output the final results into a sorted collection.
 
1. Data Structure (The Player Class)
Create a Player class to store the following information:
• Name (string)
• RunsScored (int)
• BallsFaced (int)
• IsOut (bool)
• StrikeRate (double) - Calculated
• Average (double) - Calculated
 
2. Business Logic Calculations
Your program must implement the following cricket-specific formulas:
• Strike Rate ($SR$): The number of runs scored per 100 balls faced.
$$SR = \frac{\text{Runs Scored}}{\text{Balls Faced}} \times 100$$
• Batting Average ($Avg$): The total runs scored divided by the number of times the player was out.
o Rule: If the player has never been out (IsOut = false), the average is equal to their total runs.
 
3. Requirements
A. File Processing (CSV)
Read a file named players.csv. The format is: Name, Runs, Balls, IsOut.
Example:
Code snippet
Steve Smith, 84, 90, True
Virat Kohli, 29, 35, False
Joe Root, 110, 120, True
B. Exception Handling
Your code must handle the following scenarios gracefully:
• FileNotFoundException: If the CSV is missing, print a user-friendly error.
• FormatException: If a "Run" or "Ball" value is not a valid integer.
• DivideByZeroException: Ensure you don't crash if BallsFaced is 0 when calculating Strike Rate.
C. Collections & Sorting
• Store all valid Player objects in a List<Player>.
• Filter out any players who have faced fewer than 10 balls.
• Sort the final list by StrikeRate in descending order.
 
4. Assignment Tasks
1. Create a Console Application that prompts the user for the CSV file path.
2. Parse the file line-by-line using string.Split(',').
3. Perform the calculations and populate the Player objects.
4. Display the results in a formatted table in the console.
 
5. Sample Output
Plaintext
Name            Runs    SR      Avg    
---------------------------------------
Joe Root        110     91.67   110.00
Steve Smith     84      93.33   84.00
Virat Kohli     29      82.86   29.00
 
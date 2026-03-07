🚩 Challenge: "The High-Score Leaderboard"
You are developing the backend for a racing game. You need to store player names and their fastest lap times. The requirement is that the list must always be sorted by the lap time (the Key) so that the leaderboard is ready to display at any moment.
Assignment Tasks
1. Initialize the Sorted Collection
Create a SortedDictionary<double, string> named leaderboard.
• Key: Lap time in seconds (double).
• Value: Player name (string).
2. Populate Data
Add the following records to the dictionary:
• 55.42: "SwiftRacer"
• 52.10: "SpeedDemon"
• 58.91: "SteadyEddie"
• 51.05: "TurboTom"
3. Automatic Sorting Verification
Print all players and their times. Observe that even though "TurboTom" was added last, he should appear first in the output because his time is the lowest.
4. Range Logic (Find the "Gold Medal" Time)
Retrieve the first entry in the collection (the fastest time) without using a loop.
Hint: Use leaderboard.Keys.First() or leaderboard.First().
5. Update a Record
"SteadyEddie" improved his time to 54.00.
• Task: Remove the old record (58.91) and add the new one. (Keys in a SortedDictionary are immutable; you must delete and re-insert to "change" a key).
 
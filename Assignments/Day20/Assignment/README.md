Problem Statement: The SkyHigh Flight Aggregator
Background
You are a software engineer for "SkyHigh," a new flight search engine. The core engine receives a list of flight options from various airlines, but the raw data is unsorted. To provide a high-quality user experience, the system must present these flights in a logical order.
While most users care about the cheapest option, power users often want to prioritize speed (duration) or timing (departure time).
Requirements
1. The Flight Model: Create a Flight class that stores:
o FlightNumber (String)
o Price (Decimal)
o Duration (TimeSpan)
o DepartureTime (DateTime)
2. Natural Sorting (Default): Implement the IComparable<T> interface within the Flight class. By default, when a list of flights is sorted without any specific instructions, it must be ordered by Price (Ascending).
3. Advanced Filtering (Custom): The UI team needs two additional sorting "strategies." Implement the IComparer<T> interface in two separate classes:
o DurationComparer: Sorts flights from shortest to longest duration.
o DepartureComparer: Sorts flights from earliest to latest departure.
4. Edge Case Handling: Ensure your comparison logic gracefully handles null objects to prevent the application from crashing during sort operations.
Expected Output
When given a list of disorganized flight data, your solution should be able to produce three distinct views:
1. Economy View: Cheapest flights at the top.
2. Business Runner View: Shortest flights at the top.
3. Early Bird View: Earliest departing flights at the top.
 
Success Criteria
• The Flight class uses IComparable<T> for price.
• The separate comparer classes implement IComparer<T>.
• The List<T>.Sort() method is used correctly to apply both the default and the custom logic.
• The code is clean, readable, and follows C# naming conventions.
 
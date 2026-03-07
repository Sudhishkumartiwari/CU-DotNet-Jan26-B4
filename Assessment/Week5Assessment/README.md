Global Freight Tracking System
Business Scenario
You are developing a core module for "SwiftRoute Logistics." The system tracks shipments. A shipment has a Weight, a Destination, and a Tracking ID.
• Business Rule 1: Shipments over 1,000kg require a special "Heavy Lift" permit.
• Business Rule 2: We do not ship to "Restricted Zones" (e.g., "North Pole", "Unknown Island").
• Business Rule 3: All shipment attempts, successful or failed, must be logged to a local text file for auditing.
 
1. Exception Design
You must implement a mix of built-in and custom exceptions:
• User-Defined Exception: RestrictedDestinationException
o Triggered when a shipment destination is on the restricted list.
• User-Defined Exception: InsecurePackagingException
o Triggered if the weight is valid but the "Fragile" flag is set without a "Reinforced" status (logical check).
• Built-in Exception: ArgumentOutOfRangeException
o Triggered if the shipment weight is less than or equal to 0.
2. OOP Structure
• Abstract Base Class: Shipment
o Properties: string TrackingId, double Weight, string Destination.
o Abstract Method: void ProcessShipment().
• Derived Classes: * ExpressShipment: Implements fast processing logic.
o HeavyFreight: Implements logic that checks for the "Heavy Lift" permit.
• Interface: ILoggable
o Method: void SaveLog(string message).
 
3. File Handling Requirement
Create a LogManager class that implements ILoggable.
• It should use a StreamWriter to append error messages or success stamps to a file named shipment_audit.log.
• Ensure you use a finally block or a using statement to handle the file stream safely.
 
4. Implementation Task
Write a program that performs the following steps:
1. Initialize a list of Shipment objects (some with valid data, some with invalid data).
2. Loop through the list and call ProcessShipment().
3. Use a try-catch-finally block:
o Catch RestrictedDestinationException specifically to log a "Security Alert."
o Catch ArgumentOutOfRangeException to log a "Data Entry Error."
o Catch the general Exception to prevent the app from crashing.
o In the finally block, print "Processing attempt finished for ID: [ID]."
5. Success Criteria
• The application does not crash when an invalid shipment is processed.
• The shipment_audit.log file contains a detailed history of what went wrong.
• The HeavyFreight class correctly overrides the base logic to handle weight limits.
• Custom exceptions provide meaningful data (like the DeniedLocation) back to the caller.
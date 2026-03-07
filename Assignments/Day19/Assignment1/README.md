Technical Challenge: The "Eco-Drive" Vehicle Simulation
Background
You are developing a vehicle simulation engine for a logistics company. The company operates different types of vehicles, and they need a system to calculate fuel consumption and display travel statuses. Each vehicle type handles "movement" differently based on its mechanical constraints.
The Objective
Design a class hierarchy that allows a central controller to manage a fleet of vehicles. The controller should be able to trigger movement for all vehicles in a single loop, without knowing the specific details of each vehicle type.
Requirements
1. The Base Class: Vehicle
• Define a class Vehicle that cannot be instantiated directly (use the abstract keyword).
• Add a property ModelName (string).
• Add an Abstract Method called Move(). This forces every vehicle to define its own movement logic.
• Add a Virtual Method called GetFuelStatus(). It should provide a default implementation that returns: "Fuel level is stable."
2. The Derived Classes
Create three specific vehicle types that inherit from Vehicle:
• ElectricCar:
o Override Move() to print: "[ModelName] is gliding silently on battery power."
o Override GetFuelStatus() to change the message to: "[ModelName] battery is at 80%."
• HeavyTruck:
o Override Move() to print: "[ModelName] is hauling cargo with high-torque diesel power."
o Do not override GetFuelStatus() (let it use the default base behavior).
• CargoPlane:
o Override Move() to print: "[ModelName] is ascending to 30,000 feet."
o Override GetFuelStatus() to call the base implementation first, then add: "Checking jet fuel reserves..." (Combine both strings).
3. The Fleet Controller
In your Main method:
1. Create a Array of Vehicle containing one of each type.
2. Iterate through the array and, for each vehicle:
o Call Move().
o Call GetFuelStatus() and print the result.
 
Success Criteria
• No Interfaces: You must achieve this strictly through class inheritance.
• Runtime Selection: The program must correctly identify whether to use the Base, the Override, or a combination of both (using base) at runtime.
• Abstraction: Your Array loop should not use if or switch statements to check the type of vehicle.
 
Assignment: The Smart Kitchen Architect
Scenario
You have been hired by a home automation startup, AeroCook, to build the backend logic for their new line of kitchen appliances. The company wants a system that is modular, easy to expand, and prevents code duplication.
The Problem Statement
Your task is to design a software system that models three specific products. You must determine the best way to group shared traits while ensuring each device remains distinct.
The Device Profiles
1. The Microwave: Needs a way to track cooking time via a timer and must define its own specific cooking process.
2. The Electric Oven: This is the flagship product. It requires a timer, needs to be connected to the local WiFi for remote monitoring, and requires a preheating stage before it starts cooking.
3. The Air Fryer: A simple, mechanical device. It needs to cook food quickly, but it does not have a digital timer or any smart connectivity.
 
Your Challenge
1. Identify the Hierarchy
Look at the three devices above. All of them share basic hardware specs like a Model Name and Power Consumption (Watts).
• How will you structure a "Base" class to hold these shared properties?
• Should this base class be something you can actually "create," or is it just a template?
2. Identify the "Behaviors" (Interfaces)
Not every device can do everything. Some have timers, and some have WiFi.
• How will you handle "Timer" and "WiFi" capabilities so that you don't force an Air Fryer to have WiFi it doesn't possess?
• What is the best tool to enforce these "contracts" across different classes?
3. Logic & Polymorphism
• Cooking: Every device "Cooks," but they do it differently. How do you force every device to have a Cook() method while letting them decide how it works?
• Preheating: Most appliances just start immediately, but the Oven needs a special "Preheat" step. How can you provide a default "Preheat" action that only the Oven changes?
 
Deliverables
1. A Class Diagram: Sketch or describe how your classes and interfaces relate to one another.
2. The Code: Implement the solution in your chosen language.
3. The Test: Create a Main method where you:
o Store all three devices in a single list (if possible).
o Loop through them to trigger their Cook() methods.
o Demonstrate that the Oven can connect to WiFi, but the others cannot.
 
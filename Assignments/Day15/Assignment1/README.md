​​
Coding Question

Create a program in C# to represent and add the heights of two people.

Requirements:

1. Define a class Height with properties Feet and Inches.
2. Implement:
o A default constructor (initialize height to 0 feet 0.0 inches).
o A parameterized constructor (initialize feet and inches with given values).
o A method AddHeights(Height h2) that adds the height of two people and return the added Height.
▪ If inches ≥ 12, convert the extra inches into feet.
o Override ToString() to display the height in the format:
o Height - X feet Y inches
3. In the Main() method:
o Create two Height objects (person1, person2) using the parameterized constructor.
o Call AddHeights() to find their combined height.
o Print both heights and the total height.
Sample Output:

Height - 5 feet 6.5 inches

Height - 5 feet 7.5 inches

Height - 11 feet 2.0 inches

 
🚩 Challenge: "The Secure Terminal"
You are building a terminal interface. It needs to handle a secret "Access Code" character-by-character and then allow the user to type a "System Message" using a buffer.
Assignment Tasks
1. The Masked PIN (Using ReadKey)
The user must enter a 4-digit PIN.
• Use a loop and Console.ReadKey(true).
• For every key pressed, print a * to the console so the PIN remains secret.
• Store the digits in a string.
• Display the digit.
• Logic: Use the KeyChar property to capture the actual value.
 
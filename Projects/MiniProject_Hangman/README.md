Since you prefer using the **CLI** and are working on your **Mac**, a well-structured `README.md` is the best way to keep your project organized. This challenge is designed to test your logic, string manipulation, and state management—all core skills as you dive deeper into .NET.

Here is a detailed **Hangman Game Assignment** formatted as a professional README.

---

# Exercise: The Hangman CLI Challenge

## 🎯 Objective

Create a functional, interactive **Command-Line Interface (CLI)** Hangman game using **C#** and **.NET**. This project will test your ability to manage loops, handle user input, and manipulate strings/arrays.

---

## 📖 The Story

You are building a terminal-based game where the computer selects a secret word, and the player must guess it one letter at a time. For every wrong guess, a part of the "hangman" is drawn. If the drawing is completed before the word is guessed, the player loses.

---

## 🛠 Functional Requirements

### 1. Word Initialization

* The program should have a predefined list (Array or List) of at least 10 words.
* Upon starting, the program must **randomly select** one word from this list.

### 2. Game Display

* Display the "Hidden Word" using underscores (e.g., if the word is `DOTNET`, show `_ _ _ _ _ _`).
* Show the number of **remaining lives** (start with 6).
* Maintain a list of **Already Guessed Letters** so the player doesn't repeat mistakes.

### 3. User Input Logic

* The user should input exactly **one letter** per turn.
* **Validation:** * If the user enters a number or symbol, show an error.
* If the user enters a letter they already guessed, notify them without losing a life.
* Handle both Uppercase and Lowercase inputs (Case-insensitive).



### 4. Win/Loss Conditions

* **Win:** If all underscores are replaced by correct letters before lives reach zero.
* **Loss:** If the player runs out of lives. The program should then reveal the correct word.

---





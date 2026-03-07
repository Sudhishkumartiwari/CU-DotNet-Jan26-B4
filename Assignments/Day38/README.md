Problem Statement: The Vowel-Shift Cipher
Objective
Create a program that transforms a given lowercase string based on specific character-mapping rules. The goal is to obscure the original text by shifting both vowels and consonants to their subsequent characters in a predefined sequence.
Rules of Transformation
The program must process each character in the input string $s$ using the following logic:
1. Vowel Logic: * If the character is a vowel ($a, e, i, o, u$), replace it with the next vowel in the sequence.
o The sequence wraps around: If the character is '$u$', it should be replaced with '$a$'.
o Sequence: $a \rightarrow e, e \rightarrow i, i \rightarrow o, o \rightarrow u, u \rightarrow a$
2. Consonant Logic: * If the character is a consonant, replace it with the next character in the alphabet (e.g., $b \rightarrow c$).
o The Vowel Skip: If the resulting next character is a vowel, you must skip it and move to the very next character (e.g., if the consonant is '$d$', the next character '$e$' is a vowel, so it becomes '$f$').
Example Walkthrough
Input: "abcdu"
• 'a': Is a vowel. Next vowel is 'e'.
• 'b': Is a consonant. Next char is 'c' (not a vowel).
• 'c': Is a consonant. Next char is 'd' (not a vowel).
• 'd': Is a consonant. Next char is 'e' (vowel), so skip to 'f'.
• 'u': Is a vowel. Wrap around to 'a'.
Output: "ecdfa"
 
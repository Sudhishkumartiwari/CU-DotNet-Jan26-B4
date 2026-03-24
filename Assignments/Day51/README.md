You are developing a C# console application for StreamBuzz, a digital content platform that tracks creators' engagement over a period of 4 weeks. Each creator's name and weekly like counts are recorded using the CreatorStats class. 
Functionalities:
In class CreatorStats, implement the below-given public properties.

public static List<CreatorStats> EngagementBoard - In the code template, it is already provided.
In the class Program, implement the below-given methods.

 
In Program class, Main method,
1. Get the values from the user.
2.  Call the methods accordingly and display the result. 
3. When choice 1 is selected, the user should be prompted to input the CreatorName along with WeeklyLikes values for four weeks and print the message "Creator registered successfully".
4. When choice 2 is selected, the user should be prompted to input the likeThreshold , call the GetTopPostCounts method, and print the creators' names with their WeeklyLikes count as per the sample output. If the method returns an empty dictionary, display "No top-performing posts this week".
5. When choice 3 is selected print the message "Overall average weekly likes: <average>".
6. When choice 4, display "Logging off — Keep Creating with StreamBuzz!" and terminate the program.
7. In the Sample Input / Output provided, the highlighted text in bold corresponds to the input given by the user, and the remaining text represents the output.
 
Note:
Keep the method and class as public.
Please read the method rules clearly.
Do not use Environment.Exit() to terminate the program.
Do not change the given code template.
 
Sample Input/Output : 
1. Register Creator
2. Show Top Posts
3. Calculate Average Likes
4. Exit
Enter your choice:
1
Enter Creator Name:
Nicky
Enter weekly likes (Week 1 to 4):
1500
1600
1800
2000
Creator registered successfully

1. Register Creator
2. Show Top Posts
3. Calculate Average Likes
4. Exit
Enter your choice:
1
Enter Creator Name:
Roma
Enter weekly likes (Week 1 to 4):
800
1000
1300
1400
Creator registered successfully

1. Register Creator
2. Show Top Posts
3. Calculate Average Likes
4. Exit
Enter your choice:
2
Enter like threshold:
1400
Nicky - 4
Roma - 1

1. Register Creator
2. Show Top Posts
3. Calculate Average Likes
4. Exit
Enter your choice:
2
Enter like threshold:
5000
No top-performing posts this week

1. Register Creator
2. Show Top Posts
3. Calculate Average Likes
4. Exit
Enter your choice:
3
Overall average weekly likes: 1425

1. Register Creator
2. Show Top Posts
3. Calculate Average Likes
4. Exit
Enter your choice:
4
Logging off - Keep Creating with StreamBuzz!

Q) Make a collage management system which has the following function 

1. addStudent(string studentId, string subject, int marks) -> This function should add a entry for the student in with subject and marks. If student is already registered for that subject update entry only if marks are greater than the previous marks. 

2. removeStudent(string studentId) -> This function should remove respective student details 

3. topSubject(string subject) -> This function should return the topper of that subject. If there is an tie then display the students in the order they were inserted. 

4. result() -> This function should print all the student's average marks across all the subject. Sample Input: ADD S1 Math 80 ADD S2 Math 90 ADD S3 Math 90 ADD S1 Phy 90 TOP Math RESULT REMOVE S1 Sample Output: S2 90 S3 90 S1 85.00 S2 90.00 S3 90.00 


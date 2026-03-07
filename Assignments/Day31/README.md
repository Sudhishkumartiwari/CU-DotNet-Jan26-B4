✅ 1. Student Performance Analytics (LINQ to Objects)
Problem Statement:
Create a Student class with Id, Name, Class, Marks.
Write LINQ queries to:
• Get top 3 students by marks
• Group students by Class and calculate average marks
• List students who scored below class average
• Order students by Class then by Marks descending
Concepts: Where, OrderBy, GroupBy, Select, Aggregate
 
class Student
{
   public int Id;
   public string Name;
   public string Class;
   public int Marks;
}
 
var students = new List<Student>
{
   new Student{Id=1, Name="Amit", Class="10A", Marks=85},
   new Student{Id=2, Name="Neha", Class="10A", Marks=72},
   new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
   new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
   new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
};
 
✅ 2. Employee Salary Processing System
Problem Statement:
Create an Employee list with Id, Name, Department, Salary, JoinDate.
Use LINQ to:
• Get highest and lowest salary in each department
• Count employees per department
• Filter employees joined after 2020
• Project anonymous objects with Name and AnnualSalary
Concepts: GroupBy, Max, Min, Count, Select, Where
 
class Employee
{
   public int Id;
   public string Name;
   public string Dept;
   public double Salary;
   public DateTime JoinDate;
}
 
var employees = new List<Employee>
{
   new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
   new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
   new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
   new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
};
 
✅ 3. Product Inventory and Sales Query
Problem Statement:
Create Product and Sales collections.
• Product: Id, Name, Category, Price
• Sales: ProductId, QuantitySold
Use LINQ to:
• Join Products with Sales
• Calculate total revenue per product
• Get best-selling product
• List products with zero sales
Concepts: Join, GroupJoin, Sum, DefaultIfEmpty
 
class Product { public int Id; public string Name; public string Category; public double Price; }
class Sale { public int ProductId; public int Qty; }
 
var products = new List<Product>
{
   new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
   new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
   new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
};
 
var sales = new List<Sale>
{
   new Sale{ProductId=1, Qty=10},
   new Sale{ProductId=2, Qty=20}
};
 
✅ 4. Library Book Management System
Problem Statement:
Create Book objects with Title, Author, Genre, PublishedYear, Price.
Perform LINQ queries:
• Find books published after 2015
• Group by Genre and count books
• Get most expensive book per Genre
• Return distinct authors list
Concepts: Where, GroupBy, Distinct, OrderByDescending, FirstOrDefault
 
 
class Book { public string Title; public string Author; public string Genre; public int Year; public double Price; }
 
var books = new List<Book>
{
   new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
   new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
   new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
};
 
✅ 5. Customer Order Analysis
Problem Statement:
Create Customer and Order classes.
• Customer: Id, Name, City
• Order: OrderId, CustomerId, Amount, OrderDate
Use LINQ to:
• Get total order amount per customer
• List customers with no orders
• Get customers who spent above ₹50,000
• Sort customers by total spending
Concepts: Join, GroupJoin, Sum, OrderBy, SelectMany
 
class Customer { public int Id; public string Name; public string City; }
class Order { public int OrderId; public int CustomerId; public double Amount; }
 
var customers = new List<Customer>
{
   new Customer{Id=1, Name="Ajay", City="Delhi"},
   new Customer{Id=2, Name="Sunita", City="Mumbai"}
};
 
var orders = new List<Order>
{
   new Order{OrderId=1, CustomerId=1, Amount=20000},
   new Order{OrderId=2, CustomerId=1, Amount=40000}
};
 
✅ 6. Movie Streaming Platform Query System
Problem Statement:
Create a Movie class with Title, Genre, Rating, ReleaseYear.
LINQ tasks:
• Filter movies with rating > 8
• Group movies by Genre and get average rating
• Find latest movie per Genre
• Get top 5 highest-rated movies
Concepts: Where, GroupBy, Average, Take, OrderByDescending
 
 
 
class Movie { public string Title; public string Genre; public double Rating; public int Year; }
 
var movies = new List<Movie>
{
   new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
   new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
   new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
};
 
 
✅ 7. Bank Transaction Analyzer
Problem Statement:
Create Transaction class with AccountNumber, Amount, TransactionType (Credit/Debit), Date.
Use LINQ to:
• Calculate total balance per account
• List suspicious accounts with total debit > credit
• Group transactions by month
• Find highest transaction amount per account
Concepts: GroupBy, Sum, Max, Select, Where
 
class Transaction { public int Acc; public double Amount; public string Type; }
 
var transactions = new List<Transaction>
{
   new Transaction{Acc=101, Amount=5000, Type="Credit"},
   new Transaction{Acc=101, Amount=2000, Type="Debit"},
   new Transaction{Acc=102, Amount=10000, Type="Debit"}
};
 
✅ 8. E-Commerce Cart Processing
Problem Statement:
Create CartItem list with ProductName, Category, Price, Quantity.
LINQ tasks:
• Calculate total cart value
• Group by Category and total category cost
• Apply 10% discount for Electronics category
• Return cart summary DTO objects
Concepts: GroupBy, Select, Sum, Projection, Conditional logic in LINQ
 
class CartItem { public string Name; public string Category; public double Price; public int Qty; }
 
var cart = new List<CartItem>
{
   new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
   new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
};
 
✅ 9. Social Media User Analytics
Problem Statement:
Create User and Post classes.
• User: UserId, Name, Country
• Post: PostId, UserId, Likes, Comments
LINQ tasks:
• Get top users by total likes
• Group users by country
• List inactive users (no posts)
• Calculate average likes per post
Concepts: Join, GroupJoin, Sum, Average, SelectMany
 
class User { public int Id; public string Name; public string Country; }
class Post { public int UserId; public int Likes; }
 
var users = new List<User>
{
   new User{Id=1, Name="A", Country="India"},
   new User{Id=2, Name="B", Country="USA"}
};
 
var posts = new List<Post>
{
   new Post{UserId=1, Likes=100},
   new Post{UserId=1, Likes=50}
};
 
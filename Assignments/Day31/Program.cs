
namespace LINQ_Exercise
{
    class Student
    {
       public int Id;
       public string Name;
       public string Class;
       public int Marks;
    }

    class Employee
    {
      public int Id;
      public string Name;
      public string Dept;
      public double Salary;
      public DateTime JoinDate;
    }

    class Product 
    { 
        public int Id; 
        public string Name; 
        public string Category; 
        public double Price; 
    }
    class Sale 
    { 
        public int ProductId; 
        public int Qty; 
    }

    class Book 
    { 
        public string Title; 
        public string Author; 
        public string Genre; 
        public int Year; 
        public double Price; 
    }

    class Customer 
    { 
        public int Id; 
        public string Name; 
        public string City; 
    }
    class Order 
    { 
        public int OrderId; 
        public int CustomerId; 
        public double Amount; 
    }

    class Movie 
    { 
        public string Title; 
        public string Genre; 
        public double Rating; 
        public int Year; 
    }

    class Transaction 
    { 
        public int Acc; 
        public double Amount; 
        public string Type; 
    }

    class CartItem 
    { 
        public string Name; 
        public string Category; 
        public double Price; 
        public int Qty; 
    }

    class User 
    { 
        public int Id; 
        public string Name; 
        public string Country; 
    }
    class Post 
    { 
        public int UserId; 
        public int Likes; 
    }

    internal class LINQ_Exercise
    {
       public static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
           };
           
           var TopThreeStudents = students.OrderByDescending(s => s.Marks).Take(3);
           foreach(var v in TopThreeStudents)
            {
                Console.WriteLine($"{v.Name} - {v.Class} - {v.Marks}");
            }

           var Average_InClass = students.GroupBy(s => s.Class).Select(s => new {Class = s.Key , Avg = s.Average(s => s.Marks)});
           foreach(var v in Average_InClass)
            {
                Console.WriteLine(v);
            }

           var lessThanAverage = students.Where(s => s.Marks < (students.Where(x => x.Class == s.Class).Average(a => a.Marks)));
           foreach(var v in lessThanAverage)
            {
                Console.WriteLine($"{v.Name}-{v.Class}-{v.Marks}");
            }

           var SortedStudents = students.OrderBy(s => s.Class).ThenByDescending(s => s.Marks);
           foreach(var v in SortedStudents)
            {
                Console.WriteLine($"{v.Name}-{v.Class}-{v.Marks}");
            }


           //2.
           var employees = new List<Employee>
           {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
           };

           var DepartmnetWiseSalary = employees.GroupBy(e => e.Dept).Select(s => new { Dept = s.Key , MaxSalary = s.Max(e => e.Salary), MinSalary = s.Min(e => e.Salary)});
           foreach(var v in DepartmnetWiseSalary)
            {
                Console.WriteLine(v);
            }

            var EmployeeCount = employees.GroupBy(e => e.Dept).Select(s => new {Dept = s.Key , Count = s.Count()});
            foreach(var v in EmployeeCount)
            {
                Console.WriteLine(v);
            }

            var EmployeeJoinedAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
            foreach(var v in EmployeeJoinedAfter2020)
            {
                Console.WriteLine($"{v.Name} - {v.JoinDate}");
            }

            var ProjectAnonymousObjectNameWithSalary  = employees.Select(e => new { e.Name , AnnualSalary = e.Salary *12});
            foreach(var v in ProjectAnonymousObjectNameWithSalary)
            {
                Console.WriteLine($"{v.Name} - {v.AnnualSalary}");
            }

           //3.
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

           var JoinedData = products.Join(sales, o => o.Id , i => i.ProductId , (p,s) => new {p.Name , s.Qty });
           foreach(var j in JoinedData)
            {
                Console.WriteLine($"{j.Name}-{j.Qty}");
            }

            var TotalRevenuePerproduct = products.Join(sales, o => o.Id, i => i.ProductId , (p,s) => new { p.Name , Revenue = p.Price * s.Qty});
            foreach(var v in TotalRevenuePerproduct)
            {
                Console.WriteLine($"{v.Name} - {v.Revenue}");
            }

            var BestSellingProduct = products.Join(sales, o => o.Id, i => i.ProductId, (p, s) => new { p.Name, s.Qty }).OrderByDescending(p => p.Qty).First();
            Console.WriteLine($"{BestSellingProduct.Name}-{BestSellingProduct.Qty}");

            var ProductWithZeroSales = products.Join(sales, o => o.Id, i => i.ProductId, (p, s) => new { p.Name, s.Qty }).Where(p => p.Qty == 0).Select(p => p.Name);
            foreach(var v in ProductWithZeroSales)
            {
                Console.WriteLine(v);
            }

            //4.
           var books = new List<Book>
           {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
           };

            var PublishedAfter2015 = books.Where(b => b.Year > 2015);
            foreach(var v in PublishedAfter2015)
            {   
                Console.WriteLine($"{v.Title} - {v.Year}");
            }

            var BooksByGenere = books.GroupBy(b => b.Genre).Select(b => new{ Genre = b.Key , Count = b.Count()});
            foreach(var v in BooksByGenere){
                Console.WriteLine(v);
            }

            var ExpensiveBookByGenre = books.GroupBy(b => b.Genre).Select(b => new { Genre = b.Key , ExpensiveBook = b.OrderByDescending(b => b.Price).First()});
            foreach(var v in ExpensiveBookByGenre){
                Console.WriteLine($"{v.Genre} - {v.ExpensiveBook.Title} - {v.ExpensiveBook.Price}");
            }

            var AuthorList = books.Select(b => b.Author).Distinct();
            foreach(var v in AuthorList){
                Console.WriteLine(v);           
            }

           //5.
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

            var TotalAmountPerCustomer = customers.GroupJoin(orders , c => c.Id , o => o.CustomerId , (a,b) => new{a.Name ,Total =  b.Sum(o => o.Amount) } );
            foreach(var v in TotalAmountPerCustomer)
            {
                Console.WriteLine($"{v.Name} - {v.Total}");
            }

            var CustomerWithNoOrders = customers.GroupJoin(orders, c => c.Id, o => o.CustomerId, (c, o) => new { c.Name, Orders = o }).Where(c => !c.Orders.Any()).Select(c => c.Name);
            foreach(var v in CustomerWithNoOrders)
            {
                Console.WriteLine(v);
            }

            var NamePaidOver50000 = customers.GroupJoin(orders , c => c.Id , o => o.CustomerId , (a,b) => new{a.Name , Total =  b.Sum(o => o.Amount) }).Where(c => c.Total > 50000).Select(c => c.Name);
            foreach(var v in NamePaidOver50000)
            {
                Console.WriteLine(v);
            }

            var customerSorting = customers.GroupJoin(orders , c => c.Id , o => o.CustomerId , (a,b) => new{a.Name , Total =  b.Sum(o => o.Amount)}).OrderByDescending(c => c.Total);
            foreach(var v in customerSorting)
            {
                Console.WriteLine($"{v.Name} - {v.Total}");
            }

           //6.
           var movies = new List<Movie>
           {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
           };
 
           var RatingAbove8 = movies.Where(m => m.Rating > 8);
           foreach(var v in RatingAbove8)
            {
                Console.WriteLine($"{v.Title} - {v.Rating}");
            }

            var MoviesByGenre = movies.GroupBy(m => m.Genre).Select(g => new { Genre = g.Key, AverageRating = g.Average(m => m.Rating) });
            foreach(var v in MoviesByGenre)
            {
                Console.WriteLine($"{v.Genre} - {v.AverageRating}");
            }

            var LatestMovies = movies.GroupBy(m => m.Genre).Select(g => new { Genre = g.Key, LatestMovie = g.OrderByDescending(m => m.Year).First() });
            foreach(var v in LatestMovies)
            {
                Console.WriteLine($"{v.Genre} - {v.LatestMovie.Title} - {v.LatestMovie.Year}");
            }

            var Top5 = movies.OrderByDescending(m => m.Rating).Take(5);
            foreach(var v in Top5)
            {
                Console.WriteLine($"{v.Title} - {v.Rating}");
            }

           //7.
           var transactions = new List<Transaction>
           {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"}, 
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
           };

           var TotalBalancePerAccount = transactions.GroupBy(t => t.Acc).Select(g => new { Acc = g.Key, Balance = g.Where(t => t.Type == "Credit").Sum(t => t.Amount) - g.Where(t => t.Type == "Debit").Sum(t => t.Amount) });
           foreach(var v in TotalBalancePerAccount)
            {
                Console.WriteLine($"Account: {v.Acc} - Balance: {v.Balance}");
            }

            var DebitGreaterThanCredit = transactions.GroupBy(t => t.Acc).Select(g => new { Acc = g.Key, TotalDebit = g.Where(t => t.Type == "Debit").Sum(t => t.Amount), TotalCredit = g.Where(t => t.Type == "Credit").Sum(t => t.Amount) }).Where(a => a.TotalDebit > a.TotalCredit);
            foreach(var v in DebitGreaterThanCredit)
            {
                Console.WriteLine($"Account: {v.Acc} - Debit: {v.TotalDebit} - Credit: {v.TotalCredit}");
            }

            var HighestTransactionPerAccount = transactions.GroupBy(t => t.Acc).Select(g => new { Acc = g.Key, HighestTransaction = g.OrderByDescending(t => t.Amount).First() });
            foreach(var v in HighestTransactionPerAccount)
            {
                Console.WriteLine($"Account: {v.Acc} - Highest Transaction: {v.HighestTransaction.Amount} - Type: {v.HighestTransaction.Type}");
            }
            
           //8.
           var cart = new List<CartItem>
           {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
           };

           var TotalCost = cart.Sum(c => c.Price * c.Qty);
           Console.WriteLine($"Total Cost: {TotalCost}");

           var TotalCostPerCategory = cart.GroupBy(c => c.Category).Select(g => new { Category = g.Key, TotalCost = g.Sum(c => c.Price * c.Qty) });
           foreach(var v in TotalCostPerCategory)
            {
                Console.WriteLine($"Category: {v.Category} - Total Cost: {v.TotalCost}");
            }

            var Discount = cart.Where(c => c.Category == "Electronics").Select(c => new { c.Name, DiscountedPrice = c.Price * 0.9 });
            foreach(var v in Discount)
            {
                Console.WriteLine($"Product: {v.Name} - Discounted Price: {v.DiscountedPrice}");
            }

            var CartSummary = cart.Select(c => new { c.Name, c.Category, TotalPrice = c.Price * c.Qty });
            foreach(var v in CartSummary)
            {
                Console.WriteLine($"Product: {v.Name} - Category: {v.Category} - Total Price: {v.TotalPrice}");
            }

           // 9.
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

           var TopUsersByLikes = users.GroupJoin(posts, u => u.Id, p => p.UserId, (u, p) => new { u.Name, TotalLikes = p.Sum(post => post.Likes) }).OrderByDescending(u => u.TotalLikes).Take(5);
           foreach(var v in TopUsersByLikes)
            {
                Console.WriteLine($"User: {v.Name} - Total Likes: {v.TotalLikes}"); 
            }

            var UsersByCountry = users.GroupBy(u => u.Country).Select(g => new { Country = g.Key, Users = g.Select(u => u.Name) });
            foreach(var v in UsersByCountry)
            {
                Console.WriteLine($"Country: {v.Country} - Users: {string.Join(", ", v.Users)}");
            }

            var InactiveUsers = users.GroupJoin(posts, u => u.Id, p => p.UserId, (u, p) => new { u.Name, PostCount = p.Count() }).Where(u => u.PostCount == 0).Select(u => u.Name);
            foreach(var v in InactiveUsers)
            {
                Console.WriteLine($"Inactive User: {v}");
            }

            var AverageLikesPerPost = posts.Average(p => p.Likes);
            Console.WriteLine($"Average Likes per Post: {AverageLikesPerPost}");
 
        }
    } 
}

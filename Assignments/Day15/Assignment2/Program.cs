using System;

namespace first
{
    public class Order
    {
        private int _orderaId;
        private string _customerName;
        private int _totalAmount;
        private DateOnly _orderDate;

        private string _status;

        public int OrderId
        {
            get {return _orderaId; }
        }
        public string CustomerName
        {
            get {return _customerName;}
            set{
                if(!string.IsNullOrEmpty(value))
                   {
                      _customerName = value;
                   }
            }
        }
        public int TotalAmount
        {
            get {return _totalAmount;}
        }

        public Order(int Id , string name)
        {
            _orderaId = Id;
            _customerName = name;
            _orderDate = DateOnly.FromDateTime(DateTime.Now);
            _status = "NEW";
        }

        public void Additem(decimal amount)
        {
            _totalAmount += (int)amount;
        }

        public void AddDiscount(decimal discount)
        {
            _totalAmount -= _totalAmount * (int)discount/100;
        }

        public string getorderSummary()
        {
            return $"Order Id: {_orderaId},\nCustomer Name: {_customerName},\nTotal Amount: {_totalAmount}, \nOrder Date: {_orderDate},\nStatus: {_status}";
        }

        public static void Main(string[] args)
        {
            Order o = new Order(201 , "Hritik" );
            o.Additem(500);
            o.Additem(300);
            o.AddDiscount(10);
            Console.WriteLine( o.getorderSummary());
        }
    }
}

namespace SocialMediaApp
{
    class Person
    {
        public string? Name{get;set;}
        public int age {get;set;}
        public Person(string name) => Name = name;
        public List<Person> friends  = new List<Person>();

        // public void AddFiend(Person p)
        // {
        //     if (!friends.Contains(p))
        //     {
        //        friends.Add(p);
        //        p.friends.Add(this);
        //     }
        // }
    }

    class SocialNetwork
    {
        private List<Person> _Members = new List<Person>();

        public void AddMembers(Person member)
        {
            _Members.Add(member);
        }

        public void AddFriend(Person friend1 , Person friend2)
        {
            if(_Members.Contains(friend1) && _Members.Contains(friend2))
            {
                if (!friend1.friends.Contains(friend2))
                {
                     friend1.friends.Add(friend2);
                      friend2.friends.Add(friend1);
                }
            }
            else
            {
                Console.WriteLine($"{friend1.Name} and {friend2.Name} are not App users.");
            }
        }

        public void ShowNetwork()
        {
            foreach(var v in _Members)
            {
                Console.WriteLine($"{v.Name} :");
                List<string> end = new List<string>();
                foreach(var s in v.friends)
                {
                    end.Add($"{s.Name}");
                }
                Console.WriteLine("\t"+string.Join(",",end));
            }
        }
    }

    internal class App
    {
        public static void Main(string[] args)
        {
            SocialNetwork SN = new SocialNetwork();

            Person hritik = new Person("Hritik");
            Person aaroh = new Person("Aaroh");
            Person tushar = new Person("Tushar");
            Person mayank = new Person("Mayank");

            SN.AddMembers(hritik);
            SN.AddMembers(aaroh);
            SN.AddMembers(tushar);
            SN.AddMembers(mayank);

            SN.AddFriend(hritik,mayank);
            SN.AddFriend(mayank,tushar);
            SN.AddFriend(hritik,tushar);
            SN.AddFriend(tushar,aaroh);

            // hritik.AddFiend(aaroh);
            // hritik.AddFiend(tushar);
            // tushar.AddFiend(mayank);
            // tushar.AddFiend(aaroh);

            SN.ShowNetwork();
        }
    }
}

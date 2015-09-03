using System.Collections.Generic;

namespace Patterns.Strategy.OrderStrategy
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Id = {0}, Name = {1}", Id, Name);
        }

        public static void SortLists()
        {
            var list = new List<Employee>();

            list.Sort(new EmployeeByIdComparer());

            list.Sort((x,y) => x.Name.CompareTo(y.Name));

            var comparer = new EmployeeByIdComparer();

            var set = new SortedSet<Employee>(comparer);

            var comparer2 = ComparerFactory.Create<Employee>((x, y) => x.Id.CompareTo(y.Id));
            var set2 = new SortedSet<Employee>(comparer2);
        }
    }
}
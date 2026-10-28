namespace advancedAssignment03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 1: Student Grade Manager

            //1. Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65
            List<int> grades = new List<int>() { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades:");
            foreach (int grade in grades){
                Console.Write(grade + " ");
            }

            //2. Print the collection, Count, first and last grade
            Console.WriteLine("\nCount: " + grades.Count);
            Console.WriteLine("First grade: " + grades.First());
            Console.WriteLine("Last grade: " + grades.Last());

            #endregion


            Console.ReadLine();
        }
    }
}

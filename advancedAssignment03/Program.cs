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

            //3. Sort the grades ascending, then print
            grades.Sort();
            foreach (int grade in grades){
                Console.Write(grade + " ");
            }

            //4. Get the first grade above 90
            int firstAbove90 = grades.First(g => g > 90);
            Console.WriteLine("\nFirst grade above 90: " + firstAbove90);

            //5. Get all grades below 75
            List<int> below75 = grades.Where(g => g < 75).ToList();

            foreach (int grade in below75) { 
            Console.Write(grade + " ");
            }

            //6. Remove all failing grades (below 75)
            grades.RemoveAll(g => g < 75);

            foreach (int grade in grades)
            {
                Console.Write(grade + " ");
            }

            //7. Check if any grade equals 100
            bool check100 = grades.Any(g => g == 100);
            Console.WriteLine("\nhas any 100: " + check100);

            //8. Create a List<string> where each grade becomes "Grade: X"
            List<string> gradesString = grades.Select(g => "Grade:" + g).ToList();

            foreach (string grade in gradesString)
            {
                Console.Write(grade + " ");
            }

            #endregion

            Console.WriteLine("\n---------------------------------------------------");

            #region Exercise 2: Leaderboard

            SortedDictionary<int, string> leaderboard = new SortedDictionary<int, string>();

            //1. Add: 500="Ahmed", 200="Sara", 800="Ali", 350="Mona"
            leaderboard.Add(500, "Ahmed");
            leaderboard.Add(200, "Sara");
            leaderboard.Add(800, "Ali");
            leaderboard.Add(350, "Mona");

            //2. Print all entries (they should be sorted by score automatically)
            foreach (var player in leaderboard)
            {
                Console.WriteLine($"Score: {player.Key}, Name: {player.Value}");
            }

            //3. Access the first key and first value 
            Console.WriteLine("First Score: " + leaderboard.First().Key + " First Name: " + leaderboard.First().Value);

            //4. Check if score 500 exists
            Console.WriteLine("Score 500 exists: " + leaderboard.ContainsKey(500));

            //5. Safely get the player with score 999
            if (leaderboard.TryGetValue(999, out string player999))
            {
                Console.WriteLine("Player with score 999: " + player999);
            }else
            {
                Console.WriteLine("No player with score 999");
            }

            //6. Remove the player with score 200 and print the updated list
            leaderboard.Remove(200);

            foreach (var player in leaderboard)
            {
                Console.WriteLine($"Score: {player.Key}, Name: {player.Value}");
            }

            #endregion

            Console.WriteLine("\n---------------------------------------------------");

            #region Exercise 3: Phone Book

            // 1. Create a collection with 4 contacts
            Dictionary<string, string> contacts = new Dictionary<string, string>()
            {
                { "Ahmed", "01012345678" },
                { "Sara", "01112345678" },
                { "Ali", "01212345678" },
                { "Mona", "01512345678" }
            };

            // 2. Add a new contact using [] syntax (add or update)
            contacts["Omar"] = "01098765432"; //add
            contacts["Ahmed"] = "01055555555"; //update

            // 3. Try adding a duplicate using .Add() — catch the exception and print the error
            try
            {
                contacts.Add("Sara", "01011111111");
            }catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //4. adding a duplicate using TryAdd()
            bool added = contacts.TryAdd("Sara", "01011111111");
            Console.WriteLine("Added successfully: " + added); //doesnt accept duplicates

            //5. Search for a contact that doesn't exist
            bool exists = contacts.ContainsKey("Omar");
            Console.WriteLine("Omar exists: " + exists);

            //6. Get a contact with a fallback of "Not Found"
            Console.WriteLine("Omar's phone: " + contacts.GetValueOrDefault("Omar", "Not Found"));

            // 4. Print all Keys on one line
            Console.WriteLine("Keys: " + string.Join(", ", contacts.Keys));

            // Print all Values on another line
            Console.WriteLine("Values: " + string.Join(", ", contacts.Values));

            #endregion

            Console.WriteLine("\n---------------------------------------------------");

            #region Exercise 4: Unique Email Validator

            //1. Create a HashSet<string> with a case-insensitive comparer: new HashSet<string>(StringComparer.OrdinalIgnoreCase)

            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            emails.Add("Ahmed@test.com");
            emails.Add("Sara@test.com");

            Console.WriteLine(emails.Add("ahmed@test.com")); // false
            Console.WriteLine(emails.Add("AHMED@test.com")); // false
            Console.WriteLine(emails.Add("Omar@test.com"));  // true

            foreach (string name in emails)
            {
                Console.WriteLine(name);
            }

            //2. add emails
            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.com");

            //3. Print Count — how many are actually stored? Explain why.
            Console.WriteLine(emails.Count);
            // only stores 3 because others are just duplicates and its case insenstive also hashset doesnt accept duplicates

            //4. Create two sets
            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            //5. Print the result of: UnionWith, IntersectWith, ExceptWith
            HashSet<int> union = new HashSet<int>(setA);
            union.UnionWith(setB);
            Console.WriteLine("Union: " + string.Join(", ", union));
            HashSet<int> intersection = new HashSet<int>(setA);
            intersection.IntersectWith(setB);
            Console.WriteLine("Intersection: " + string.Join(", ", intersection));

            HashSet<int> difference = new HashSet<int>(setA);
            difference.ExceptWith(setB);
            Console.WriteLine("Difference: " + string.Join(", ", difference));

            HashSet<int> subset = new HashSet<int> { 1, 2 };
            Console.WriteLine("Is {1, 2} a subset of Set A? " + subset.IsSubsetOf(setA));

            #endregion

            Console.WriteLine("\n---------------------------------------------------");

            #region Exercise 5: Print Queue Simulator

            Queue<string> documents = new Queue<string>();

            documents.Enqueue("Report.pdf");
            documents.Enqueue("Invoice.pdf");
            documents.Enqueue("Letter.docx");
            documents.Enqueue("Resume.pdf");
            documents.Enqueue("Photo.jpg");

            // 1. Print queue contents and Count
            Console.WriteLine("Documents in the queue:");

            foreach (string document in documents)
            {
                Console.WriteLine(document);
            }
            Console.WriteLine(documents.Count);

            // 2. Use Peek to see which document will print next (without removing)
            Console.WriteLine("Next to print: " + documents.Peek());

            //3. Process the queue: Dequeue each document and print "Printing: [name]"
            while (documents.Count > 0)
            {
                string document = documents.Dequeue();
                Console.WriteLine("Printing: " + document);
            }

            //4. Try TryDequeue on the now-empty queue — what happens?
            bool success = documents.TryDequeue(out string nextDocument);
            Console.WriteLine("TryDequeue successful: " + success); //false, tries to remove item from queue but queue is empty

            #endregion

            Console.WriteLine("\n---------------------------------------------------");

            #region Exercise 6: Browser History (Undo)

            Stack<string> history = new Stack<string>();

            // 1. Push 5 URLs
            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            // 2. Peek at the current page (top of stack)
            Console.WriteLine("Current page: " + history.Peek());

            //3. Press "back" 3 times using Pop — print each page you leave
            for (int i = 0; i < 3; i++)
            {
                string page = history.Pop();
                Console.WriteLine("leaving page: " + page);
            }

            // 4. Print the current page after going back
            Console.WriteLine("Current page: " + history.Peek());

            // 5. TryPop on an empty stack
            history.Pop();
            history.Pop();
            bool popSuccess = history.TryPop(out string lastPage);
            Console.WriteLine("TryPop successful: " + popSuccess); //false, found no pages to remove

            #endregion
            Console.ReadLine();
        }
    }
}

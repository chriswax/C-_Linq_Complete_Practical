using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Practical
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Select Even Numbers--------------");
            linqInInt();
            Console.WriteLine("--------Sort Words by length, string type----------------");
            sortWord();
            Console.WriteLine("--------Union Operation---------------");
            unionOperation();
            Console.WriteLine("--------Intersect Operation-----------");
            intersectionOperation();
            Console.WriteLine("------------Distinct Operation----------------");
            distinctOperation();
            Console.WriteLine("-------------Except Operation-------------");
            exceptOperation();
            Console.WriteLine("-----------Filter Operation Where Word  == 3-----------------");
            filterOperation();
            Console.WriteLine("-----------Duo Filter Operation Where Word  == 3-----------------");
            duoFilterOperation();

            Console.WriteLine("-----------All Quantifiers Operation Where Word  == 3------------");
            allQuantifierOperation();
            Console.WriteLine("-----------Any Filter Operation----------------------------------");
            anyQuantifierOperation();
            Console.WriteLine("---------------Contains Filter Operation-------------------------");
            containQuantifierOperation();
            Console.WriteLine("---------------Projection Operation-------------------------");
            projectionOperation();
            Console.WriteLine("---------------sentence Projection Operation-------------------------");
            sentenceProjectionOperation();
            Console.WriteLine("---------------Zip Projection Operation-------------------------");
            zipProjectionOperation();
            Console.WriteLine("---------------Partition Operation-------------------------");
            partitioningOperation();
            Console.WriteLine("---------------Skip Operation-------------------------");
            skipPartitioningOperation();
            Console.WriteLine("---------------Take Operation-------------------------");
            takePartitioningOperation();   
            Console.WriteLine("---------------Partitioning Operation-------------------------");
            takeWhilePartitioningOperation();
            Console.WriteLine("--------------- Join  Operation-------------------------");
            joinOperation();
            Console.WriteLine("---------------Group  Operation-------------------------");
            groupOperation();
            Console.WriteLine("--------------- Generation Operation-------------------------");
            generationEmptyOperation();
            Console.WriteLine("--------------- Operation-------------------------");
            generationBoolOperation();
            Console.WriteLine("--------------- Generation  Bool Operation-------------------------");
            rangeOperation();
            Console.WriteLine("---------------Repeat Operation-------------------------");
            repeatOperation();
            Console.WriteLine("---------------Element Operation-------------------------");
            elementOperation();
            Console.WriteLine("--------------- Single Operation-------------------------");
            singleOperation();
            Console.WriteLine("---------------Concatenation of Tables Operation-------------------------");
            concatenationOperation();
            Console.WriteLine("--------------- Aggregate Operation-------------------------");
            aggregateOperation();
            Console.WriteLine("--------------- Find Ocuurrence of words Operation-------------------------");
            occurrenceOperation();
            Console.WriteLine("--------------- extract Only NumberFrom Text Operation-------------------------");
            extractOnlyNumberFromTexteOperation();
            Console.WriteLine("--------------- extract Only Letter From Text Operation-------------------------");
            extractOnlyLetterFromTexteOperation();
            Console.WriteLine("---------------extractNeitherLetterNorDigitFromText  Operation-------------------------");
            extractNeitherLetterNorDigitFromTextOperation();
            Console.WriteLine("---------------extractNeitherLetterNorDigitFromText  Operation-------------------------");
            splitDataFromFileIntoMultipleFilesOperation();
            Console.WriteLine("---------------extractSpecificFilesFromFolder  Operation-------------------------");
            extractSpecificFilesFromFolder();
            Console.WriteLine("---------------extractLargestFileFromFolder  Operation-------------------------");
            extractLargestFileFromFolder(); 
            Console.WriteLine("---------------extractNeitherLetterNorDigitFromText  Operation-------------------------");
            Console.WriteLine("---------------extractNeitherLetterNorDigitFromText  Operation-------------------------");

            Console.ReadKey();
        }
        static void linqInInt()
        {
            //Data Source
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            //Query Creation
            var numQuery = from num in numbers
                           where (num % 2 == 0)
                           select num;
            //Query Execution
            foreach (var num in numQuery)
            {
                Console.WriteLine(num);
            }
        }

        static void sortWord()
        {
            string[] words = { "the", "quick", "brown", "fox", "jumps" };
            var query = from word in words
                            //orderby word.Length
                            //orderby word.Substring(0, 1)
                        orderby word.Length, word.Substring(0, 1)
                        select word;
            foreach (var word in query)
            {
                Console.WriteLine(word);
            }
        }

        //create union operation
        static void unionOperation()
        {
            int[] list1 = { 1, 2, 3, 4 };
            int[] list2 = { 5, 6, 7 };

            var unionQuery = from union in list1.Union(list2)
                             select union;
            foreach (var item in unionQuery)
            {
                Console.WriteLine(item);
            }

        }

        //create Intersection operation
        static void intersectionOperation()
        {
            int[] list1 = { 1, 2, 3, 4, 5, 6 };
            int[] list2 = { 5, 6, 7, 8 };

            var intersectQuery = from intersect in list1.Intersect(list2)
                                 select intersect;
            foreach (var item in intersectQuery)
            {
                Console.WriteLine(item);
            }

        }

        //create Intersection operation
        static void distinctOperation()
        {
            int[] list1 = { 1, 2, 3, 3, 4, 5, 5 };

            var distinctQuery = from distinct in list1.Distinct()
                                select distinct;
            foreach (var item in distinctQuery)
            {
                Console.WriteLine(item);
            }
        }

        //create Except operation
        static void exceptOperation()
        {
            int[] list1 = { 1, 2, 3, 4, 5, 6 };
            int[] list2 = { 5, 6 };

            var exceptQuery = from except in list1.Except(list2)
                              select except;
            foreach (var item in exceptQuery)
            {
                Console.WriteLine(item);
            }
        }

        //create Filter words which the count is three operation
        static void filterOperation()
        {
            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            var query = from word in words
                        where word.Length == 3
                        select word;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        //create Filter further to extract word where the first word is f
        static void duoFilterOperation()
        {
            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            var query = from word in words
                        where word.Length == 3 && word.Substring(0, 1) == "f"
                        select word;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        //=============================================================
        //====================== Quantifier Operations (All, Any, Contain) ================

        //create Filter further to extract word where the first word is f
        static void allQuantifierOperation()
        {
            var Markets = new[]
            {
                new { MarketName = "Market A", Fruits = new string[] { "Kiwi", "Cherry", "Banana" } },
                new { MarketName = "Market B", Fruits = new string[] { "Melon", "Mango", "Olive" } },
                new { MarketName = "Market C", Fruits = new string[] { "Kiwi", "Apple", "Orange" } }
            };

            var names = from market in Markets
                        where market.Fruits.All(fruit => fruit.Length == 5)
                        select market.MarketName;


            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
        //create Filter further to extract word where the first word is f
        static void anyQuantifierOperation()
        {
            var Markets = new[]
            {
                new { MarketName = "Market A", Fruits = new string[] { "Kiwi", "Cherry", "Banana" } },
                new { MarketName = "Market B", Fruits = new string[] { "Melon", "Mango", "Olive" } },
                new { MarketName = "Market C", Fruits = new string[] { "Kiwi", "Apple", "Orange" } }
            };

            var names = from market in Markets
                        where market.Fruits.Any(fruit => fruit.StartsWith("O"))
                        select market.MarketName;


            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }

        //create Filter further to extract word where the first word is f
        static void containQuantifierOperation()
        {
            var Markets = new[]
            {
                new { MarketName = "Market A", Fruits = new string[] { "Kiwi", "Cherry", "Banana" } },
                new { MarketName = "Market B", Fruits = new string[] { "Melon", "Mango", "Olive" } },
                new { MarketName = "Market C", Fruits = new string[] { "Kiwi", "Apple", "Orange" } }
            };

            var names = from market in Markets
                        where market.Fruits.Contains("Kiwi")
                        select market.MarketName;


            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }

        /////==============================================
        ///Projection Operation- is the transformation of object into a new form
        static void projectionOperation()
        {
            var words = new string[] { "an", "apple", "a", "day" };
            var query = from word in words
                        select word.Substring(0,1);

            foreach (var word in query)
            {
                Console.WriteLine($"{word}");
            }
        }

        ///Projection Operation- is the transformation of object into a new form
        static void sentenceProjectionOperation()
        {
            var sentences = new string[] { "an apple a day", "the quik brown fox" };
            var query = from sentence in sentences
                        from word in sentence.Split(' ')
                        select word;

            foreach (var word in query)
            {
                Console.WriteLine($"{word}");
            }
        }

        ///Zip Projection Operation- is the transformation of object into a new form
        static void zipProjectionOperation()
        {
            var list1 = new int[] { 1, 2, 3, 4, 5, 6 };
            var list2 = new char[] {'A', 'B', 'C', 'D', 'E' };

            var query = Enumerable.Zip(list1, list2, (num, letter)=>num.ToString()+letter);

            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
        }

        ///partitioning is the transformation of object into a new form
        static void partitioningOperation()
        {
            var list = new char[] { 'A', 'B', 'C', 'D', 'E' };

            var query = list.Skip(3);

            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
        }

        ///partitioning is the transformation of object into a new form
        static void skipPartitioningOperation()
        {
            var list = new char[] { 'A', 'B', 'C', 'D', 'E' };

            var query = list.SkipWhile(i => i != 'C');

            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
        }
        ///partitioning is the transformation of object into a new form
        static void takePartitioningOperation()
        {
            var list = new char[] { 'A', 'B', 'C', 'D', 'E' };

            var query = list.Take(3);

            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
        }
        ///partitioning is the transformation of object into a new form
        static void takeWhilePartitioningOperation()
        {
            var list = new char[] { 'A', 'B', 'C', 'D', 'E' };

            var query = list.TakeWhile(i => i != 'C');

            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
        }
        

        //join Operation in LINQ, e.g joining of two tables
        static void joinOperation()
        {
            var products = new[]
            {
                new {ProductName="Cola", CategoryID=0},
                new {ProductName="Tea", CategoryID=0},
                new {ProductName="Apple", CategoryID=1},
                new {ProductName="Kiwi", CategoryID=1},
                new {ProductName="Carrot", CategoryID=2},
            };

            var categories = new[]
            {
                new {CategoryID=0, CategoryName="Beverage"},
                new {CategoryID=1, CategoryName="Fruit"},
                new {CategoryID=2, CategoryName="Vegetable"}
            };

            var query = from product in products
                        join category in categories on product.CategoryID equals category.CategoryID
                        select new {product.ProductName, category.CategoryName};

            foreach(var item in query)
            {
                Console.WriteLine(item.ProductName + ":" + item.CategoryName);
            }
        }


        //Grouping Operation in LINQ, e.g joining of two tables
        static void groupOperation()
        {
            var numbers = new[]
            {
                new {Number="One", Type="Odd"},
                new {Number="Two", Type="Even"},
                new {Number="Three", Type="Odd"},
                new {Number="Four", Type="Even"},
                new {Number="Five", Type="Odd"},
            };

            var query = from number in numbers
                        group number by number.Type into g
                        select new { Type = g.Key, Count = g.Count() };

            foreach(var item in query)
            {
                Console.WriteLine(item.Type + ":" +item.Count);
            }
        }


        
        //Generation with empty int Operation in LINQ,
        static void generationEmptyOperation()
        {
            var numbers = new int []{};

            foreach (int i in numbers.DefaultIfEmpty())
            {
                Console.WriteLine(i);
            }
        }

        
        //Generation with empty Bool Operation in LINQ,
        static void generationBoolOperation()
        {
            bool[] numbers = new bool[] { };

            foreach (bool i in numbers.DefaultIfEmpty())
            {
                Console.WriteLine(i);
            }
        }

        //range Operation in LINQ,
        static void rangeOperation()
        {
            var collection = Enumerable.Range(1, 5);


            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
        //repeat Operation in LINQ,
        static void repeatOperation()
        {
            var collection = Enumerable.Repeat("I love Programming with C#", 5);


            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        //Element Operation in LINQ,
        static void elementOperation()
        {
            int[] collection = new int[] { 10, 20, 30, 40, 50, 60 };

            // var item = collection.First();   // find first number in the list
            //var item = collection.FirstOrDefault();   // find first number in the list, if list is empty it displays 0
            //var item = collection.Last();   // find first number in the list
            //var item = collection.LastOrDefault();   // find last number in the list, if list is empty it displays 0
            var item = collection.ElementAt(3);   // find the fourth item in the list 0-3

            Console.WriteLine(item);

        }

        //Single Operation in LINQ,
        static void singleOperation()
        {
            string[] fruits = new string[] { "Apple", "Banana", "Kiwi", "Orange" };

            var item = fruits.Single(f => f.Length == 4);   // find a word that the length is 4

            Console.WriteLine(item);
        }



        //concatenation Operation in LINQ,
        static void concatenationOperation()
        {
            var cats = new[]
            {
                new{Name = "Barley", Age=8},
                new{Name = "Boots", Age=5},
                new{Name = "Whiskers", Age=2}
            };

            var dogs = new[]
           {
                new{Name = "Bounders", Age=3},
                new{Name = "Snoopy", Age=14},
                new{Name = "Fido", Age=9}
            };

            var concatCatsDogs = cats.Concat(dogs);

            foreach (var item in concatCatsDogs)
            {
                Console.WriteLine(item.Name + ":" + item.Age);
            }
         
        }

        
        //Aggregate Operation in LINQ,
        static void aggregateOperation()
        {
            var numbers = new int[] { 10, 20, 30, 30, 40, 50 };
            var min = numbers.Min();
            var max = numbers.Max();
            var sum = numbers.Sum();
            var average = numbers.Average();
            var count = numbers.Count();

            //checks where number is equal to 30 and count 
            var value = (from number in numbers
                        where number == 30
                        select number).Count();

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average : " + average);
            Console.WriteLine("Count : " + count);
            Console.WriteLine("Value : " + value);
        }
        //Find Occurrence Operation in LINQ,
        static void occurrenceOperation()
        {
           string text = "This is sample text, to check the occurrence of the word sample in this sample text! Thank you.";
            string searchTerm = "sample";

            string[] textArray = text.Split(new char[] { ' ', ',', '.'});

            var matchQuery = from word in textArray
                             where word.Equals(searchTerm)
                             select word;

            Console.WriteLine("Count of word 'Sample' = " + matchQuery.Count());
        }
        //extractOnlyNumberFromTexteOperation Operation in LINQ,
        static void extractOnlyNumberFromTexteOperation()
        {
            string text = "ABCD12-3-D-EF-467";

            var query = from ch in text
                        where char.IsDigit(ch)
                        select ch;

            foreach (var ch in query)
            {
                Console.WriteLine(ch);
            }
        }
        
        //extractOnlyLetterFromTexte Operation in LINQ,
        static void extractOnlyLetterFromTexteOperation()
        {
            string text = "ABCD12-3-D-EF-467";

            var query = from ch in text
                        where char.IsLetter(ch)
                        select ch;  

          foreach(var ch in query)
            {
                Console.WriteLine(ch);
            }
        }


        //extractNeitherLetterNorDigitFromText Operation in LINQ,
        static void extractNeitherLetterNorDigitFromTextOperation()
        {
            string text = "ABCD12-3-D-EF-467";

            var query = from ch in text
                        where (!char.IsLetter(ch) && !char.IsDigit(ch))
                        select ch;

            foreach (var ch in query)
            {
                Console.WriteLine(ch);
            }
        }

        //splitDataFromFileIntoMultipleFiles Operation in LINQ
        static void splitDataFromFileIntoMultipleFilesOperation()
        {
            string[] file_content = System.IO.File.ReadAllLines(@"C:\Users\chris\Documents\Citechs\Henry Class\practicals\all_number.txt");

            var even_numbers = from i in file_content
                               where Convert.ToInt32(i)%2 == 0
                               select i;
            var odd_numbers = from o in file_content
                              where Convert.ToInt32(o)%2 != 0
                              select o;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Users\chris\Documents\Citechs\Henry Class\practicals\even_number.txt"))
            {
                foreach(var i in even_numbers)
                {
                    sw.WriteLine(i);
                }
            }

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Users\chris\Documents\Citechs\Henry Class\practicals\odd_number.txt"))
            {
                foreach (var o in odd_numbers)
                {
                    sw.WriteLine(o);
                }
            }

        }

        //extractSpecificFilesFromFolder Operation in LINQ
        static void extractSpecificFilesFromFolder()
        {
            string Folder = @"C:\\Users\\chris\\Downloads";


            string[] fileList = System.IO.Directory.GetFiles(Folder);

            var fileQuery = from file in fileList
                            where System.IO.Path.GetExtension(file) == ".pdf"      //eg .mp4, .mp3, .txt, .doc, .docs, .xls
                            select file;

            foreach( var file in fileQuery)
            {
                Console.WriteLine(file);
            }

      

        }


        //extractLargestFileFromFolder Operation in LINQ
        static void extractLargestFileFromFolder()
        {
            string Folder = @"C:\\Users\\chris\\Downloads";

            var fileList = new System.IO.DirectoryInfo(Folder).GetFiles();

            var largestFile = (from file in fileList
                            orderby file.Length descending
                            select file).First();

           Console.WriteLine(largestFile.Name + " Size :" + largestFile.Length);



        }

    }
}

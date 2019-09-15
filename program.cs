using GenericList;
using System;
using System.Collections.Generic;

namespace csharptests
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(
                        "Generic List:1\r\n\r\n" +
                        "List With Enumerator:2\r\n\r\n" +
                        "List With Comparer:3\r\n\r\n" +
                        "Extensions:4");
                    int opt = Convert.ToInt16(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            GenericListRun();
                            break;
                        case 2:
                            GenericListEnumeratorRun();
                            break;
                        case 3:
                            GenericListComparerRun();
                            break;
                        case 4:
                            Extensions();
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please type an integer value");
                }
            }
        }

        static void Extensions()
        {
            // Calling first method - AddNObjectsToCollection
            var bookList = new List<Book>();
            bookList.AddNObjectsToCollection(4);

            foreach (Book b in bookList)
            {
                Console.WriteLine(b.CreatedTime.ToString());
            }
            // ========== OR ==========
            // Calling second method - GenerateSpecificNumberOfCollection
            var bookList2 = new List<Book>().GenerateSpecificNumberOfCollection(3);


            foreach (Book b in bookList2)
            {
                Console.WriteLine(b.CreatedTime.ToString());
            }


            System.Console.WriteLine("\nDone");
            Console.Read();
        }

        static void GenericListRun()
        {
            GenericList<int> list = new GenericList<int>();

            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }

            foreach (int i in list)
            {
                System.Console.Write(i + " ");
            }

            System.Console.WriteLine("\nDone");
            Console.Read();
        }

        static void GenericListEnumeratorRun()
        {
            List<User> cuslist = new List<User>();

            User cus1 = new User();
            cus1.Name = "Fatima";
            cus1.Age = 57;
            cuslist.Add(cus1);

            User cus2 = new User();
            cus2.Name = "Evangeline";
            cus2.Age = 52;
            cuslist.Add(cus2);

            User cus3 = new User();
            cus3.Name = "Damien";
            cus3.Age = 49;
            cuslist.Add(cus3);

            User cus4 = new User();
            cus4.Name = "Cameroon";
            cus4.Age = 55;
            cuslist.Add(cus4);

            User cus5 = new User();
            cus5.Name = "Babu";
            cus5.Age = 24;
            cuslist.Add(cus5);

            UserCollection cuscoll = new UserCollection(cuslist);

            Console.WriteLine("___Older users with enumerator___");

            UserEnumerator2 sen = new UserEnumerator2(cuslist);
            foreach (User cus in cuscoll.GetUserEnumerator2())
            {
                Console.WriteLine(cus.Name + "   " + cus.Age);
            }
            Console.WriteLine("");
            Console.WriteLine("___Younger users with enumerator___");
            foreach (User cus in cuscoll.GetUserEnumerator1())
            {
                Console.WriteLine(cus.Name + "   " + cus.Age);
            }
            Console.WriteLine("");

            Console.WriteLine("___Older User w/ enumarator______");
            foreach (User cus in cuslist)
            {
                if (cus.Age > 50)
                {
                    Console.WriteLine(cus.Name + "   " + cus.Age);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("___Younger User w/ enumarator___");
            foreach (User cus in cuslist)
            {
                if (cus.Age < 50)
                {
                    Console.WriteLine(cus.Name + "   " + cus.Age);
                }
            }

            System.Console.WriteLine("\nDone");
            Console.Read();
        }

        static void GenericListComparerRun()
        {
            //1st Overload
            List<Personel> cuslist1 = new List<Personel>();
            #region list1

            Personel cus1 = new Personel();
            cus1.Name = "Fatima";
            cus1.Age = 23;
            cuslist1.Add(cus1);

            Personel cus2 = new Personel();
            cus2.Name = "Evangeline";
            cus2.Age = 24;
            cuslist1.Add(cus2);

            Personel cus3 = new Personel();
            cus3.Name = "Damien";
            cus3.Age = 27;
            cuslist1.Add(cus3);

            Personel cus4 = new Personel();
            cus4.Name = "Cameroon";
            cus4.Age = 21;
            cuslist1.Add(cus4);

            Personel cus5 = new Personel();
            cus5.Name = "Babu";
            cus5.Age = 20;
            cuslist1.Add(cus5);

            #endregion

            Console.WriteLine("1. Default sort");
            cuslist1.Sort();
            foreach (Personel cus in cuslist1)
            {
                Console.WriteLine(cus.Name + " " + cus.Age);
            }

            System.Collections.Generic.
            //2nd Overload   
            List<Personel> cuslist2 = new List<Personel>();
            #region list2
            cus1 = new Personel();
            cus1.Name = "Tom";
            cus1.Age = 23;
            cuslist2.Add(cus1);

            cus2 = new Personel();
            cus2.Name = "Sanjay";
            cus2.Age = 24;
            cuslist2.Add(cus2);

            cus3 = new Personel();
            cus3.Name = "Mathew";
            cus3.Age = 27;
            cuslist2.Add(cus3);

            cus4 = new Personel();
            cus4.Name = "Nguyen";
            cus4.Age = 21;
            cuslist2.Add(cus4);

            cus5 = new Personel();
            cus5.Name = "Peter";
            cus5.Age = 20;
            cuslist2.Add(cus5);


            #endregion

            Console.WriteLine("\n2.1. Sort with \"Comparison\" Based on Name");
            Comparison<Personel> compnamedel = new Comparison<Personel>(Personel.ComparePersonelName);
            cuslist2.Sort(compnamedel);

            foreach (Personel emp in cuslist2)
            {
                Console.WriteLine(emp.Name + " " + emp.Age);
            }

            Console.WriteLine("\n2.2. Sort with \"Comparison\" Based on Age");
            Comparison<Personel> compagedel = new Comparison<Personel>(Personel.ComparePersonelAge);
            cuslist2.Sort(compagedel);

            foreach (Personel cus in cuslist2)
            {
                Console.WriteLine(cus.Name + " " + cus.Age);
            }





            //3rd Overload
            List<Personel> cuslist3 = new List<Personel>();

            #region list3

            cus1 = new Personel();
            cus1.Name = "Louise";
            cus1.Age = 23;
            cuslist3.Add(cus1);

            cus2 = new Personel();
            cus2.Name = "Katie";
            cus2.Age = 24;
            cuslist3.Add(cus2);

            cus3 = new Personel();
            cus3.Name = "Viru";
            cus3.Age = 27;
            cuslist3.Add(cus3);

            cus4 = new Personel();
            cus4.Name = "Satheesh";
            cus4.Age = 21;
            cuslist3.Add(cus4);

            cus5 = new Personel();
            cus5.Name = "Naveen";
            cus5.Age = 20;
            cuslist3.Add(cus5);

            #endregion


            Console.WriteLine("\n3. Sort with IComparer Based on Name");
            PersonelNameSort esort = new PersonelNameSort();
            cuslist3.Sort(esort);

            foreach (Personel cus in cuslist3)
            {
                Console.WriteLine(cus.Name + " " + cus.Age);
            }



            //4th Overload
            List<Personel> cuslist4 = new List<Personel>();

            #region list4


            cus1 = new Personel();
            cus1.Name = "George";
            cus1.Age = 23;
            cuslist4.Add(cus1);

            cus2 = new Personel();
            cus2.Name = "Bush";
            cus2.Age = 24;
            cuslist4.Add(cus2);

            cus3 = new Personel();
            cus3.Name = "John";
            cus3.Age = 27;
            cuslist4.Add(cus3);

            cus4 = new Personel();
            cus4.Name = "Kennedy";
            cus4.Age = 21;
            cuslist4.Add(cus4);

            cus5 = new Personel();
            cus5.Name = "Clinton";
            cus5.Age = 20;
            cuslist4.Add(cus5);
            #endregion


            Console.WriteLine("\n4. Sort with IComparer Based on Name within Range");
            PersonelNameSort esort4 = new PersonelNameSort();
            cuslist4.Sort(0, 3, esort4);
            foreach (Personel cus in cuslist4)
            {
                Console.WriteLine(cus.Name + " " + cus.Age);
            }



            //Sort using Anonymous method
            Console.WriteLine("\n5. Sort Using Anonymous methods");
            List<Personel> cuslist5 = new List<Personel>();

            #region list5


            cus1 = new Personel();
            cus1.Name = "Nicole";
            cus1.Age = 23;
            cuslist5.Add(cus1);

            cus2 = new Personel();
            cus2.Name = "Catherine";
            cus2.Age = 24;
            cuslist5.Add(cus2);

            cus3 = new Personel();
            cus3.Name = "Angelina";
            cus3.Age = 27;
            cuslist5.Add(cus3);

            cus4 = new Personel();
            cus4.Name = "Winslet";
            cus4.Age = 21;
            cuslist5.Add(cus4);

            cus5 = new Personel();
            cus5.Name = "Eva";
            cus5.Age = 20;
            cuslist5.Add(cus5);

            #endregion

            Console.WriteLine("\n5.1. Sort Based on Name");

            cuslist5.Sort(delegate (Personel c1, Personel c2)
            {
                return c1.Name.CompareTo(c2.Name);
            });
            foreach (Personel cus in cuslist5)
            {
                Console.WriteLine(cus.Name + " " + cus.Age);
            }

            Console.WriteLine("\n5.2. Sort Based on Age");

            cuslist5.Sort(delegate (Personel c1, Personel c2)
            {
                return c1.Age.CompareTo(c2.Age);
            });
            foreach (Personel cus in cuslist5)
            {
                Console.WriteLine(cus.Name + " " + cus.Age);
            }








            System.Console.WriteLine("\nDone");
            Console.Read();
        }
    }



}

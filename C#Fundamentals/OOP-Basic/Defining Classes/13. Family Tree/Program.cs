using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace _13.Family_Tree
{
    class Program
    {
        static void Main()
        {
            
            var listOfPeoples = new List<Person>();
            var name = Console.ReadLine();
            var person = new Person(name);
            listOfPeoples.Add(person);

            while (true)
            {
                var input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }

                if (input.IndexOf("-") == -1)
                {
                    var split = input.Split(' ').ToArray();
                    var pName = split[0] + " " + split[1];
                    DateTime date = DateTime.Parse(split[2]);
                    if (listOfPeoples.Any(x => x.Name == pName))
                    {
                        listOfPeoples.First(x => x.Name == pName).Birthdate = date;
                    }
                    else if (listOfPeoples.Any(x => x.Birthdate == date))
                    {
                        listOfPeoples.First(x => x.Birthdate == date).Name = pName;
                    }
                    else
                    {
                        var man = new Person(pName);
                        man.Birthdate = date;
                        listOfPeoples.Add(man);
                    }
                }
                else
                {
                    var split = Regex.Split(input, @" - ");
                    var parrent = split[0];
                    var child = split[1];
                    if (parrent.IndexOf("/") == -1)
                    {
                        
                        if (child.IndexOf("/") == -1)
                        {
                            Console.WriteLine($"Lqvo name - Dqsno name");
                            if (listOfPeoples.Any(x => x.Name == parrent))
                            {
                                if (listOfPeoples.Any(x => x.Name == child))
                                {
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                                else
                                {
                                    var newChild = new Person(split[1]);
                                    listOfPeoples.Add(newChild);
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                            }
                            else
                            {
                                if (listOfPeoples.Any(x => x.Name == child))
                                {
                                    var newParrent = new Person(parrent);
                                    listOfPeoples.Add(newParrent);
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                                else
                                {
                                    var newChild = new Person(split[1]);
                                    var newParrent = new Person(parrent);
                                    listOfPeoples.Add(newParrent);
                                    listOfPeoples.Add(newChild);
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                            }
                            
                        }
                        else//child is date parent is name
                        {
                            Console.WriteLine($"Lqvo name - Dqsno date");
                            if (listOfPeoples.Any(x => x.Name == parrent))
                            {
                                if (listOfPeoples.Any(x => x.Birthdate == DateTime.Parse(child)))
                                {
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                                else
                                {
                                    var newChild = new Person(DateTime.Parse(child));
                                    listOfPeoples.Add(newChild);
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                            }
                            else
                            {
                                if (listOfPeoples.Any(x => x.Birthdate == DateTime.Parse(child)))
                                {
                                    var newParrent = new Person(parrent);
                                    listOfPeoples.Add(newParrent);
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                                else
                                {
                                    var newChild = new Person(DateTime.Parse(child));
                                    var newParrent = new Person(parrent);
                                    listOfPeoples.Add(newParrent);
                                    listOfPeoples.Add(newChild);
                                    listOfPeoples.First(x => x.Name == parrent)
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Name == parrent));
                                }
                            }

                        }
                    }
                    else //parent - date
                    {
                        if (child.IndexOf("/") == -1)   //parent date child name
                        {
                            Console.WriteLine($"Lqvo date - Dqsno name");
                            if (listOfPeoples.Any(x => x.Birthdate == DateTime.Parse(parrent)))
                            {
                                if (listOfPeoples.Any(x => x.Name == child))
                                {
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                                else
                                {
                                    var newChild = new Person(child);
                                    listOfPeoples.Add(newChild);
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                            }
                            else //no parent date
                            {
                                if (listOfPeoples.Any(x => x.Name == child))
                                {
                                    var newParent = new Person(DateTime.Parse(parrent));
                                    listOfPeoples.Add(newParent);
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                                else
                                {
                                    var newParent = new Person(DateTime.Parse(parrent));
                                    listOfPeoples.Add(newParent);
                                    var newChild = new Person(child);
                                    listOfPeoples.Add(newChild);
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Name == child));
                                    listOfPeoples.First(x => x.Name == child)
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lqvo date - Dqsno date");
                            if (listOfPeoples.Any(x => x.Birthdate == DateTime.Parse(parrent)))
                            {
                                if (listOfPeoples.Any(x => x.Birthdate == DateTime.Parse(child)))
                                {
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                                else
                                {
                                    var newChild = new Person(DateTime.Parse(child));
                                    listOfPeoples.Add(newChild);
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                            }
                            else
                            {
                                if (listOfPeoples.Any(x => x.Birthdate == DateTime.Parse(child)))
                                {
                                    var newParent = new Person(DateTime.Parse(parrent));
                                    listOfPeoples.Add(newParent);
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                                else
                                {
                                    var newChild = new Person(DateTime.Parse(child));
                                    listOfPeoples.Add(newChild);
                                    var newParent = new Person(DateTime.Parse(parrent));
                                    listOfPeoples.Add(newParent);
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent))
                                        .AddChildren(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child)));
                                    listOfPeoples.First(x => x.Birthdate == DateTime.Parse(child))
                                        .AddParent(listOfPeoples.First(x => x.Birthdate == DateTime.Parse(parrent)));
                                }
                            }
                            
                        }
                    }
                    
                }
            }
            //--> end of While
            Console.WriteLine(person.ToString());
        }
    }
}

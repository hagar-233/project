using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp77
{
    internal class Program
    {//creat list 
     static List<task> tasks = new List<task>();
        /*menu*/
        static public void list() { 
            Console.WriteLine("--------------------");
            Console.WriteLine("Enter:1 to add task");
            Console.WriteLine("Enter:2 to delet task");
            Console.WriteLine("Enter:3 to view tasks ");
            Console.WriteLine("Enter:4 to modify task");
            Console.WriteLine("----------------------");

        }
        /*creat class*/
        class task
        {
            /*property description and time*/
            
            public string Description
            {
                get;
                set;
            }
            public TimeSpan Time
            {
                get;
                set;
            }
        }

        static void Main(string[] args)
        {/*numbder of choice*/
            int number;
            /*make sure valid data */
           do
           { 
           
             list();
               Console.Write("please enter your choice:");
               number = int.Parse(Console.ReadLine());
           /*switch of menu*/
              switch (number)
               {
                   case 1:
                       Addtask();
                      break;
                  case 2:
                      Delettask();
                       break;
                      case 3:
                     Viewtask();
                      break;
                    case 4:
                   Modifytask();
                        break;
                         default:
                        Console.WriteLine("Exit......");
                       return;

                }



            } while (number > 0);
        }
        /*method for add tasks*/
        static void Addtask()
        {
            while (true)
            {
                Console.WriteLine("please enter task (if you finish enter done)");
                string desc;
                /*make sure describtion not null*/
               do
              {/*make task*/
                   desc = Console.ReadLine();
               } while (desc == null);
                /*point to stop add task*/
                if (desc.ToLower().Trim() == "done")
                    break;
                Console.WriteLine("please enter time you want to finish task");
                /*make time for task*/
                int minute = int.Parse(Console.ReadLine());
                TimeSpan time =  TimeSpan.FromMinutes( minute);
                tasks.Add(new task { Description = desc, Time = time });


           }
        }
        /*method for view task*/
        static void Viewtask()
        {/*make sure list not empty*/
            if (tasks.Count == 0)
           {
                Console.WriteLine("no task to show");
            }
            else
            {
               for (int i = 0; i < tasks.Count; i++)
               {
                    Console.WriteLine("{0}:{1} {2}", i, tasks[i].Description, tasks[i].Time);
                }
           }

        }
        /*method for delete task*/
     static void Delettask()
        {
           
          /*indicate number of task to delet*/
            Console.WriteLine("delete one task:1  ");
            Console.WriteLine("delete all task:2  ");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                Viewtask();
                Console.WriteLine("please enter the number of the task to delete ");
                int index = int.Parse(Console.ReadLine());
                /*make sure index not out of range*/
                if (index > tasks.Count || index < 0)
                {
                    try
                    {
                        index = int.Parse(Console.ReadLine());

                    }
                    catch (OutOfMemoryException ex)
                    {
                        Console.WriteLine("exception:" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    tasks.RemoveAt(index);
                }
            }
           else if (number == 2)
            {
                tasks.Clear();
            }
            else
            {
                Console.WriteLine("invalid number");
            }
           
       }
        /*method for mosify task.....*/

        static void Modifytask()
        {
            Viewtask();
           Console.WriteLine("please enter task to modify it");
            /*add taks instade of last*/
            int indexmodify=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter task: ");
            /*add new task*/
            tasks[indexmodify].Description = Console.ReadLine();
            /*add time for task*/
           Console.WriteLine("please enter time you want to finish task");
            int minutemodify = int.Parse(Console.ReadLine());
            TimeSpan timemodify = TimeSpan.FromMinutes(minutemodify);
            tasks[indexmodify].Time= timemodify;
        }

       


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupPicker
{
    class Program
    {
        static List<string> studentList = new List<string>() {"Keith", "Aaron", "Matt", "Mitch",
        "Kris", "David", "Umar", "Ryan", "Colton", "Mac", "Lamond", "Mahmoud", "Nathan"};
        static Random rand = new Random();
        static void Main(string[] args)
        {
            string pickGroupSize;
            string repeat = "";
            int x = 0;

            do
            {
                Console.WriteLine("Group Picker: This program creates random groups of an inputed size.");
                do
                {
                    do
                    {
                        Console.WriteLine("Choose a positive integer value for the size of the groups.");
                        pickGroupSize = Console.ReadLine();
                    } while (!(Int32.TryParse(pickGroupSize, out x)));
                    if (x > (studentList.Count / 2))
                    {
                        Console.WriteLine("Pick a realistic number, you choose more than half of the class for one group size, prick.");
                        x = 0;
                    }
                } while (x < 1);
                PickGroup(studentList, x);
                x = 0;
                Console.WriteLine("Would you like to select new groups? y/n");
                repeat = Console.ReadLine();
            } while (repeat != "n");
        }
        public static void PickGroup(List<string> inputList, int groupSize)
        {
            List<string> currentGroupList = new List<string>();
            int groupNumber = 1;
            int extraGroupMemebers = inputList.Count % groupSize;
            Console.WriteLine("--------------------------");
            while (inputList.Count != 0)
            {
                int currentGroupSize = 0;
                Console.WriteLine("Group {0}:", groupNumber);
                if (extraGroupMemebers > inputList.Count / groupSize)
                {
                    groupSize += 2;
                }
                else if (extraGroupMemebers > 0) //if the group numbers don't evenly divide, the next group in line gets an extra member
                {
                    groupSize++;
                }
                while ((currentGroupSize < groupSize) && (inputList.Count != 0))
                {
                    int randomNumber = rand.Next(0, inputList.Count);
                    string currentStudent = inputList[randomNumber];
                    currentGroupList.Add(currentStudent);
                    inputList.RemoveAt(randomNumber);
                    if (currentGroupSize < groupSize)
                        Console.WriteLine(currentStudent);
                    currentGroupSize++;
                }
                if (extraGroupMemebers > 0)
                {
                    groupSize--;
                    extraGroupMemebers--;
                }
                groupNumber++;
            }
            Console.WriteLine("--------------------------");
            inputList.AddRange(currentGroupList); 
            currentGroupList.Clear();
        }
    }
}

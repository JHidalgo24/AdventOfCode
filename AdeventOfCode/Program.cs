using System;
using System.Xml.Schema;

namespace AdventOfCode
{
    class Program
    {
        public static void Main(string[] args)
        {
            DayFourPartOne();
        }

        public static void DayFourPartOne()
        {
            var textFile = File.ReadLines("dayFour.txt").ToList();
            var randNums = textFile[0];
            var subtractTotal = 0;
            var grandTotal = 0;
            textFile.RemoveAll(x => x == randNums);
            List<List<string>> horizontalArrays = new List<List<string>>();
            List<List<string>> verticalArrays = new List<List<string>>();
            
                //this gets the values of the horizontal array
                for (int i = 0; i <= 5; i++)
                {
                    var temp = textFile[i].Replace("  "," ").Replace(" ","-").Split('-').ToList();
                    horizontalArrays.Add(temp);

                }
                //this gets the values of the vertical arrays
                



            


        }
        public static void DayThreePartTwo()
        {
            List<string> mostList = new List<string>();
            List<string> leastList = new List<string>();
            var text = File.ReadLines("dayThree.txt").ToList();
            mostList = text.ToList();
            leastList = text.ToList();
            var oneInstances = 0;
            var zeroInstances = 0;
            //this loop will find the most common instance (Oxygen generator rating)
            for (int i = 0; i < 12; i++)
            {
                //figure out how many times 1 occurs at x[i]
                mostList.ForEach(x=> oneInstances += x[i] == '1' ? 1:0);
                //figure out how many times 0 occurs at x[i]
                mostList.ForEach(x=> zeroInstances += x[i] == '0' ? 1:0);
                
                //if instances of 0 and 1 equal the same keep the one with a one
                if (zeroInstances == oneInstances)
                {
                    mostList.RemoveAll(x => x[i] =='0');
                }
                //if instace of 1 is greater keep the one 
                else if (zeroInstances < oneInstances)
                {
                    mostList.RemoveAll(x => x[i] == '0');
                }
                //if instance of 0 is bigger keep the zero
                else if (zeroInstances > oneInstances)
                {
                    mostList.RemoveAll(x => x[i] == '1');
                }
                

                oneInstances = 0;
                zeroInstances = 0;

                Console.WriteLine($"There are {mostList.Count} left in the list");
            }
            
            //this loop will find the least common instance(CO2 Scrubber)

            for (int i = 0; i < 12; i++)
            {
                //figure out how many times 1 occurs at x[i]
                leastList.ForEach(x=> oneInstances += x[i] == '1' ? 1:0);
                //figure out how many times 0 occurs at x[i]
                leastList.ForEach(x=> zeroInstances += x[i] == '0' ? 1:0);
                
                //if instances of 0 and 1 equal the same keep the one with a zero
                if (zeroInstances == oneInstances)
                {
                    leastList.RemoveAll(x => x[i] =='1');
                }
                //if instace of 1 is greater keep the zero 
                else if (zeroInstances < oneInstances)
                {
                    leastList.RemoveAll(x => x[i] == '1');
                }
                //if instance of 0 is bigger keep the one
                else if (zeroInstances > oneInstances)
                {
                    leastList.RemoveAll(x => x[i] == '0');
                }

                oneInstances = 0;
                zeroInstances = 0;
                int total = 0;
                if (leastList.Count == 1)
                {
                    Console.Write($"The last value is: ");
                    Console.Write(Convert.ToInt32(leastList.First(), 2));
                    total = Convert.ToInt32(leastList.First(), 2) * Convert.ToInt32(mostList.First(), 2);
                }

                
                Console.WriteLine("The total is : "+total);


            }


        }
        public static void DayThreePartOne()
        {
            List<Int64> values = new List<Int64>();
            var text = File.ReadLines("dayThree.txt").ToList();
            text.ForEach(x=>values.Add(Int64.Parse(x)));
            int instanceOfZero = 0;
            int instanceOfOne = 0;
            string currentRow = "";
            string gamma = "";
            string epsilon = "";
            var valueLength = text[0].Length;
            for (int i = 0; i < 12; i++)
            {
                foreach (var value in text)
                {
                    char[] currentNum = value.ToCharArray();
                    if (currentNum[i] == '0')
                    {
                        instanceOfZero++;
                    }
                    else
                    {
                        instanceOfOne++;
                    }

                    currentRow += currentNum[0];
                }
                
                if (instanceOfOne > instanceOfZero)
                {
                    gamma += "1";
                    epsilon += "0";
                    
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                    
                }
                var gammaConv = Convert.ToInt32(gamma, 2);
                var epsilonConv = Convert.ToInt32(epsilon, 2);
                
                currentRow = "";
                instanceOfOne = 0;
                instanceOfZero = 0;
            }
            Console.WriteLine(epsilon);

        }
        public static void DayTwoPartOne()
        {
            var text = File.ReadLines("dayTwo.txt").ToList();
            int depth = 0;
            int horizontal = 0;
            foreach (var x in text)
            {
                string[] words = x.Split(" ");
                if (words[0].ToLower().Contains("down"))
                {
                    
                    depth+= Int32.Parse(words[1]);
                    Console.WriteLine($"moving {words[0]} {words[1]} depth is now at {depth}");
                }
                else if (words[0].ToLower().Contains("up"))
                {
                    depth-= Int32.Parse(words[1]);
                    Console.WriteLine($"moving {words[0]} {words[1]} depth is now at {depth}");
                }
                else if (words[0].ToLower().Contains("forward"))
                {
                    
                    horizontal+= Int32.Parse(words[1]);
                    Console.WriteLine($"moving {words[0]} {words[1]} Horizontal is now at {horizontal}");
                }
                else
                {
                    Console.WriteLine(words[0]);
                }
                
            }

            Console.WriteLine($"Horizontal:{horizontal} Depth:{depth}");
            Console.WriteLine(horizontal*depth);
            
        }
        public static void DayTwoPartTwo()
        {
            var text = File.ReadLines("dayTwo.txt").ToList();
            int depth = 0;
            int horizontal = 0;
            int aim = 0;
            
            //down increases aim by x
            //up decreases aim by x
            //forward increases horizontal by x
            //increases depth by aim * x

            foreach (var x in text)
            {
                string[] words = x.Split(" ");
                string action = words[0].ToLower();
                int currentValue = Int32.Parse(words[1]);
                Console.WriteLine($"Current action is: {action} {currentValue}");
                switch (action)
                {
                    case "down":
                        aim+= currentValue;
                        Console.WriteLine($"Aim: {aim}");
                        break;
                    case "up":
                        aim -= currentValue;
                        Console.WriteLine($"Aim: {aim}");
                        break;
                    case "forward":
                        horizontal += currentValue;
                        Console.WriteLine($"Depth changed to {depth} because {depth} + ()");
                        depth += (aim * currentValue);
                        break;
                }
            }
            
            Console.WriteLine($"End value = {depth * horizontal}");
            
        }

        public static void DayOnePartTwo()
        {
            var text = File.ReadLines("dayOne.txt").ToList();
            List<int> nums = new List<int>();
            text.ForEach(x => nums.Add(Int32.Parse(x)));
            int? firstsum = null;
            int? secondSum = 0;
            int increased = 0;
            while (nums.Any())
            {
                
                if (nums.Count > 3 || nums.Count % 3 == 0 )
                {
                    for (int i = 0; i < 3; i++)
                    {
                        secondSum += nums[i];
                        
                    }
                }
                else
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        secondSum += nums[i];
                    }
                }
                

                if (firstsum < secondSum)
                {
                    Console.WriteLine($"{firstsum} < {secondSum}");
                    increased++;
                }

                firstsum = secondSum;
                secondSum = 0;
                nums.Remove(nums[0]);
                

            }
            Console.WriteLine(increased);
        }
    }
}
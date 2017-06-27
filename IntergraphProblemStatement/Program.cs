using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergraphProblemStatement
{
    class IntergraphProblemStatement
    {
        static void Main(string[] args)
        {
            //array of data to be sorted
            string[] samples = {"P-100","PlantR.14.211","Z-101","212-1A-BR4","100-43-011","102-BS-493","100-42-012","PlantA.10.43","230-91-841",
                                   "511-A1-DB4","PlantQ-42-92","R_102","290-41-123","PlantB-91-12","234-12-123-2","218-QR-123","X-043"};
            //the list that will hold the string of data paired with a string representing its format
            //the data is stored in the key and the pattern is the value
            List<KeyValuePair<string, string>> collections = new List<KeyValuePair<string, string>>();
            //label used to label types of collections during output
            string label = "";

            //loop through the array of data to determine pattern of each and store in the list
            foreach (string str in samples)
            {
                collections.Add(new KeyValuePair<string, string>(str, identifyPattern(str)));
            }

            //loop through the list sorted by values (the patterns)
            foreach (KeyValuePair<string, string> output in collections.OrderBy(key => key.Value))
            {
                if (!output.Value.Equals(label))
                {
                    label = output.Value;
                    Console.WriteLine("\nFormat: " + label);
                    Console.WriteLine("------------");
                }
                Console.WriteLine(output.Key);
            }
            Console.ReadKey();
        }

        static string identifyPattern(string data)
        {
            string format = "";
            foreach (char temp in data)
            {
                //65-90 for uppercase,97-122 for lowercase,48-57 is numbers
                if (((int)temp >= 65 && (int)temp <= 90) || ((int)temp >= 97 && (int)temp <= 122))
                    format += "A";
                else if (((int)temp >= 48 && (int)temp <= 57))
                    format += "N";
                else
                    format += temp;
            }
            return format;
        }
    }
}
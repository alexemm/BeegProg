using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jotaro
{
    internal class Program
    {
        private static string _parameterName = "";

        private static void Main(string[] args)
        {
            var staaten = new List<Staat>();
            ReadFile(staaten);
        }

        public static void ReadFile(List<Staat> staaten)
        {
            var lines = File.ReadAllLines("inputTest1.txt");
            _parameterName = lines[0];
            var counter = 0;
            foreach (var line in lines.Skip(2)) //start with 3rd item
            {
                if (line[0] == '#')
                {
                    ++counter;
                    continue;
                }

                if (counter == 0)
                {
                    var newLine = Regex.Split(line, @"\s+");
                    staaten.Add(new Staat(newLine[0], int.Parse(newLine[1]), float.Parse(newLine[2]),
                        float.Parse(newLine[3])));
                }
                else
                {
                    var pos = line.IndexOf(':');
                    var firstCode = line.Substring(0, pos);
                    var otherCodes = line.Substring(pos + 1);
                    var newCodes = Regex.Split(otherCodes, @"\s+");
                    foreach (var code in newCodes.Skip(1))
                    {
                        staaten.Find(i => i.CountryCode.Equals(firstCode)).Neighbours.Add(code); //Add neighbours
                        staaten.Find(i => i.CountryCode.Equals(code)).Neighbours
                            .Add(firstCode); //bi-directional neighbours
                    }
                }
            }
        }
    }
}
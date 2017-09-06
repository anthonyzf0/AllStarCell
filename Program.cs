using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        private static Dictionary<char, String> list = new Dictionary<char, String>();
        private static List<String> cmd = new List<string>();

        static int tempValue = 1;

        static string store(String val)
        {
            tempValue++;

            char a = (tempValue + "")[0];

            list[a] = val;
            return a + "";
        } 

        static string cutAndStore(String val)
        {
            return store(val.Substring(0, 8));
        }

        static void replaceCmd(int index, String value)
        {

            cmd.RemoveAt(index - 1);
            cmd.RemoveAt(index - 1);

            cmd.Insert(index - 1, value);

        }

        static void Main(string[] args)
        {
            list['X'] = Console.ReadLine();
            list['Y'] = Console.ReadLine();
            list['Z'] = Console.ReadLine();
            
            while (true)
            {
                cmd = Console.ReadLine().Split(' ').ToList();

                cmd.Reverse();

                int checkNumber = 1;

                for (int i = 0; i < cmd.Count; i++)
                    if (cmd[i] == "")
                        cmd.RemoveAt(i);
                
                while (cmd.Count > 1)
                {
                    if (cmd[checkNumber].Length == 1)
                    {
                        checkNumber++;
                        continue;
                    }

                    switch (cmd[checkNumber].Substring(0,3))
                    {
                        case "DIV":

                            char index = cmd[checkNumber - 1][0];

                            String a = list[index].Substring(0, 4);
                            String b = list[index].Substring(4);

                            replaceCmd(checkNumber, "" + store(a + a + " and " + b + b + b.Length));

                            break;

                        case "ADD":

                            int n = Convert.ToInt32(cmd[checkNumber][3]+"");
                            index = cmd[checkNumber - 1][0];

                            string adjusted = list[index].Substring(0, n) + list[index];

                            replaceCmd(checkNumber, "" + cutAndStore(adjusted));
                            
                            break;

                        case "SUB":

                            n = Convert.ToInt32(cmd[checkNumber][3] + "");
                            index = cmd[checkNumber - 1][0];

                            adjusted = list[index].Substring(n);

                            List<char> extra = list[index].Substring(8 - n).ToCharArray().ToList();
                            extra.Sort();

                            adjusted += new String(extra.ToArray());

                            replaceCmd(checkNumber, "" + cutAndStore(adjusted));

                            break;

                        case "UNI":

                            char I1 = cmd[checkNumber - 1][0];
                            char I2 = cmd[checkNumber - 2][0];

                            cmd.RemoveAt(checkNumber - 1);

                            List<char> first = list[I1].Substring(4).ToCharArray().ToList();
                            List<char> seccond = list[I2].Substring(0, 4).ToCharArray().ToList();

                            first.Sort();
                            seccond.Sort();

                            adjusted = new String(first.ToArray()) + new String(seccond.ToArray());
                            replaceCmd(checkNumber-1, "" + cutAndStore(adjusted));

                            break;

                        case "INT":

                            I1 = cmd[checkNumber - 1][0];
                            I2 = cmd[checkNumber - 2][0];
                            
                            first = (list[I1].Substring(0, 2)+ list[I1].Substring(6)).ToCharArray().ToList();
                            seccond = (list[I2].Substring(0, 2) + list[I2].Substring(6)).ToCharArray().ToList();

                            first.Sort();
                            seccond.Sort();

                            cmd.RemoveAt(checkNumber - 1);

                            replaceCmd(checkNumber-1, "" + cutAndStore(new String(first.ToArray()) + new String(seccond.ToArray())));

                            break;

                        case "ALI":
                            
                            index = cmd[checkNumber - 1][0];
                            List<Char> chars = list[index].ToCharArray().ToList();

                            chars.Sort();
                            chars.Reverse();

                            replaceCmd(checkNumber, store(new string(chars.ToArray())));
                            
                            break;

                    }
                }

                Console.WriteLine(list[cmd[0][0]]);
            }

        }
    }
}

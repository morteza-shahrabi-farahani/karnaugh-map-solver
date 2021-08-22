using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace homework5dl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number of variables that should be between 2 and 6");
            int n;
            int hold;
            n = int.Parse(Console.ReadLine());
            String line;
            int[] minterms;
            int j = 0;
            List<int> holder = new List<int>();
            string binary = "";
            List<string> binaryMinterms = new List<string>();
            List<string> secondMinterms = new List<string>();
            List<string> thirdMinterms = new List<string>();
            List<string> forthMinterms = new List<string>();
            List<string> fifthMinterms = new List<string>();
            int differences = 0;
            char[] temp = new char[n];
            char[] temp2 = new char[n];
            char[] save = new char[n];
            Console.WriteLine("Please eneter minterms");
            line = Console.ReadLine();
            minterms = Array.ConvertAll(line.Split(","), int.Parse);
            Array.Sort(minterms);
            for (int i = 0; i < minterms.Length; i++)
            {
                holder.Clear();
                binary = "";
                hold = minterms[i];
                while (hold > 0)
                {
                    holder.Add(hold % 2);
                    hold = hold / 2;
                    j++;
                }
                for (j = 0; holder.Count < n; j++)
                {
                    holder.Add(0);
                }
                holder.Reverse();
                for (j = 0; j < holder.Count; j++)
                {
                    binary += holder[j].ToString();
                }
                binaryMinterms.Add(binary);
            }
            for (int i = 0; i < binaryMinterms.Count; i++)
            {
                //Console.WriteLine(binaryMinterms[i]);
            }
            for (int i = 0; i < binaryMinterms.Count - 1; i++)
            {
                differences = 0;
                temp = binaryMinterms[i].ToCharArray();
                //Console.WriteLine(temp);
                for (j = 1; j < binaryMinterms.Count; j++)
                {
                    differences = 0;
                    temp2 = binaryMinterms[j].ToCharArray();
                    for (int z = 0; z < n; z++)
                    {
                        //Console.WriteLine(temp[z] + " " + temp2[z]);
                        //Console.WriteLine("diff " + differences);
                        if (temp[z] != temp2[z])
                        {
                            differences++;
                        }
                        //Console.WriteLine("diff " + differences);
                    }
                    if (differences == 1)
                    {
                        for (int z = 0; z < n; z++)
                        {
                            if (temp[z] != temp2[z])
                            {
                                save[z] = '-';
                            }
                            else if (temp[z] == temp2[z])
                            {
                                save[z] = temp[z];
                            }
                        }
                        if (secondMinterms.Count == 0)
                        {
                            secondMinterms.Add(new string(save));
                        }
                        else
                        {
                            bool flag = false;
                            for (int z = 0; z < secondMinterms.Count; z++)
                            {
                                if (new string(save) == secondMinterms[z])
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag == false)
                            {
                                secondMinterms.Add(new string(save));
                            }
                        }

                    }
                }
            }
            if (secondMinterms.Count != 0)
            {
                differences = 0;
                for (int i = 0; i < secondMinterms.Count - 1; i++)
                {
                    differences = 0;
                    for (j = 1; j < secondMinterms.Count; j++)
                    {
                        differences = 0;
                        temp = secondMinterms[i].ToCharArray();
                        temp2 = secondMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] == temp2[z] && temp2[z] == '-')
                            {
                                for (int d = 0; d < temp.Length; d++)
                                {
                                    if (temp[d] != temp2[d])
                                    {
                                        differences++;
                                    }
                                }
                                if (differences == 1)
                                {
                                    for (int d = 0; d < temp.Length; d++)
                                    {
                                        if (temp[d] != temp2[d])
                                        {
                                            save[d] = '-';
                                        }
                                        else
                                        {
                                            save[d] = temp[d];
                                        }
                                    }
                                    if (thirdMinterms.Count == 0)
                                    {
                                        thirdMinterms.Add(new string(save));
                                    }
                                    else
                                    {
                                        bool flag = false;
                                        for (int g = 0; g < thirdMinterms.Count; g++)
                                        {
                                            if (new string(save) == thirdMinterms[g])
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag == false)
                                        {
                                            thirdMinterms.Add(new string(save));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //4'th level
            if (thirdMinterms.Count != 0)
            {
                differences = 0;
                for (int i = 0; i < thirdMinterms.Count - 1; i++)
                {
                    differences = 0;
                    for (j = 1; j < thirdMinterms.Count; j++)
                    {
                        bool first = false;
                        bool second = false;
                        differences = 0;
                        temp = thirdMinterms[i].ToCharArray();
                        temp2 = thirdMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] == temp2[z] && temp2[z] == '-')
                            {
                                for (int d = z + 1; d < temp.Length; d++)
                                {
                                    if (temp[d] == temp2[d] && temp2[d] == '-')
                                    {
                                        for (int p = 0; p < temp.Length; p++)
                                        {
                                            if (temp[p] != temp2[p])
                                            {
                                                differences++;
                                            }
                                        }
                                    }
                                }
                                if (differences == 1)
                                {
                                    for (int d = 0; d < temp.Length; d++)
                                    {
                                        if (temp[d] != temp2[d])
                                        {
                                            save[d] = '-';
                                        }
                                        else
                                        {
                                            save[d] = temp[d];
                                        }
                                    }
                                    if (forthMinterms.Count == 0)
                                    {
                                        forthMinterms.Add(new string(save));
                                    }
                                    else
                                    {
                                        bool flag = false;
                                        for (int g = 0; g < forthMinterms.Count; g++)
                                        {
                                            if (new string(save) == forthMinterms[g])
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag == false)
                                        {
                                            forthMinterms.Add(new string(save));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //5'th level
            if (forthMinterms.Count != 0)
            {
                differences = 0;
                for (int i = 0; i < forthMinterms.Count - 1; i++)
                {
                    differences = 0;
                    for (j = 1; j < forthMinterms.Count; j++)
                    {
                        bool first = false;
                        bool second = false;
                        bool third = false;
                        differences = 0;
                        temp = forthMinterms[i].ToCharArray();
                        temp2 = forthMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] == temp2[z] && temp2[z] == '-')
                            {
                                for (int d = z + 1; d < temp.Length; d++)
                                {
                                    for (int u = d + 1; u < temp.Length; u++)
                                    {
                                        if (temp[u] == temp2[u] && temp2[u] == '-')
                                        {
                                            for (int p = 0; p < temp.Length; p++)
                                            {
                                                if (temp[p] != temp2[p])
                                                {
                                                    differences++;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (differences == 1)
                                {
                                    for (int d = 0; d < temp.Length; d++)
                                    {
                                        if (temp[d] != temp2[d])
                                        {
                                            save[d] = '-';
                                        }
                                        else
                                        {
                                            save[d] = temp[d];
                                        }
                                    }
                                    if (fifthMinterms.Count == 0)
                                    {
                                        fifthMinterms.Add(new string(save));
                                    }
                                    else
                                    {
                                        bool flag = false;
                                        for (int g = 0; g < fifthMinterms.Count; g++)
                                        {
                                            if (new string(save) == fifthMinterms[g])
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag == false)
                                        {
                                            fifthMinterms.Add(new string(save));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (fifthMinterms.Count != 0)
            {
                for (int i = 0; i < fifthMinterms.Count; i++)
                {
                    temp = fifthMinterms[i].ToCharArray();
                    for (j = 0; j < forthMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = forthMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            forthMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }


                    for (j = 0; j < thirdMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = thirdMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            thirdMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }

                    for (j = 0; j < secondMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = secondMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            secondMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }

                    for (j = 0; j < binaryMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = binaryMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            binaryMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }


                }
            }

            if (forthMinterms.Count != 0)
            {
                for (int i = 0; i < forthMinterms.Count; i++)
                {
                    temp = forthMinterms[i].ToCharArray();

                    for (j = 0; j < thirdMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = thirdMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            thirdMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }

                    for (j = 0; j < secondMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = secondMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            secondMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }

                    for (j = 0; j < binaryMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = binaryMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            binaryMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }
                }
            }

            if (thirdMinterms.Count != 0)
            {

                for (int i = 0; i < thirdMinterms.Count; i++)
                {
                    temp = thirdMinterms[i].ToCharArray();
                    for (j = 0; j < secondMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = secondMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            secondMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }

                    for (j = 0; j < binaryMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = binaryMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            binaryMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }


                }
            }

            if (secondMinterms.Count != 0)
            {
                for (int i = 0; i < secondMinterms.Count; i++)
                {
                    temp = secondMinterms[i].ToCharArray();

                    for (j = 0; j < binaryMinterms.Count; j++)
                    {
                        bool same = true;
                        temp2 = binaryMinterms[j].ToCharArray();
                        for (int z = 0; z < temp.Length; z++)
                        {
                            if (temp[z] != '-')
                            {
                                if (temp[z] != temp2[z])
                                {
                                    same = false;
                                    break;
                                }
                            }
                        }
                        if (same)
                        {
                            binaryMinterms.Remove(new string(temp2));
                            j--;
                        }
                    }


                }
            }

            for (int i = 0; i < fifthMinterms.Count; i++)
            {
                string result = "";
                temp = fifthMinterms[i].ToCharArray();
                for (int z = 0; z < temp.Length; z++)
                {
                    if (z == 0)
                    {
                        if (temp[z] == '1')
                        {
                            result += "A";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "A'";
                        }
                    }
                    if (z == 1)
                    {
                        if (temp[z] == '1')
                        {
                            result += "B";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "B'";
                        }
                    }
                    if (z == 2)
                    {
                        if (temp[z] == '1')
                        {
                            result += "C";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "C'";
                        }
                    }
                    if (z == 3)
                    {
                        if (temp[z] == '1')
                        {
                            result += "D";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "D'";
                        }
                    }
                    if (z == 4)
                    {
                        if (temp[z] == '1')
                        {
                            result += "E";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "E'";
                        }
                    }
                    if (z == 5)
                    {
                        if (temp[z] == '1')
                        {
                            result += "F";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "F'";
                        }
                    }
                }
                Console.WriteLine(result);
            }

            for (int i = 0; i < forthMinterms.Count; i++)
            {
                string result = "";
                temp = forthMinterms[i].ToCharArray();
                for (int z = 0; z < temp.Length; z++)
                {
                    if (z == 0)
                    {
                        if (temp[z] == '1')
                        {
                            result += "A";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "A'";
                        }
                    }
                    if (z == 1)
                    {
                        if (temp[z] == '1')
                        {
                            result += "B";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "B'";
                        }
                    }
                    if (z == 2)
                    {
                        if (temp[z] == '1')
                        {
                            result += "C";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "C'";
                        }
                    }
                    if (z == 3)
                    {
                        if (temp[z] == '1')
                        {
                            result += "D";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "D'";
                        }
                    }
                    if (z == 4)
                    {
                        if (temp[z] == '1')
                        {
                            result += "E";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "E'";
                        }
                    }
                    if (z == 5)
                    {
                        if (temp[z] == '1')
                        {
                            result += "F";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "F'";
                        }
                    }
                }
                Console.WriteLine(result);
            }
            for (int i = 0; i < thirdMinterms.Count; i++)
            {
                string result = "";
                temp = thirdMinterms[i].ToCharArray();
                for (int z = 0; z < temp.Length; z++)
                {
                    if (z == 0)
                    {
                        if (temp[z] == '1')
                        {
                            result += "A";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "A'";
                        }
                    }
                    if (z == 1)
                    {
                        if (temp[z] == '1')
                        {
                            result += "B";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "B'";
                        }
                    }
                    if (z == 2)
                    {
                        if (temp[z] == '1')
                        {
                            result += "C";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "C'";
                        }
                    }
                    if (z == 3)
                    {
                        if (temp[z] == '1')
                        {
                            result += "D";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "D'";
                        }
                    }
                    if (z == 4)
                    {
                        if (temp[z] == '1')
                        {
                            result += "E";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "E'";
                        }
                    }
                    if (z == 5)
                    {
                        if (temp[z] == '1')
                        {
                            result += "F";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "F'";
                        }
                    }
                }
                Console.WriteLine(result);
            }

            for (int i = 0; i < secondMinterms.Count; i++)
            {
                string result = "";
                temp = secondMinterms[i].ToCharArray();
                for (int z = 0; z < temp.Length; z++)
                {
                    if (z == 0)
                    {
                        if (temp[z] == '1')
                        {
                            result += "A";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "A'";
                        }
                    }
                    if (z == 1)
                    {
                        if (temp[z] == '1')
                        {
                            result += "B";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "B'";
                        }
                    }
                    if (z == 2)
                    {
                        if (temp[z] == '1')
                        {
                            result += "C";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "C'";
                        }
                    }
                    if (z == 3)
                    {
                        if (temp[z] == '1')
                        {
                            result += "D";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "D'";
                        }
                    }
                    if (z == 4)
                    {
                        if (temp[z] == '1')
                        {
                            result += "E";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "E'";
                        }
                    }
                    if (z == 5)
                    {
                        if (temp[z] == '1')
                        {
                            result += "F";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "F'";
                        }
                    }
                }
                Console.WriteLine(result);
            }

            for (int i = 0; i < binaryMinterms.Count; i++)
            {
                string result = "";
                temp = binaryMinterms[i].ToCharArray();
                for (int z = 0; z < temp.Length; z++)
                {
                    if (z == 0)
                    {
                        if (temp[z] == '1')
                        {
                            result += "A";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "A'";
                        }
                    }
                    if (z == 1)
                    {
                        if (temp[z] == '1')
                        {
                            result += "B";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "B'";
                        }
                    }
                    if (z == 2)
                    {
                        if (temp[z] == '1')
                        {
                            result += "C";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "C'";
                        }
                    }
                    if (z == 3)
                    {
                        if (temp[z] == '1')
                        {
                            result += "D";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "D'";
                        }
                    }
                    if (z == 4)
                    {
                        if (temp[z] == '1')
                        {
                            result += "E";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "E'";
                        }
                    }
                    if (z == 5)
                    {
                        if (temp[z] == '1')
                        {
                            result += "F";
                        }
                        else if (temp[z] == '0')
                        {
                            result += "F'";
                        }
                    }
                }
                Console.WriteLine(result);
            }
        }
    }
}

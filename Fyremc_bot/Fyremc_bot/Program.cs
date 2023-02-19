using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

using WindowsInput;
using WindowsInput.Native;

namespace Fyremc_bot
{
    class Program
    {

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        public static void Main()
        {
            
            Writer();
        }

        public static void Writer()
        {
            Process[] ps = Process.GetProcessesByName("javaw");
            Process p = ps?.FirstOrDefault();
            if (p != null)
            {

                Console.WriteLine("Found a running Minecraft");

                Console.WriteLine("Bringing the app on focus...");
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);


                InputSimulator isim = new InputSimulator();
                Random rnd = new Random();


                Thread.Sleep(2000);
                Console.WriteLine("Turning Game Menu off...");
                isim.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);




                string path = Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\AppData\Local\fyremc-client\app-0.8.9\logs\latest.log");
                string path2 = Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\AppData\Roaming\.minecraft\logs\latest.log");
                string txt_words = @"..\..\szavak.txt";
                string[] words = File.ReadAllLines(@"../../alap.txt");
                string[] words_without = File.ReadAllLines(@"../../beturend.txt");


                using (var fs = new FileStream(path2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs, System.Text.Encoding.ASCII))
                {
                    string line;
                    string last;
                    string z;
                    string r;
                    int answer;

                    string word;
                    bool right = false;
                    int tries = 0;
                    string word_abc1;
                    char[] char1;

                    while (true)
                    {
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            if (sr.Peek() == -1)
                            {

                                if (line.Contains("[J") && line.Contains("k]") && line.Contains("sold le: "))
                                {

                                    Console.WriteLine(line);
                                    List<string> result = line.Split(new char[] { ' ' }).ToList();
                                    last = result.Last();
                                    Console.WriteLine(last);

                                    Thread.Sleep(rnd.Next(2000, 2200));

                                    isim.Keyboard.KeyPress(VirtualKeyCode.VK_T);

                                    Thread.Sleep(rnd.Next(100, 150));

                                    for (int i = 0; i < last.Length; i++)
                                    {
                                        isim.Keyboard.TextEntry(last[i]);
                                        Thread.Sleep(rnd.Next(50, 100));
                                    }

                                    isim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                                    Thread.Sleep(5000);

                                   

                                }
                                else if (line.Contains("[J") && line.Contains("k]") && line.Contains("mold ki: "))
                                {

                                    DataTable dt = new DataTable();
                                    z = line.Replace(" ", "");
                                    r = z.Substring(z.Length + ((z.LastIndexOf(":") + 1) - z.Length));
                                    answer = (int)dt.Compute(r, "");

                                    Console.WriteLine(z);
                                    Console.WriteLine(answer);


                                    Thread.Sleep(rnd.Next(2700, 3000));

                                    isim.Keyboard.KeyPress(VirtualKeyCode.VK_T);

                                    Thread.Sleep(rnd.Next(100, 150));

                                    for (int i = 0; i < answer.ToString().Length; i++)
                                    {
                                        isim.Keyboard.TextEntry(answer.ToString()[i]);
                                        Thread.Sleep(rnd.Next(50, 100));
                                    }

                                    isim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                                    Thread.Sleep(5000);

                                    


                                }

                                else if (line.Contains("[J") && line.Contains("k]") && line.Contains("ld ki: "))
                                {

                                    z = line.Replace(" ", "");
                                    word = z.Substring(z.Length + ((z.LastIndexOf(":") + 1) - z.Length)).ToLower();

                                    Console.WriteLine(line);
                                    Console.WriteLine(word);

                                    right = false;

                                    try
                                    {
                                        while (right == false)
                                        {
                                            char1 = word.ToCharArray();
                                            Array.Sort(char1);
                                            word_abc1 = string.Join("", char1);
                                            Console.WriteLine(word_abc1);


                                            if (word_abc1.Contains(words_without[tries]) == true)
                                            {
                                                Console.WriteLine("Right");
                                                Thread.Sleep(rnd.Next(2400, 2700));

                                                isim.Keyboard.KeyPress(VirtualKeyCode.VK_T);

                                                Thread.Sleep(rnd.Next(100, 150));

                                                for (int i = 0; i < words[tries].Length; i++)
                                                {
                                                    isim.Keyboard.TextEntry(words[tries][i]);
                                                    Thread.Sleep(rnd.Next(150, 200));
                                                }

                                                isim.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                                                Thread.Sleep(5000);

                                                right = true;

                                            }
                                            else
                                            {
                                                Console.WriteLine("Bad");
                                            }

                                            tries++;

                                        }

                                    }
                                    catch
                                    {

                                        char[] char2 = word.ToCharArray();
                                        Array.Sort(char2);
                                        string word_abc2 = string.Join("", char2);
                                        File.AppendAllText(txt_words, word_abc2 + "\n");

                                        Console.WriteLine("New Word");
                                    }

                                    

                                }
                            }
                        }
                    }
                    


                }
            }
        }


    }
}

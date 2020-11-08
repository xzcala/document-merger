using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exit if less than 3 arguments are supplied
            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file>");

                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");

                System.Environment.Exit(1);
            }

            // Else begin merging
            else
            {
                StreamWriter writer = null;

                // Create new file
                try
                {
                    writer = new StreamWriter(args[args.Length - 1] + ".txt");
                }
                // Error codes (file/directory/drive/path/permission/IO)
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File " + args[args.Length - 1] + ".txt not found.");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Directory not found.");
                }
                catch (DriveNotFoundException)
                {
                    Console.WriteLine("Drive not found.");
                }
                catch (PathTooLongException)
                {
                    Console.WriteLine("The file name exceeds the path length limit.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Permission not granted.");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }

                // Copy each file into the new file inside a for nest
                for (int i = 0; i < args.Length - 1; ++i)
                {
                    StreamReader reader = null;
                    try
                    {
                        reader = new StreamReader(args[i] + ".txt");

                        reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    }
                    // Error codes (file/directory/drive/path/permission/IO)
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File " + args[i] + ".txt not found.");
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("Directory not found.");
                    }
                    catch (DriveNotFoundException)
                    {
                        Console.WriteLine("Drive not found.");
                    }
                    catch (PathTooLongException)
                    {
                        Console.WriteLine("The file name exceeds the path length limit.");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Permission not granted.");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }


                    string copy = reader.ReadLine();

                    // Paste message if not null
                    while (copy != null)
                    {
                        writer.WriteLine(copy);
                        copy = reader.ReadLine();
                    }

                    // Close reader
                    reader.Close();
                }

                // Close writer
                writer.Flush();
                writer.Close();
            }
        }
    }
}

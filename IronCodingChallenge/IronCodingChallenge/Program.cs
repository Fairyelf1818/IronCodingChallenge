using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

class Program
{
    static void Main() // I'm not sure how much I should actually comment this so my apologies if it's a bit excessive.
    {
        Console.WriteLine("Use the keys (2–9, *, 0) WHERE '#' sends.");
        Console.WriteLine("We've all used one of these phones. It's pretty self explanatory lolol");
        Console.WriteLine("* = backspace. '#' = finish.\n"); // UI for the user - basic.

        List<string> sequences = new List<string>(); // Stores the finished key sequence
        StringBuilder currentSequence = new StringBuilder(); // Holds the pending sequence

        Stopwatch stopwatch = new Stopwatch(); // Using Stopwatch instead of the well known DateTime was better as datatime didn't accurately get the seconds.
        stopwatch.Start();

        char lastKey = '\0'; // Variable name lol. stores last key used.

        while (true) // A WHILE LOOP
        {
            if (Console.KeyAvailable) // If statement - runs if a key was pressed.
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // reads key - printing.
                char key = keyInfo.KeyChar;

                double timeSinceLast = stopwatch.Elapsed.TotalSeconds; // measures time - the name speaks for itself basically.

                if ((key >= '0' && key <= '9')) // key handling
                {
                    bool timeExpired = timeSinceLast > 1; // if the user pauses
                    bool newKey = key != lastKey; // did the user change the digit?

                    if (timeExpired || newKey) // if the user pauses, or a changed digits then this should "save" (NESTED IF)
                    {
                        if (currentSequence.Length > 0) // Another nested if. 
                        {
                            sequences.Add(currentSequence.ToString());
                            currentSequence.Clear();
                        }
                    }

                    currentSequence.Append(key); // adding key to current sequence
                    Console.Write(key); // printing key

                    lastKey = key; // these reset for when it loops again
                    stopwatch.Restart();
                }
                else if (key == '*') // if statement to handle this input
                {
                    if (currentSequence.Length > 0)
                    {
                        currentSequence.Clear(); // mid sequence? delete it
                    }
                    else if (sequences.Count > 0)
                    {
                        sequences.RemoveAt(sequences.Count - 1); // if there's something to delete you can delete the last charcter
                    }

                    Console.Write("\b \b"); // this removes the deleted character from the console.
                    lastKey = '\0';
                    stopwatch.Restart();
                }
                else if (key == '#') // handles the send (#) logic
                {
                    if (currentSequence.Length > 0)
                    {
                        sequences.Add(currentSequence.ToString());
                    }
                    break; // breaks form the loop
                }

                Thread.Sleep(10); // slows loop so it doesn't lag/ overload
            }
        }

        string result = irontest.Decode(sequences);
        // decode - final output
        Console.WriteLine($"\n\nDecoded Output: {result}");
    }
}

using System;
public class Menu
{
    public int ShowMenuOptions(List<string> options, string title)
    {
        int currentIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine(title);

            for (int i = 0; i < options.Count; i++)
            {
                string optionText = options[i]?.ToString() ?? "(null)";

                if (i == currentIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-> " + optionText);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("   " + optionText);
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                currentIndex = (currentIndex == 0) ? options.Count - 1 : currentIndex - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                currentIndex = (currentIndex == options.Count - 1) ? 0 : currentIndex + 1;
            }

        } while (key != ConsoleKey.Enter);

        return currentIndex;
    }
}
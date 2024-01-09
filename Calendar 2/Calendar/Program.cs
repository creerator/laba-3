using System;
using System.Reflection.Metadata;
using CalendarServices;
using Data;
using Helpers;
using Microsoft.EntityFrameworkCore;
using Models;
using ProgramUtilities;

class Program
{
    static void Main()
    {
        ConsoleWrapper.WriteLine(Literals.welcome_message);

        ConsoleWrapper.WriteLine(Literals.separator);
        ConsoleWrapper.WriteLine(Literals.input_command);

        CommandProcessor processor = new CommandProcessor();
        
        while (processor.ProcessCommand())
        {
            ConsoleWrapper.WriteLine(Literals.separator);
            ConsoleWrapper.WriteLine(Literals.input_command);
        }
    }
}

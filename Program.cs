﻿using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CsharpToPyton
{
    public class Program
    {
        public static string run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\Python37_64\\python.exe";
            start.Arguments = string.Format("\"{0}\" {1}", cmd, args);

            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")

                    if (!stderr.Equals(""))
                        return stderr;
                    return result;
                }
            }
        }

        #region
        // este codigo es para ejecutar python pero con el motor que se descarga en nuget
        //public static string PatchParameter(string parameter, int serviceid)
        //{
        //    var engine = Python.CreateEngine(); // Extract Python language engine from their grasp
        //    var scope = engine.CreateScope(); // Introduce Python namespace (scope)
        //    var d = new Dictionary<string, object>
        //    {
        //        { "serviceid", serviceid},
        //        { "parameter", parameter}
        //    }; // Add some sample parameters. Notice that there is no need in specifically setting the object type, interpreter will do that part for us in the script properly with high probability

        //    scope.SetVariable("params", d); // This will be the name of the dictionary in python script, initialized with previously created .NET Dictionary
        //    ScriptSource source = engine.CreateScriptSourceFromFile("proceso_imagen.py"); // Load the script
        //    object result = source.Execute(scope);
        //    //parameter = scope.GetVariable<string>("parameter"); // To get the finally set variable 'parameter' from the python script
        //    //return parameter;
        //    return "";
        //}
        #endregion

        static void Main(string[] args)
        {
            string r = run_cmd("proceso_imagen.py", "-image_name imagen_a_procesar.png");
            Console.WriteLine(r);
            Console.ReadKey();
        }        
    }
}

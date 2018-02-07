/*
 * 04. Hospital
 * 
 * Your task will be to prepare an electronic register for a hospital. In the hospital we have different departments:
 * •   Cardiology
 * •   Oncology
 * •   Emergency department 
 * •   etc. 
 * 
 * Each department has 20 rooms for patients and each room has 3 beds. When a new patient goes in the hospital, 
 * he/she is placed on the first free bed in the department. If there are no free beds, the patient should go in another
 * hospital. Of course, in every hospital there are doctors. Each doctor can have patients in a different department. 
 * You will receive information about patients in the format {Department} {Doctor} {Patient}
 * 
 * After the "Output" command you will receive some other commands with what kind of output you need to print. 
 * The commands are: 
 * •   {Department} – You need to print all patients in this department in the order of receiving
 * •   {Department} {Room} – You need to print all patients in this room in alphabetical order
 * •   {Doctor} – you need to print all patients for this doctor in alphabetical order
 * 
 * The program ends when you receive command "End".
 * 
 * Input
 * On the first lines you will receive info for the hospital, department, doctors and patients in the following format:
 *                {Department} {Doctor} {Patient}
 * When you read the "Output" line you will get one or more commands telling you what you need to print
 * Read commands for printing, ‘till you reach the command "End"
 * 
 * Output
 * •   {Department} – print all patients in this department in order of receiving on new line
 * •   {Department} {Room} – print all patients in this room in alphabetical order each on new line
 * •   {Doctor} – print all patients that are healed from doctor in alphabetical order on new line
 * 
 * Constraints
 * •   {Department} – single word with length 1 < n < 100
 * •   {Doctor} – name and surname, both with length 1 < n < 20
 * •   {Patient} – unique name with length 1 < n < 20
 * •   {Room} – integer 1 <= n <= 20
 * •   Time limit: 0.3 sec. Memory limit: 16 MB.
 * 
 * Example:
 * Input:                                  Output:               Input:                                  Output:
 * Cardiology Petar Petrov Ventsi          Ventsi                Cardiology Petar Petrov Ventsi          Esmeralda
 * Oncology Ivaylo Kenov Valio             Simon                 Oncology Ivaylo Kenov Valio             Simon
 * Emergency Mariq Mircheva Simo           Esmeralda             Emergency Mariq Mircheva Simo           Ventsi
 * Cardiology Genka Shikerova Simon                              Cardiology Genka Shikerova Simon
 * Emergency Ivaylo Kenov NuPogodi                               Emergency Ivaylo Kenov NuPogodi
 * Cardiology Gosho Goshov Esmeralda                             Cardiology Gosho Goshov Esmeralda
 * Oncology Gosho Goshov Cleopatra                               Oncology Gosho Goshov Cleopatra
 * Output                                                        Output
 * Cardiology                                                    Cardiology 1
 * End                                                           End
 * 
 * Input:                                  Output:
 * Cardiology Petar Petrov Ventsi          NuPogodi
 * Oncology Ivaylo Kenov Valio             Valio
 * Emergency Mariq Mircheva Simo
 * Cardiology Genka Shikerova Simon
 * Emergency Ivaylo Kenov NuPogodi
 * Cardiology Gosho Goshov Esmeralda
 * Oncology Gosho Goshov Cleopatra
 * Output
 * Ivaylo Kenov 
 * End
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string[]>> hospital = FillHospital();

            string[] command = Console.ReadLine()
                                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

            while (command[0] != "End")
            {
                if (command.Count() == 1 && hospital.ContainsKey(command[0]))
                {
                    Action<string[]> patient = n => Console.WriteLine($"{n[1]} ");

                    hospital.Where(x => x.Key == command[0])
                            .SelectMany(sel => sel.Value)
                            .ToList()
                            .ForEach(patient);

                    // -------- Or can use this -------------------------------------------
                    //foreach (var department in hospital.Where(n => n.Key == command[0]))
                    //{
                    //    Action<string[]> patient = n => Console.WriteLine($"{n[1]} ");

                    //    department.Value.ForEach(patient); 
                    //}
                    //---------------------------------------------------------------------
                }
                else if (command.Count() == 2) 
                {
                    try
                    {
                        string department = command[0];
                        int room = int.Parse(command[1]);

                        List<string> patients = new List<string>();
                        foreach (var dep in hospital.Where(n => n.Key == department)) 
                        {
                            foreach (var pat in dep.Value) 
                            {
                                patients.Add(pat[1]);
                            }
                        }

                        patients.Skip((room * 3) - 3)
                                .Take(3)
                                .OrderBy(name => name)
                                .ToList()
                                .ForEach(name => Console.WriteLine(name));
                    }
                    catch (Exception)
                    {
                        string doctor = $"{command[0]} {command[1]}";

                        List<string> patients = new List<string>();

                        foreach (var department in hospital)
                        {
                            foreach (var docs in department.Value.Where(a => a[0] == doctor)) 
                            {
                                patients.Add(docs[1]);
                            }
                        }

                        patients.OrderBy(name => name)
                                .ToList()
                                .ForEach(name => Console.WriteLine(name));
                    }
                }
                command = Console.ReadLine()
                                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();
            }
        }

        private static Dictionary<string, List<string[]>> FillHospital()
        {
            Dictionary<string, List<string[]>> hospital = new Dictionary<string, List<string[]>>();

            string[] input = Console.ReadLine()
                                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
            
            while (input[0] != "Output")
            {
                string department = input[0];
                string doctor = $"{input[1]} {input[2]}";
                string patient = input[3];

                if (!hospital.ContainsKey(department))
                {
                    hospital[department] = new List<string[]>();
                    string[] hostipalData = new string[] { doctor, patient };
                    hospital[department].Add(hostipalData);
                }
                else
                {
                    string[] hostipalData = new string[] { doctor, patient };
                    hospital[department].Add(hostipalData);
                }

                input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
            }
            return hospital;
        }
    }
}

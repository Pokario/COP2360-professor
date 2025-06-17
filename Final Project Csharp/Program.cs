using System;
using System.Collections.Generic;
using System.Globalization;

class Contractor
{
    public string Name { get; set; }
    public int ContractorNumber { get; set; }
    public DateTime StartDate { get; set; }

    public Contractor(string name, int contractorNumber, DateTime startDate)
    {
        Name = name;
        ContractorNumber = contractorNumber;
        StartDate = startDate;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Number: {ContractorNumber}, Start Date: {StartDate.ToString("dd-MMM-yyyy")}");
    }
}

class Subcontractor : Contractor
{
    public int Shift { get; set; } // 1 = day, 2 = night
    public double HourlyRate { get; set; }

    public Subcontractor(string name, int contractorNumber, DateTime startDate, int shift, double hourlyRate)
        : base(name, contractorNumber, startDate)
    {
        Shift = shift;
        HourlyRate = hourlyRate;
    }

    public double CalculatePay(int hoursWorked)
    {
        double rate = HourlyRate;
        if (Shift == 2)
        {
            rate *= 1.03; // Apply 3% shift differential
        }
        return rate * hoursWorked;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        string shiftName = Shift == 1 ? "Day" : "Night";
        Console.WriteLine($"Shift: {shiftName}, Hourly Rate: ${HourlyRate:F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Subcontractor> subcontractors = new List<Subcontractor>();
        HashSet<int> contractorNumbers = new HashSet<int>(); // To track unique contractor numbers
        string cont;

        do
        {
            string name;
            int number;
            DateTime startDate;
            int shift;
            double rate;

            // Input: Contractor Name
            Console.Write("Enter Contractor Name: ");
            name = Console.ReadLine().Trim();

            // Input: Contractor Number (with validation)
            number = GetValidContractorNumber(contractorNumbers);

            // Input: Start Date with validation
            startDate = GetValidStartDate();

            // Input: Shift (1 for Day, 2 for Night) with validation
            shift = GetValidShift();

            // Input: Hourly Rate with validation
            rate = GetValidHourlyRate();

            // Create Subcontractor object and add to list
            Subcontractor sc = new Subcontractor(name, number, startDate, shift, rate);
            subcontractors.Add(sc);
            contractorNumbers.Add(number); // Track the contractor number

            // Ask user if they want to add another subcontractor
            Console.Write("Add another subcontractor? (y/n): ");
            cont = Console.ReadLine();

        } while (cont.ToLower() == "y");

        // Display all subcontractor details and pay
        Console.WriteLine("\nContractor and Subcontractor Details and Pay for 40 hours:");
        foreach (var sc in subcontractors)
        {
            sc.DisplayInfo();
            Console.WriteLine($"Weekly Pay (40 hrs): ${sc.CalculatePay(40):F2}\n");
        }
    }

    static int GetValidContractorNumber(HashSet<int> contractorNumbers)
    {
        int number;
        while (true)
        {
            Console.Write("Enter Contractor Number: ");
            if (int.TryParse(Console.ReadLine(), out number) && !contractorNumbers.Contains(number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid number or contractor number already exists. Please try again.");
            }
        }
    }

    static DateTime GetValidStartDate()
    {
        DateTime startDate;
        while (true)
        {
            Console.Write("Enter Start Date (mm-dd-yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                return startDate;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter a valid date.");
            }
        }
    }

    static int GetValidShift()
    {
        int shift;
        while (true)
        {
            Console.Write("Enter Shift (1 for Day, 2 for Night): ");
            if (int.TryParse(Console.ReadLine(), out shift) && (shift == 1 || shift == 2))
            {
                return shift;
            }
            else
            {
                Console.WriteLine("Invalid shift. Please enter 1 for Day or 2 for Night.");
            }
        }
    }

    static double GetValidHourlyRate()
    {
        double rate;
        while (true)
        {
            Console.Write("Enter Hourly Rate: ");
            if (double.TryParse(Console.ReadLine(), out rate) && rate > 0)
            {
                return rate;
            }
            else
            {
                Console.WriteLine("Invalid hourly rate. Please enter a positive value.");
            }
        }
    }
}

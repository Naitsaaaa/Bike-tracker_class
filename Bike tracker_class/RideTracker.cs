using System;

public class RideTracker
{
    private bool finishedRiding = false;
    private double totalDistance = 0;
    private int takenRides = 0;
    private const int maxRides = 100;
    private double[] rideDistances = new double[maxRides];

    public void StartTracking()
    {
        Console.WriteLine("Welcome to Daily Bike Tracker");
        Console.WriteLine("What's your name?");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}. Enter the number of kilometers you traveled today, then type 'done' when you are done.");

        while (!finishedRiding && takenRides < maxRides)
        {
            Console.Write("Enter the ride's total distance for today: ");
            string input = Console.ReadLine();
            bool validInput = InputValidator.ValidateInput(input);

            if (input.ToLower() == "done")
            {
                finishedRiding = true;
            }
            else if (validInput)
            {
                double distance = Convert.ToDouble(input);

                if (distance <= 0)
                {
                    Console.WriteLine("There must be a distance that is bigger than zero.");
                }
                else
                {
                    rideDistances[takenRides] = distance;
                    totalDistance += distance;
                    takenRides++;
                    Console.WriteLine($"Ride {takenRides} completed. You traveled {distance} kilometers.");
                }
            }
            else
            {
                Console.WriteLine("Invalid answer. Please enter the distance or type 'done' if you are done.");
            }
        }

        double averageDistance = CalculateAverageDistance();
        DisplaySummary(averageDistance);
    }

    private double CalculateAverageDistance()
    {
        if (takenRides == 0)
            return 0;

        double sum = 0;
        for (int i = 0; i < takenRides; i++)
        {
            sum += rideDistances[i];
        }

        return sum / takenRides;
    }

    private void DisplaySummary(double averageDistance)
    {
        Console.WriteLine($"Congratulations! You completed {takenRides} rides and traveled a total distance of {totalDistance:F2} kilometers.");
        Console.WriteLine($"The average distance per ride is {averageDistance:F2} kilometers.");
        Console.WriteLine("Thank you for choosing our app!");
    }
}

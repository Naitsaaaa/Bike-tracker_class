public static class InputValidator
{
    public static bool ValidateInput(string input)
    {
        foreach (char rideChar in input)
        {
            if (!char.IsDigit(rideChar) && rideChar != '.')
            {
                return false;
            }
        }

        return true;
    }
}

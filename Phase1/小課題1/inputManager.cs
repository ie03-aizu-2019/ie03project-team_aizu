using System;

public class inputManager
{
    public bool isNum(ref int[] values)
    {
        var input = Console.ReadLine().Split(' ');

        if(input.Length == values.Length)
        {
            for(int i = 0; i < values.Length; i++)
            {
                if(!int.TryParse(input[i],out values[i]))
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }

        return true;
    }

    public bool limitCheck(int num, int min, int max)
    {
        if(num < min && num > max)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
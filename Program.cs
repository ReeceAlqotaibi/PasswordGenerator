int _passLength;
string password = "";
const int minLength = 8;
const int maxLength = 128;

//List of character arrays: upper, lower, special, numeric - used for random password creation.
List<char[]> characterSets = new()
{
    
    new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
    new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
    new char[] { '!', '£', '$', '%', '^', '&', '*', '(', ')', ';', ':', '@', '~', '#', '<', '>', '?' },
    new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }
};

Console.WriteLine("Enter desired password length (must be greater than seven characters):");

string passLength = Console.ReadLine()!;

// Validates whether user input is numeric and that the number is greater/less than the minimum or maximum password length
if (int.TryParse(passLength, out _passLength) && (_passLength >= minLength) && (_passLength <= maxLength))
{
    GeneratePassword(_passLength);
    Console.WriteLine(password);
}


void GeneratePassword(int passwordLength)
{
    Random random = new();

    // Set the first four characters of the password to satisfy requirements: upper, lower, special, numeric
    password += characterSets[0][random.Next(characterSets[0].Length)];
    password += characterSets[1][random.Next(characterSets[1].Length)];
    password += characterSets[2][random.Next(characterSets[2].Length)];
    password += characterSets[3][random.Next(characterSets[3].Length)];

    // In each iteration, choose a random character set from the list <characterSets> 
    // Set the remaining characters of the password to a random character from the character set
    for (int i = 4; i < passwordLength; i++)
    {
        char[] characterSet = characterSets[random.Next(characterSets.Count)];
        password += characterSet[random.Next(characterSet.Length)];

    }

    // Randomise the order of the password and store in temp variable
    char[] temp_password = (password.OrderBy(item => random.Next())).ToArray();
        
    // Iterate through the characters of temp password and check if the previous character is the same as the current one
    // If current and previous are the same, generate a new random character and swap it out with the current
    for(int i = 1; i < temp_password.Length; i++)
    {
        if(temp_password[i] == temp_password[i-1])
        {
            Random rand = new();
            char[] characterSet = characterSets[rand.Next(characterSets.Count)];
            temp_password[i] = characterSet[rand.Next(characterSet.Length)];
        }
    }

    password = new string(temp_password);
}


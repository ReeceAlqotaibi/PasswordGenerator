int _passLength;
string password = "";
const int minLength = 8;
const int maxLength = 128;

List<char[]> characterSets = new()
{
    
    new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
    new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
    new char[] { '!', '£', '$', '%', '^', '&', '*', '(', ')', ';', ':', '@', '~', '#', '<', '>', '?' },
    new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }
};

Console.WriteLine("Enter desired password length (must be greater than seven characters):");

string passLength = Console.ReadLine()!;

// Validates whether user input is an integer and that the integer is greater/less than the minimum or maximum password length
if (int.TryParse(passLength, out _passLength) && (_passLength >= minLength) && (_passLength <= maxLength))
{
    GeneratePassword(_passLength);
    Console.WriteLine(password.ToString());
}

/* 
* Sets the first four characters of the password to be an uppercase, lowercase, special, and an integer between 0 and 9
* Sets the remaining characters in the password to a random selection of upper, lower, special, or integer
* Randomize the order of the password (makes sure the first four characters are not always going to be upper, lower, special, integer - in that order)
*/
void GeneratePassword(int passwordLength)
{
    Random random = new();

    password += characterSets[0][random.Next(characterSets[0].Length)];
    password += characterSets[1][random.Next(characterSets[1].Length)];
    password += characterSets[2][random.Next(characterSets[2].Length)];
    password += characterSets[3][random.Next(characterSets[3].Length)];

    for (int i = 4; i < passwordLength; i++)
    {
        char[] characterSet = characterSets[random.Next(characterSets.Count)];
        password += characterSet[random.Next(characterSet.Length)];
    }


    var randomized = password.OrderBy(item => random.Next());
    password = "";

    foreach(char character in randomized)
    {
        password += character;
    }
}


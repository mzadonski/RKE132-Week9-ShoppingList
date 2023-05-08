string folderPtah = @"C:\Users\Maria\source\date";
string fileName = "shoppingList.txt";
string failPath = Path.Combine(folderPtah, fileName);
List<string> myShoppingList = new List<string>();

if (File.Exists(failPath))
{
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(failPath, myShoppingList);
}
else
{
    File.CreateText(failPath).Close();
    Console.WriteLine($"File {fileName} dose not exist.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(failPath, myShoppingList);
}



static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();
    while (true)
    {
        Console.WriteLine("Add an item(add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return userList;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();
    int listlenght = someList.Count;
    Console.WriteLine($"You have added {listlenght} items to your shopping list.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
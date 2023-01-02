// yield return'ni oddiy return'dan farqi, u hozirgi elementni qaytarish bilan birga
// holatni (elementni) saqlab qoladi va keyingi safar undan keyingi elementni qaytaradi

IEnumerable<int> GetOneTwoThreeFourFive()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
}

foreach (int number in GetOneTwoThreeFourFive())
{
    Console.WriteLine(number);
}

Console.ReadLine();
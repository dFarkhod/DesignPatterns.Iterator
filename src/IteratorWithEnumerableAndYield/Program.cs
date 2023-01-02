// bu kodlarni yozishda quyidagi maqoladan foydalanildi: https://learn.microsoft.com/en-us/archive/msdn-magazine/2017/june/essential-net-custom-iterators-with-yield
using System.Collections;


var MuhammadsFamilyTree = new BinaryTree<string>("Muhammad (S.A.W)");

// ota va ona:
MuhammadsFamilyTree.SubItems = new Pair<BinaryTree<string>>(
  new BinaryTree<string>("Abdullah"),
  new BinaryTree<string>("Amina bint Wahb"));

// doda buvi (ota tomonidan):
MuhammadsFamilyTree.SubItems.First.SubItems =
  new Pair<BinaryTree<string>>(
  new BinaryTree<string>("Abd al-Muttalib"),
  new BinaryTree<string>("Fatima bint Amr"));

// doda buvi (ona tomonidan):
MuhammadsFamilyTree.SubItems.Second.SubItems =
  new Pair<BinaryTree<string>>(
  new BinaryTree<string>("Wahb ibn Abd Manaf"),
  new BinaryTree<string>("Barrah bint Abd al-Uzza"));

foreach (string name in MuhammadsFamilyTree)
{
    Console.WriteLine(name);
}

Console.ReadLine();

public interface IPair<T>
{
    T First { get; }
    T Second { get; }
    IEnumerator<T> GetEnumerator();
}

public struct Pair<T> : IPair<T>, IEnumerable<T>
{
    public Pair(T first, T second) : this()
    {
        First = first;
        Second = second;
    }
    public T First { get; }
    public T Second { get; }

    public IEnumerator<T> GetEnumerator()
    {
        yield return First;
        yield return Second;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class BinaryTree<T> : IEnumerable<T>
{
    public BinaryTree(T value)
    {
        Value = value;
    }

    public T Value;
    public Pair<BinaryTree<T>> SubItems;


    public IEnumerator<T> GetEnumerator()
    {
        // hozirgi elementni qaytaramiz:
        yield return Value;

        // juftlikdagi har bir element bo'yicha yurib chiqamiz:
        foreach (BinaryTree<T> tree in SubItems)
        {
            if (tree != null)
            {
                // jutlikdagi har bir element daraxt bo'lgani uchun,
                // o'sha daraxt bo'yicha yurib chiqib, undagi har bir elementni yield qilamiz:
                foreach (T item in tree)
                {
                    yield return item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

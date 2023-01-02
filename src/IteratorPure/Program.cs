ConcreteAggregate collection = new();
collection.AddStaff(new Staff(1, "Ahmad"));
collection.AddStaff(new Staff(2, "Umar"));
collection.AddStaff(new Staff(3, "Said"));
collection.AddStaff(new Staff(4, "Aziz"));
collection.AddStaff(new Staff(5, "Zafar"));
collection.AddStaff(new Staff(6, "Furqat"));
collection.AddStaff(new Staff(7, "Dilshod"));

Iterator iterator = collection.CreateIterator();
iterator.SetStep(2); // ixtiyoriy

for (Staff staff = iterator.First(); !iterator.IsDone; staff = iterator.Next())
{
    Console.WriteLine($"ID : {staff.ID}, Name : {staff.Name}");
}
Console.ReadLine();
        
public class Staff
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Staff(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

public interface IAggregate
{
    public Iterator CreateIterator();
}

// StaffCollection
public class ConcreteAggregate : IAggregate
{
    private List<Staff> _staffs = new();


    public Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return _staffs.Count; }
    }

    public void AddStaff(Staff staff)
    {
        _staffs.Add(staff);
    }

    public Staff GetStaff(int position)
    {
        return _staffs[position];
    }
}

public abstract class Iterator
{
    public abstract dynamic First();
    public abstract dynamic Next();
    public abstract void SetStep(int step);
    public abstract bool IsDone { get; }
}

// StaffIterator
public class ConcreteIterator : Iterator
{
    private ConcreteAggregate _collection;
    private int _current = 0;
    private int _step = 1;

    public ConcreteIterator(ConcreteAggregate collection)
    {
        _collection = collection;
    }

    public override void SetStep(int step)
    {
        _step = step;
    }

    public override Staff First()
    {
        _current = 0;
        return _collection.GetStaff(_current);
    }

    public override Staff Next()
    {
        _current += _step;
        if (!IsDone)
        {
            return _collection.GetStaff(_current);
        }
        else
        {
            return null;
        }
    }

    public override bool IsDone
    {
        get { return _current >= _collection.Count; }
    }
}
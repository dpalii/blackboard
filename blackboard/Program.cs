using System;
using System.Collections.Generic;

// Component: Represents a piece of knowledge or expertise
public abstract class KnowledgeComponent
{
    public abstract void Update(Blackboard blackboard);
}

// Blackboard: Acts as a shared memory that holds the current state of the problem and facilitates communication between components
public class Blackboard
{
    private Dictionary<string, int> data;

    public Blackboard()
    {
        data = new Dictionary<string, int>();
    }

    public int GetData(string key)
    {
        if (data.ContainsKey(key))
        {
            return data[key];
        }

        return 0;
    }

    public void SetData(string key, int value)
    {
        data[key] = value;
    }
}

// Concrete Knowledge Components
public class KnowledgeComponentA : KnowledgeComponent
{
    public override void Update(Blackboard blackboard)
    {
        // Retrieve data from the blackboard
        int dataA = blackboard.GetData("DataA");

        // Perform some calculations or operations
        int result = dataA * 2;

        // Update the blackboard with the new result
        blackboard.SetData("Result", result);
    }
}

public class KnowledgeComponentB : KnowledgeComponent
{
    public override void Update(Blackboard blackboard)
    {
        // Retrieve data from the blackboard
        int dataB = blackboard.GetData("DataB");

        // Perform some calculations or operations
        int result = dataB + 5;

        // Update the blackboard with the new result
        blackboard.SetData("Result", result);
    }
}

public class KnowledgeComponentC : KnowledgeComponent
{
    public override void Update(Blackboard blackboard)
    {
        // Retrieve data from the blackboard
        int result = blackboard.GetData("Result");

        // Display the final result
        Console.WriteLine($"Final Result: {result}");
    }
}

public class Program
{
    static void Main()
    {
        // Create the blackboard
        var blackboard = new Blackboard();

        // Set initial data on the blackboard
        blackboard.SetData("DataA", 10);
        blackboard.SetData("DataB", 7);

        // Create and register the knowledge components
        var componentA = new KnowledgeComponentA();
        var componentB = new KnowledgeComponentB();
        var componentC = new KnowledgeComponentC();

        // Update the knowledge components
        componentA.Update(blackboard);
        componentB.Update(blackboard);
        componentC.Update(blackboard);

        Console.ReadLine();
    }
}

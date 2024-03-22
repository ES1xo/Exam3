using System;

public class Node
{
    public int value;
    public Node left;
    public Node right;

    public Node(int value)

    {
        this.value = value;
        this.left = null;
        this.right = null;
    }
}

public class thirdTaskProgram 
{
    public static int CalculateSum(Node root)
    {
        if (root == null)
            return 0;

        return root.value + CalculateSum(root.left) + CalculateSum(root.right);
    }

    public static int FindDeepestLevel(Node root)

    {
        if (root == null)
            return 0;

        int leftlevel = FindDeepestLevel(root.left);
        int rightLevel = FindDeepestLevel(root.right);

        return Math.Max(leftlevel, rightLevel) + 1;
    }

    public static int CountNodes(Node root)
    {
        if (root == null)
            return 0;

        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }

    public static void thirdTaskMain(string[] args)
    {
        
        Node root = new Node(67);
        root.left = new Node(765);
        root.right = new Node(167);
        root.right.left = new Node(564);
        root.right.left.right = new Node(379);

        int sum = CalculateSum(root);

        int deepestLevel = FindDeepestLevel(root);

        int nodeCount = CountNodes(root);

        Console.WriteLine("Sum = " + sum);
        Console.WriteLine("Deepest level = " + deepestLevel);
        Console.WriteLine("Nodes = " + nodeCount);
    }
}

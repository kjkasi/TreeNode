var root = new TreeNode<int>
{
    Value = 10,
    Child = new TreeNode<int>
    {
        Value = 20,
        Child = new TreeNode<int>
        {
            Value = 30
        }
    }
};

var stackValues = GetStackValues(root);
var recurseValues = GetRecurseValues(root);

Console.WriteLine(string.Join(",", stackValues));
Console.WriteLine(string.Join(",", recurseValues));

IEnumerable<T> GetStackValues<T>(TreeNode<T> root)
{
    Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
    stack.Push(root);
    while (stack.Count > 0)
    {
        var node = stack.Pop();
        if (node == null)
        {
            continue;
        }
        yield return node.Value;
        stack.Push(node.Child);
    }
}

IEnumerable<T> GetRecurseValues<T>(TreeNode<T> root)
{
    if (root == null)
    {
        yield break;
    }

    yield return root.Value;
    foreach(var item in GetRecurseValues(root.Child))
    {
        yield return item;
    }
}

public class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Child { get; set; }
}
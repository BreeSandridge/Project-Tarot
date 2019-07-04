using System;
using System.Collections.Generic;

public class Node<T>
{
    public T data;
    public Node<T> next;
}

public class MyLinkedList<T> : IEnumerable<T>, System.Collections.IEnumerable
{
    private Node<T> root;
    private int size;
    public int Count { get { { return size; } } }

    private IEnumerable<Node<T>> Nodes
    {
        get
        {
            Node<T> node = root;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }
    }

    private Node<T> Pop()
    {
        Node<T> tResult = null;
        if (root != null)
        {
            tResult = root;
            root = root.next;
            size--;
        }
        return tResult;
    }

    private void Push(Node<T> item)
    {
        item.next = root;
        root = item;
        size++;
    }

    private Node<T> NodeAt(int index)
    {
        if (index < 0 || index + 1 > size)
        {
            throw new IndexOutOfRangeException("Index");
        }
        int counter = 0;
        foreach (Node<T> item in Nodes)
        {
            if (counter == index)
            {
                return item;
            }
            counter++;
        }
        return null;
    }

    public MyLinkedList()
    {
        root = null;
        size = 0;
    }

    public MyLinkedList(IEnumerable<T> Items)
    {
        foreach (T item in Items)
        {
            Add(item);
        }
    }

    public void ForEach(Action<T> action)
    {
        foreach (Node<T> item in Nodes)
        {
            action(item.data);
        }
    }

    public void AddRange(IEnumerable<T> Items)
    {
        foreach (T item in Items)
        {
            Add(item);
        }
    }

    public void AddRange(params T[] Items)
    {
        foreach (T item in Items)
        {
            Add(item);
        }
    }

    public T this[int index]
    {
        get { return NodeAt(index).data; }
        set { NodeAt(index).data = value; }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (Node<T> item in Nodes)
        {
            yield return item.data;
        }
    }

    public bool Exists(T value)
    {
        foreach (Node<T> item in Nodes)
        {
            if (Comparer<T>.Default.Compare(value, item.data) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        root = null;
        size = 0;
    }

    public void Shuffle()
    {
        if (root != null)
        {
            Random rRand = new Random();
            T[] aResult = new T[size];
            int i = 0;

            foreach (Node<T> nItem in Nodes)
            {
                int j = rRand.Next(i + 1);
                if (i != j)
                {
                    aResult[i] = aResult[j];
                }
                aResult[j] = nItem.data;
                i++;
            }
            this.Clear();
            this.AddRange(aResult);
        }
    }

    public void Sort()
    {
        root = MergeSortSub(root);
    }

    private Node<T> MergeSortSub(Node<T> nHead)
    {
        if (nHead == null || nHead.next == null) { return nHead; }
        Node<T> nSeeker = nHead;
        Node<T> nMiddle = nSeeker;
        while (nSeeker.next != null && nSeeker.next.next != null)
        {
            nMiddle = nMiddle.next;
            nSeeker = nSeeker.next.next;
        }
        Node<T> sHalf = nMiddle.next;
        nMiddle.next = null;
        Node<T> nFirst = MergeSortSub(nHead);
        Node<T> nSecond = MergeSortSub(sHalf);
        Node<T> nResult = new Node<T>();
        Node<T> nCurrent = nResult;
        while (nFirst != null && nSecond != null)
        {
            IComparer<T> comparer = Comparer<T>.Default;
            if (comparer.Compare(nFirst.data, nSecond.data) < 1)
            {
                nCurrent.next = nFirst;
                nFirst = nFirst.next;
            }
            else
            {
                nCurrent.next = nSecond;
                nSecond = nSecond.next;
            }
            nCurrent = nCurrent.next;
        }
        nCurrent.next = (nFirst == null) ? nSecond : nFirst;
        return nResult.next;
    }

    public void Add(T item)
    {
        Node<T> NewNode = new Node<T>() { data = item, next = root };
        root = NewNode;
        size++;
    }

    public IEnumerable<int> AllIndexesOf(T Value)
    {
        int IndexCount = 0;
        foreach (Node<T> item in Nodes)
        {
            if (Comparer<T>.Default.Compare(item.data, Value) == 0)
            {
                yield return IndexCount;
            }
            IndexCount++;
        }
    }

    public int IndexOf(T Value)
    {
        IEnumerator<int> eN = AllIndexesOf(Value).GetEnumerator();
        if (eN.MoveNext())
        {
            return eN.Current;
        }
        return -1;
    }

    public int LastIndexOf(T Value)
    {
        IEnumerator<int> eN = AllIndexesOf(Value).GetEnumerator();
        int Result = -1;
        while (eN.MoveNext())
        {
            Result = eN.Current;
        }
        return Result;
    }

    public void RemoveAll(Func<T, bool> match)
    {
        while (root != null && match(root.data)) //  head node
        {
            root = root.next;
            size--;
        }
        if (root != null)
        {
            Node<T> nTemp = root;
            while (nTemp.next != null)// other nodes
            {
                if (match(nTemp.next.data))
                {
                    nTemp.next = nTemp.next.next;
                    size--;
                }
                else
                {
                    nTemp = nTemp.next;
                }
            }
        }
    }

    public IEnumerable<T> Find(Predicate<T> match)
    {
        foreach (Node<T> item in Nodes)
        {
            if (match(item.data))
            {
                yield return item.data;
            }
        }
    }

    public void Distinct()
    {
        HashSet<T> uniques = new HashSet<T>();
        Node<T> nTemp = root;
        if (nTemp != null)
        {
            uniques.Add(root.data);
            while (nTemp.next != null)
            {
                if (!uniques.Add(nTemp.next.data))
                {
                    nTemp.next = nTemp.next.next;
                    size--;
                }
                else
                {
                    nTemp = nTemp.next;
                }
            }
        }
    }

    public void Reverse()
    {
        Node<T> nCurrent = root;
        Node<T> nBack = null;
        while (nCurrent != null)
        {
            Node<T> nTemp = nCurrent.next;
            nCurrent.next = nBack;
            nBack = nCurrent;
            nCurrent = nTemp;
        }
        root = nBack;
    }

    public void RemoveFirst()
    {

        if (root != null)
        {
            root = root.next;
            size--;
        }
    }

    public void RemoveLast()
    {
        if (root != null)
        {
            if (root.next == null)
            {
                root = null;
            }
            else
            {
                NodeAt(Count - 2).next = null;
            }
            size--;
        }
    }

    public void AddLast(T item)
    {
        Node<T> NewNode = new Node<T>() { data = item, next = null };
        if (root == null)
        {
            root = NewNode;
        }
        else
        {
            NodeAt(Count - 1).next = NewNode;
        }
        size++;
    }

    public void Insert(T item, int index)
    {
        if (index < 0 || index + 1 > size)
        {
            throw new IndexOutOfRangeException("Index");
        }

        Node<T> NewNode = new Node<T>() { data = item, next = null };
        if (index == 0)
        {
            NewNode.next = root;
            root = NewNode;
        }
        else
        {
            NewNode.next = NodeAt(index - 1).next;
            NodeAt(index - 1).next = NewNode;
        }
        size++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index + 1 > size)
        {
            throw new IndexOutOfRangeException("Index");
        }

        if (index == 0)
        {
            root = root.next;
        }
        else
        {
            Node<T> temp = NodeAt(index - 1);
            temp.next = temp.next.next;
        }
        size--;
    }

    public void RemoveRange(int index, int count)
    {
        if (index < 0 || index + count > size)
        {
            throw new IndexOutOfRangeException("Index");
        }
        if (index == 0)
        {
            for (int i = 0; i < count; i++)
            {
                root = root.next;
            }
        }
        else
        {
            Node<T> nStart = NodeAt(index - 1);
            for (int i = 0; i < count; i++)
            {
                nStart.next = nStart.next == null ? null : nStart.next.next;
            }
        }
        size -= count;
    }
}
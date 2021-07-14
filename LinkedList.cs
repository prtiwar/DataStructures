using System;

namespace ProgramDemo
{
    class LinkedListNode
    {
        public int data;
        public LinkedListNode next;

        public LinkedListNode(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    class LinkedList
    {
        public LinkedListNode head;

        public LinkedList()
        {
            head = null;
        }

        public void AddNodesInFront(int data)
        {
            LinkedListNode toAdd = new LinkedListNode(data);
            toAdd.next = head;
            head = toAdd;
        }

        public void AddNodesInLast(int data)
        {
            if(head == null)
            {
                head = new LinkedListNode(data);
            }
            else
            {
                LinkedListNode toAdd = new LinkedListNode(data);
                LinkedListNode current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
            
        }

        public void InsertNode(int data, int index)
        {
            if(head == null)
            {
                head = new LinkedListNode(data);
            }
            else
            {
                LinkedListNode toAdd = new LinkedListNode(data);
                LinkedListNode current = head;

                for(int i = 1; i < index-1; i++)
                {
                    current = current.next;
                }

                toAdd.next = current.next; //imp step
                current.next = toAdd;
            }
        }

        public int GetIndexOf(int data)
        {
            int count = 0;
            LinkedListNode current = head;
                        
            while(current.next != null)
            {
                count++;
                if (current.data == data)
                    return count;
                current = current.next;
            }
            return -1;
        }

        public void DeleteGivenNode(int index)
        {
            LinkedListNode current = head;
            
            if(head == null)
                Console.WriteLine("No node to delete");

            for (int i = 1; i < index - 1; i++)
                current = current.next;
            
            current.next = current.next.next;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;
            else
            {

                ListNode curr1 = l1;
                ListNode curr2 = l2;

                while (curr1 != null && curr2 != null)
                {
                    ListNode temp1 = curr1.next;
                    ListNode temp2 = curr2.next;

                    if (curr1.val <= curr2.val)
                    {
                        curr1.next = curr2;
                        curr2.next = temp1;
                    }
                    else
                    {
                        curr2.next = curr1;
                        curr1.next = temp2;
                    }
                    curr1 = temp1;
                    curr2 = temp2;
                }
                return l1;
            }
        }

        public void PrintList()
        {
            LinkedListNode current = head;

            while(current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            LinkedList List1 = new LinkedList();
            List1.AddNodesInFront(6);
            List1.AddNodesInFront(8);
            List1.AddNodesInFront(12);

            Console.WriteLine("Printing list by adding nodes in front");
            List1.PrintList();

            LinkedList List2 = new LinkedList();
            List2.AddNodesInLast(6);
            List2.AddNodesInLast(8);
            List2.AddNodesInLast(12);

            Console.WriteLine("Printing list by adding nodes at last");
            List2.PrintList();

            Console.WriteLine("Inseting new node at tail");
            List2.InsertNode(15, 3);

            Console.WriteLine("Printing list by adding nodes at last");
            List2.PrintList();

            int x = List2.GetIndexOf(19);
            
            if( x < 0)
                Console.WriteLine("Number not present in this node");
            else
                Console.WriteLine("Number present at: {0)", x);

            List2.DeleteGivenNode(3);

            Console.WriteLine("Printing list by adding nodes at last");
            List2.PrintList();

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd_laba_6
{
    internal class BinarySearchTree
    {
        private Node root;

        public void Insert(int value)
        {
            root = Insert(root, value);
        }

        private Node Insert(Node node, int value)
        {
            if (node == null) return new Node(value);
            if (value < node.Data) node.Left = Insert(node.Left, value);
            else if (value > node.Data) node.Right = Insert(node.Right, value);
            return node;
        }

        public void InOrderPrint()
        {
            InOrder(root);
            Console.WriteLine();
        }

        private void InOrder(Node node)
        {
            if (node == null) return;
            InOrder(node.Left);
            Console.Write(node.Data + " ");
            InOrder(node.Right);
        }

        public void PreOrderPrint()
        {
            PreOrder(root);
            Console.WriteLine();
        }

        private void PreOrder(Node node)
        {
            if (node == null) return;
            Console.Write(node.Data + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void Delete(int value)
        {
            root = Delete(root, value);
        }

        private Node Delete(Node node, int value)
        {
            if (node == null) return null;
            if (value < node.Data) node.Left = Delete(node.Left, value);
            else if (value > node.Data) node.Right = Delete(node.Right, value);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                Node temp = FindMin(node.Right);
                node.Data = temp.Data;
                node.Right = Delete(node.Right, temp.Data);
            }
            return node;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        public int CountMultiplesOf10()
        {
            return CountMultiplesOf10(root);
        }

        private int CountMultiplesOf10(Node node)
        {
            if (node == null) return 0;
            int count = node.Data % 10 == 0 ? 1 : 0;
            return count + CountMultiplesOf10(node.Left) + CountMultiplesOf10(node.Right);
        }

        public void RemoveLeafNodesWithoutSiblings()
        {
            root = RemoveLeafNodesWithoutSiblings(root);
        }

        private Node RemoveLeafNodesWithoutSiblings(Node node)
        {
            if (node == null)
                return null;

            node.Left = RemoveLeafNodesWithoutSiblings(node.Left);
            node.Right = RemoveLeafNodesWithoutSiblings(node.Right);

            // Видалити лівого листа без брата
            if (node.Left != null && IsLeaf(node.Left) && node.Right == null)
            {
                node.Left = null;
            }

            // Видалити правого листа без брата
            if (node.Right != null && IsLeaf(node.Right) && node.Left == null)
            {
                node.Right = null;
            }

            return node;
        }

        private bool IsLeaf(Node node)
        {
            return node != null && node.Left == null && node.Right == null;
        }
    }
}

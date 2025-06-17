using System.Text;

namespace Asd_laba_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            BinarySearchTree tree = new BinarySearchTree();
            Random rnd = new Random();

            // Генерація та вставка 29 випадкових чисел (25 + варіант 4)
            for (int i = 0; i < 29; i++)
            {
                int num = rnd.Next(-50, 51);
                tree.Insert(num);
            }

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Вивести дерево (прямий обхід)");
                Console.WriteLine("2. Вивести відсортований вміст дерева");
                Console.WriteLine("3. Додати елемент");
                Console.WriteLine("4. Видалити елемент");
                Console.WriteLine("5. Порахувати кількість елементів, кратних 10");
                Console.WriteLine("6. Видалити листи без братів");
                Console.WriteLine("0. Вийти");
                Console.Write("Оберіть опцію: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Дерево (прямий обхід):");
                        tree.PreOrderPrint();
                        break;
                    case "2":
                        Console.WriteLine("Відсортований вміст дерева:");
                        tree.InOrderPrint();
                        break;
                    case "3":
                        Console.Write("Введіть число для додавання: ");
                        if (int.TryParse(Console.ReadLine(), out int toAdd))
                            tree.Insert(toAdd);
                        break;
                    case "4":
                        Console.Write("Введіть число для видалення: ");
                        if (int.TryParse(Console.ReadLine(), out int toDelete))
                            tree.Delete(toDelete);
                        break;
                    case "5":
                        Console.WriteLine($"Кількість елементів, кратних 10: {tree.CountMultiplesOf10()}");
                        break;
                    case "6":
                        tree.RemoveLeafNodesWithoutSiblings();
                        Console.WriteLine("Листи без братів видалено.");
                        break;
                    case "0": return;
                }
            }
        }
    }
}
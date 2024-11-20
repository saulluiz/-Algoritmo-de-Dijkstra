using TrabalhoMenorCaminho;

public class Program()
{
    public static void Main()
    {
        Dijkstra d = new Dijkstra(6);
      
        d.CreateEdge(1, 3, 12);
        d.CreateEdge(1, 5, 2);
        d.CreateEdge(1, 4, 1);
        d.CreateEdge(5,2,9);
        d.CreateEdge(5, 4, 3);
        d.CreateEdge(4,3,5);
        d.CreateEdge(3,2,8);

        Console.WriteLine("Digite a origem ");
        int origem = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o fim ");
        int fim = int.Parse(Console.ReadLine());
        Console.WriteLine("Menor caminho:");
        foreach(var n in d.MinimumPath(origem, fim))
        {
            Console.Write(" -> " + n);
        }



    }
}
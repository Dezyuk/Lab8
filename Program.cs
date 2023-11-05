using Lab8;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        PartsWarehouse part1 = new PartsWarehouse("Drill", "fds51s1", 50.584, 150);
        PartsWarehouse part2 = new PartsWarehouse("Pump", "5d8sf11c", 1000.00, 58);
        PartsWarehouse part3 = new PartsWarehouse("Valve", "9df2q3f", 405.35, 7);
        PartsWarehouse part4 = new PartsWarehouse("Sealer", "a1f4y2n", 18.99, 200);


        Storehouse store = new Storehouse();
        store.AddParts(part1);
        store.AddParts(part2);
        store.AddParts(part3);
        store.AddParts(part4);

        Console.WriteLine(store);
        Console.WriteLine("--------------------------------------------------");
        store.RemovePart(part1);

        Console.WriteLine(store);
        string json;

        string output = JsonSerializer.Serialize(store);
        
        

        using (FileStream fileStream = new FileStream("Parts.json", FileMode.OpenOrCreate))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(output);
            }
        }


        
//        Stream stream = File.Open("Parts.bin", FileMode.OpenOrCreate);
//#pragma warning disable SYSLIB0011
//        BinaryFormatter bf = new BinaryFormatter();
//        bf.Serialize(stream, store);
//#pragma warning restore SYSLIB0011
//        stream.Close();


//        using (var bin = new FileStream("Parts.bin", FileMode.OpenOrCreate))
//        {
//#pragma warning disable SYSLIB0011
//            BinaryFormatter formatter = new BinaryFormatter();
//            formatter.Serialize(bin, store);
//#pragma warning restore SYSLIB0011
//        }




        using (FileStream fileStream = new FileStream("Parts.json", FileMode.Open)) { 
        using (StreamReader  reader = new StreamReader(fileStream))
            {
                json = reader.ReadToEnd();
            }
        }
        Storehouse store2 = JsonSerializer.Deserialize<Storehouse>(json);
        Console.WriteLine("New Store");
        Console.WriteLine(store2);
    }
}
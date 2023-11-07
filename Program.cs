using Lab8;



internal class Program
{
    private static void Main(string[] args)
    {
        PartsWarehouse part1 = new PartsWarehouse("Drill", "fds51s1", 60.584, 150);
        PartsWarehouse part2 = new PartsWarehouse("Pump", "5d8sf11c", 1000.00, 58);
        PartsWarehouse part3 = new PartsWarehouse("Valve", "9df2q3f", 405.35, 7);
        PartsWarehouse part4 = new PartsWarehouse("Sealer", "a1f4y2n", 28.99, 200);


        Storehouse store = new Storehouse();
        store.AddParts(part1);
        store.AddParts(part2);
        store.AddParts(part3);
        store.AddParts(part4);

        Console.WriteLine(store);
        Console.WriteLine("--------------------------------------------------");
        store.RemovePart(part1);

        Console.WriteLine(store);


        string fileNameJSON = "Parts.json";
        string fileNameBinary = "Parts.bin";
        
        FileManager.SerializationJSON(store,fileNameJSON);
        FileManager.SerializationBinary(store, fileNameBinary);



        Storehouse store2 = FileManager.DeserializationJSON(fileNameJSON);
        Console.WriteLine("Read from JSON\n--------------------------------------------------\n");
        Console.WriteLine(store2);


        Storehouse store3 = FileManager.DeserializationBinary(fileNameBinary);
        Console.WriteLine("Read from Binary\n--------------------------------------------------\n");
        Console.WriteLine(store3);



    }
}
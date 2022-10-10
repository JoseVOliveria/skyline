// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Collections.Generic;


class bitrate{


    static void Main(string[] args) {
        
        while(true){

            var RXTX = read();
            long RX = RXTX.Item1;
            long TX = RXTX.Item2;


            var RXTX2 = update(RXTX);
            long RX2 = RXTX2.Item1;
            long TX2 = RXTX2.Item2;

            Console.WriteLine("O bitrate do TX é : " + (TX2-TX)*2);
            Console.WriteLine("O bitrate do RX é : " + (RX2-RX)*2);

            Thread.Sleep(500);

        }
    }

    public static  Tuple<long, long> read(){
        
        string json = File.ReadAllText("vendor.json");
        Vendor variables = JsonSerializer.Deserialize<Vendor>(json)!;

        List<NIC> NIC = variables.NIC;

        var values = NIC.ElementAt(0);

        return Tuple.Create(values.RX,values.TX);
    }

    public static Tuple<long, long> update(Tuple<long, long> RXTX){

        Random rnd = new Random();
    
        long TX2 = RXTX.Item1 + rnd.Next(50, 200);
        long RX2 = RXTX.Item2 + rnd.Next(50, 200);

        return Tuple.Create(TX2,RX2);
    }


    public class NIC
    {
        public string Description {get;set;}
        public string MAC {get;set;}
        public string Timestamp {get;set;}
        public long RX {get;set;}
        public long TX {get;set;}
    }

    public class Vendor
    {
        public string Device {get;set;}
        public string Model {get;set;}
        public List<NIC> NIC {get;set;}
    }

}


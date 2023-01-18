// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Morstead.Spatial.Quadtree;
using System.ComponentModel;
using System.Security.Cryptography;

var summary = BenchmarkRunner.Run<Md5VsSha256>();

Console.WriteLine("Hello, World!");

public class QuadtreeBenchmark
{
    private QuadTree<ItemT<Simple>> _tree = new(new RectangleF(0,0,1000,1000));

    [GlobalSetup]
    public void Setup()
    {
      //  data = new byte[N];
      //  new Random(42).NextBytes(data);
    }

    [Benchmark]
    public void AddItem()
    {

    } 

}


[RPlotExporter]
public class Md5VsSha256
{
    private SHA256 sha256 = SHA256.Create();
    private MD5 md5 = MD5.Create();
    private byte[] data;

    [Params(1000, 10000)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        data = new byte[N];
        new Random(42).NextBytes(data);
    }

    [Benchmark]
    public byte[] Sha256() => sha256.ComputeHash(data);

    [Benchmark]
    public byte[] Md5() => md5.ComputeHash(data);
}




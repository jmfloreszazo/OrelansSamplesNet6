using System;
using Orleans.TestingHost;

namespace UnitTest;

public class ClusterFixture : IDisposable
{
    public ClusterFixture()
    {
        var builder = new TestClusterBuilder();
        builder.AddSiloBuilderConfigurator<TestSiloConfigurations>();
        Cluster = builder.Build();
        Cluster.Deploy();
    }
    public void Dispose()
    {
        Cluster.StopAllSilos();
    }
    public TestCluster Cluster { get; }
}
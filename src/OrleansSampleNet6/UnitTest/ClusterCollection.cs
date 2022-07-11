using Xunit;

namespace UnitTest;

[CollectionDefinition(ClusterCollection.Name)]
public class ClusterCollection : ICollectionFixture<ClusterFixture>
{
    public const string Name = "ClusterCollectionUnitTestingWithNet6";
}
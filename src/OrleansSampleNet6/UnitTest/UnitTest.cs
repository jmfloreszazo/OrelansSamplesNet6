using System.Threading.Tasks;
using GrainInterface;
using Orleans.TestingHost;
using Xunit;

namespace UnitTest
{
    [Collection(ClusterCollection.Name)]
    public class UnitTest
    {
        private readonly TestCluster _cluster;

        public UnitTest(ClusterFixture fixture) => _cluster = fixture.Cluster;

        [Fact]
        public async Task IsMessageCorrect()
        {
            var test = _cluster.GrainFactory.GetGrain<ISample>("1");
            var result = await test.Response("Unit Test");
            Assert.True(result.Length > 0);
        }
    }
}
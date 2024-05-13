using Student.API.ProgramPartial;
using Student.Test.Config;

namespace Student.Test.Fixtures
{
    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Program>> { }

    public class IntegrationTestsFixture<T> : IDisposable where T : class
    {
        public readonly TestAppFactory<T> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            Factory = new TestAppFactory<T>();
            Client = Factory.CreateClient();
        }

        public void Dispose()
        {
            Factory.Dispose();
            Client.Dispose();
        }
    }
}

using Xunit;

namespace GdsRazorTest.Tests.Internal;

[CollectionDefinition("GDS")]
public class GdsCollection : ICollectionFixture<CustomWebApplicationFactory<Startup>>, ICollectionFixture<SeleniumBase>
{
}

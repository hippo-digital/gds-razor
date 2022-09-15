using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GdsRazorTest.Tests.Internal;

public abstract class GdsTestBase : ClientBase<Startup>, IClassFixture<WebApplicationFactory<Startup>>
{
    protected GdsTestBase(WebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    protected override void Configure(IServiceCollection services)
    {
    }
}
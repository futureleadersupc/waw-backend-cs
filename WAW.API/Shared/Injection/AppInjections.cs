using WAW.API.Auth.Injection;
using WAW.API.Chat.Injection;
using WAW.API.Employers.Injection;
using WAW.API.Job.Injection;
using WAW.API.Shared.Domain.Repositories;
using WAW.API.Shared.Persistence.Repositories;

namespace WAW.API.Shared.Injection;

public static class AppInjections {
  public static void Register(IServiceCollection services) {
    AuthInjections.Register(services);
    CompanyInjections.Register(services);
    JobInjections.Register(services);
    ChatInjections.Register(services);

    services.AddScoped<IUnitOfWork, UnitOfWork>();
  }
}

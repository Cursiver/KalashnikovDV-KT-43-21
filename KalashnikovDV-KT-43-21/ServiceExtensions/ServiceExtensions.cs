using KalashnikovDV_KT_43_21.Interfaces.TeacherInterfaces;

namespace KalashnikovDV_KT_43_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        { 
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}

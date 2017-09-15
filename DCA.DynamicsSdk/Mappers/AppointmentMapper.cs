using DCA.DynamicsSdk.Entities;
using Models = DCA.Core.Models;

namespace DCA.DynamicsSdk.Mappers
{
    public sealed class AppointmentMapper
    {
        public static Models.Appointment GetAppointmentFromEntity(Appointment appointment)
        {
            return new Models.Appointment();
        }
    }
}

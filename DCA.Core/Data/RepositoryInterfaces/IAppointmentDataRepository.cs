using DCA.Core.Models;
using System;

namespace DCA.Core.Data.RepositoryInterfaces
{
    public interface IAppointmentDataRepository
    {
        Appointment GetAppointment(Guid appointmentId);

        void UpdateActualStartDate(Guid appointmentId, DateTime actualStartDate);
    }
}
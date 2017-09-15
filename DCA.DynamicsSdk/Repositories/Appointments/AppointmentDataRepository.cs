using DCA.Core.Data.RepositoryInterfaces;
using DCA.DynamicsSdk.Entities;
using DCA.DynamicsSdk.Mappers;
using Microsoft.Xrm.Sdk;
using System;
using System.Linq;

using Models = DCA.Core.Models;

namespace DCA.DynamicsSdk.Appointments
{
    public class AppointmentDataRepository : IAppointmentDataRepository
    {
        private readonly ICrmContext _crmContext;

        public AppointmentDataRepository(ICrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Models.Appointment GetAppointment(Guid appointmentId)
        {
            using (var context = new DcaCrmContext(_crmContext.ServiceProxy))
            {
                var appointment = context.AppointmentSet.FirstOrDefault(x => x.Id == appointmentId);
                return AppointmentMapper.GetAppointmentFromEntity(appointment);
            }
        }

        public void UpdateActualStartDate(Guid appointmentId, DateTime actualStartDate)
        {
            var appointment = new Entity(Constants.Entities.Appointment, appointmentId)
            {
                [Constants.CrmFieldNames.Apppointment.ActualStartDate] = actualStartDate
            };

            _crmContext.Update(appointment);
        }
    }
}
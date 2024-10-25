namespace MedicalAppoiments.Persistance.Models.appointments
{
    public sealed  class AppointmentsModel
    {
        public int AppointmentID { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string SpecialtyName { get; set; }

        public string StatusName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
/*  try
           {

               operationResult.Data = await (from asiento in _boletoContext.Asientos
                                             join bus in _boletoContext.Buses on asiento.IdBus equals bus.IdBus
                                             where asiento.Estatus == true
                                             orderby asiento.FechaCreacion descending
                                             select new AsientoBusModel()
                                             {
                                                 AsientoId = asiento.IdAsiento,
                                                 Bus = bus.Nombre,
                                                 BusId = bus.IdBus,
                                                 FechaCreacion = bus.FechaCreacion,
                                                 FechaModificacion = bus.FechaModificacion,
                                                 NumeroAsiento = asiento.NumeroAsiento,
                                                 NumeroPiso = asiento.NumeroPiso,
                                                 UsuarioModificacion = asiento.UsuarioModificacion
                                             }).ToListAsync(); ;
           }*/

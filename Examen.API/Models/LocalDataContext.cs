using ExamenAeroMexico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.API.Models
{
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<ExamenAeroMexico.Domain.Reservacion> Reservacions { get; set; }
    }
}
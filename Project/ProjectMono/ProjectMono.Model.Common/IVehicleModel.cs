using ProjectMono.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMono.Model.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        int MakeId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServiceContracts
{
    public interface ICitiesService
    {
        Guid ServiceInstanceId { get; }
        List<string> GetCities();
    }
}

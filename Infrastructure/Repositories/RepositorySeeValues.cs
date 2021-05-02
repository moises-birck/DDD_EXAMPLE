using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.RequestObject;
using Entities.Entities.ResponseObjects;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositorySeeValues : RepositoryGenerics<SeeValuesResponse>, ISeeValues
    { 
    
    }
}

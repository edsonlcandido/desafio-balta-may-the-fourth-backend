using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Core.Context.StarWars.UseCases.GetVehicleById;
using Xunit;

namespace StarWars.Tests.Contexts.StarWars.UseCases.GetVehicleById
{
    public class RequestTest
    {
        private Request request = new(){Id = 321 };
        private Request request1 = new(){Id = -8 };

        [Fact]
        public void Validar_Retornar_true_Ao_Chamar_IsInvalid()
        {            
            Assert.True(request1.IsInvalid());
        }

        [Fact]
        public void Validar_Retornar_false_Ao_Chamar_IsInvalid()
        {            
            Assert.False(request.IsInvalid());
        }
    }
}
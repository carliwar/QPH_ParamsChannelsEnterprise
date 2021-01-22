using AutoMapper;
using NUnit.Framework;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Infrastructure.Mapping;

namespace QPH_ParamsChannelsEnterprise.Tests.Infrastructure
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void MappingCredentialsServer_StatusTrue_ReturnStatusACTIVO()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();
            var credentialsServerDTO = new CredentialsServer
            {
                Status = true
            };

            // Act
            var result = mapper.Map<CredentialsServerDTO>(credentialsServerDTO);

            // Assert
            Assert.AreEqual("ACTIVO", result.Status);
        }

        [Test]
        public void MappingCredentialsServer_StatusFalse_ReturnStatusINACTIVO()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();
            var credentialsServerDTO = new CredentialsServer
            {
                Status = false
            };

            // Act
            var result = mapper.Map<CredentialsServerDTO>(credentialsServerDTO);

            // Assert
            Assert.AreEqual("INACTIVO", result.Status);
        }

        [Test]
        public void MappingCredentialsServerDTO_StatusACTIVO_ReturnStatusTrue()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();
            var credentialsServerDTO = new CredentialsServerDTO
            {
                Status = "ACTIVO"
            };

            // Act
            var result = mapper.Map<CredentialsServer>(credentialsServerDTO);

            // Assert
            Assert.AreEqual(true, result.Status);
        }

        [Test]
        public void MappingCredentialsServerDTO_StatusINACTIVO_ReturnStatusFalse()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();
            var credentialsServerDTO = new CredentialsServerDTO
            {
                Status = "INACTIVO"
            };

            // Act
            var result = mapper.Map<CredentialsServer>(credentialsServerDTO);

            // Assert
            Assert.AreEqual(false, result.Status);
        }
    }
}

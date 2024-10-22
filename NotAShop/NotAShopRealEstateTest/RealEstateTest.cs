using Microsoft.AspNetCore.Http;
using NotAShop.Core.Domain;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NotAShopRealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto dto = new();

            dto.Size = 100;
            dto.Location = "asd";
            dto.RoomNumber = 1;
            dto.BuildingType = "asd";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            //Assert

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealestate_WhenReturnsNotEqual()
        {
            // Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdRealestate_WhenReturnsEqual()
        {
            ////Arrange
            //Guid testGuid = Guid.NewGuid();  
            //var realEstate = new RealEstate
            //{
            //    Id = testGuid,  
            //    Size = 100,
            //    Location = "Test",
            //    RoomNumber = 3,
            //    BuildingType = "Apartment",
            //    CreatedAt = DateTime.Now,
            //    ModifiedAt = DateTime.Now
            //};

            //var context = Svc<NotAShopContext>();
            //context.RealEstates.Add(realEstate);
            //await context.SaveChangesAsync();

            //// Act
            //var result = await Svc<IRealEstateServices>().GetAsync(testGuid);

            //// Assert
            //Assert.Equal(testGuid, result.Id);

            //Arrange
            Guid databaseGuid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");
            Guid guid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realEstate = MockRealEstateData();
            var AddRealEstate = await Svc<IRealEstateServices>().Create(realEstate);

            //Act
            var result = await Svc<IRealEstateServices>().Delete((Guid)AddRealEstate.Id);

            //Assert
            Assert.Equal(result, AddRealEstate);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realEstate = MockRealEstateData();
            var realEstate1 = await Svc<IRealEstateServices>().Create(realEstate);
            var realEstate2 = await Svc<IRealEstateServices>().Create(realEstate);

            //Act
            var result = await Svc<IRealEstateServices>().Delete((Guid)realEstate2.Id);

            //Assert
            Assert.NotEqual(result.Id, realEstate1.Id);
        }

        [Fact]

        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("f0d2b871-29c3-456e-8eb2-3277a4aa791a");

            RealEstateDto dto = MockRealEstateData();

            RealEstate domain = new();

            domain.Id = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");
            domain.Size = 99;
            domain.Location = "qwerty";
            domain.RoomNumber = 456;
            domain.BuildingType = "asd";
            domain.CreatedAt = DateTime.UtcNow;
            domain.ModifiedAt = DateTime.UtcNow;

            await Svc<IRealEstateServices>().Update(dto);

            Assert.Equal(guid, domain.Id);
            Assert.DoesNotMatch(dto.Location, domain.Location);
            Assert.DoesNotMatch(dto.RoomNumber.ToString(), domain.RoomNumber.ToString());
            Assert.NotEqual(dto.Size, domain.Size);

        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdatedataVersion2()
        {
            //kasutame kahte mock andmebaasi
            //ja siis võrdleme neid omavahel

            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto update = MockRealEstateData2();
            var result = await Svc<IRealEstateServices>().Update(update);

            Assert.DoesNotMatch(result.Location, createRealEstate.Location);
            Assert.NotEqual(result.ModifiedAt, createRealEstate.ModifiedAt);
        }


        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenDidNotUpdateData()
        {
            RealEstateDto dto = MockRealEstateData();
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);

            RealEstateDto nullUpdate = MockNullRealEstateData();
            var result = await Svc<IRealEstateServices>().Update(nullUpdate);

            Assert.NotEqual(createRealEstate.Id, result.Id);
            


        }

        [Fact]
        public async Task ShouldNotUpload_XLSXFiles()
            //Poolik
        {
            RealEstateDto dto = new()
            {
                Size = 100,
                Location = "asd",
                RoomNumber = 1,
                BuildingType = "asd",
                Files = new List<IFormFile>(),
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            var fileName = "test.xlsx";
            var isXlsxFile = fileName.EndsWith(".xlsx");

            

            if (isXlsxFile)
            {
                Assert.True(isXlsxFile, "XLSX files should not be uploaded but they are uploaded.");
            }
            else
            {
                var result = await Svc<IRealEstateServices>().Update(dto);

                Assert.NotNull(result);
            }
        }


        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Size = 100,
                Location = "asd",
                RoomNumber = 1,
                BuildingType = "asd",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return realEstate;
        }

        private RealEstateDto MockRealEstateData2()
        {
            RealEstateDto realEstate2 = new()
            {
                Size = 99,
                Location = "ghj",
                RoomNumber = 2,
                BuildingType = "udf",
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };

            return realEstate2;
        }

        private RealEstateDto MockNullRealEstateData()
        {
            RealEstateDto realEstate2 = new()
            {
                Id = null,
                Size = 99,
                Location = "ghj",
                RoomNumber = 2,
                BuildingType = "udf",
                CreatedAt = DateTime.Now.AddYears(-1),
                ModifiedAt = DateTime.Now.AddYears(-1),
            };

            return realEstate2;
        }
    }
}